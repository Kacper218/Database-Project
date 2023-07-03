﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using Projekt_bazodanowy.DataRepository;
using Projekt_bazodanowy.Models;
using SimpleTCP;
using DodatkoweElementy;

namespace Projekt_bazodanowy
{
    public partial class Form1 : Form, ILoginInfo
    {
        public static Form1 instance;
        public ISessionFactory sessionFactor;
        private SimpleTcpClient client;
        private bool isLoggedIn = false;
        private int portNumber = 1234;

        public Form1()
        {
            InitializeComponent();
            instance = this;
            instance.CenterToScreen();
            this.Text = "Logowanie";

            loginTextBox.Enabled = false;
            passwordTextBox.Enabled = false;
            button1.Enabled = false;

            // Client Initialization
            client = new SimpleTcpClient();
            client.StringEncoder = System.Text.Encoding.UTF8;
            client.DataReceived += Client_DataRecieved;
        }

        private void Client_DataRecieved(object sender, SimpleTCP.Message e)
        {
            string message = e.MessageString;
            if (message == "LOGIN_SUCCES")
            {
                isLoggedIn = true;
                MessageBox.Show("Połączono z bazą danych.");
            } else if (message == "LOGIN_FAILED")
            {
                isLoggedIn = false;
                MessageBox.Show("Nie połączono z bazą danych.");
            } else
            {
                string[] jsonResponse = e.MessageString.Split(';');
                string command = jsonResponse[0];
                switch (command)
                {
                    case "SIMPLE_SEARCH":
                        string table = jsonResponse[1];
                        switch (table)
                        {
                            case "Clients":
                                List<Klienci> clientsResponseData = JsonConvert.DeserializeObject<List<Klienci>>(jsonResponse[2]);
                                IList<Klienci> clientsDataList = clientsResponseData;
                                ClientsJsonDataRepository.DataList = clientsDataList;
                                break;
                            case "Products":
                                List<Produkty> productsResponseData = JsonConvert.DeserializeObject<List<Produkty>>(jsonResponse[2]);
                                IList<Produkty> produtsDataList = productsResponseData;
                                ProductsJsonDataRepository.DataList = produtsDataList;
                                break;
                            case "Purchase":
                                List<Zakupy> purchaseResponseData = JsonConvert.DeserializeObject<List<Zakupy>>(jsonResponse[2]);
                                IList<Zakupy> purchaseDataList = purchaseResponseData;
                                PurchaseJsonDataRepository.DataList = purchaseDataList;
                                break;
                            case "Receipts":
                                List<Paragony> receiptsResponseData = JsonConvert.DeserializeObject<List<Paragony>>(jsonResponse[2]);
                                IList<Paragony> receiptsDataList = receiptsResponseData;
                                ReceiptsJsonDataRepository.DataList = receiptsDataList;
                                break;
                        }
                        break;

                    case "REPORT":
                        PdfReportDto reportDto = JsonConvert.DeserializeObject<PdfReportDto>(jsonResponse[2]);
                        string base64String = reportDto.Base64Data;
                        byte[] reportBytes = Convert.FromBase64String(base64String);
                        File.WriteAllBytes(jsonResponse[1], reportBytes);
                        MessageBox.Show("Pomyslnie wygenerowano raport.", "Git", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case "ERROR":
                        MessageBox.Show("Wystapil bład podczas:\n" + jsonResponse[1] + ":" + jsonResponse[2], "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case "SEARCH":
                        string table2 = jsonResponse[1];
                        switch (table2)
                        {
                            case "Clients":
                                BindingList<Klienci> clientsResponseData = JsonConvert.DeserializeObject<BindingList<Klienci>>(jsonResponse[2]);
                                IList<Klienci> clientsDataList = clientsResponseData;
                                ClientsJsonDataRepository.DataList = clientsDataList;
                                break;
                            case "Products":
                                BindingList<Produkty> productsResponseData = JsonConvert.DeserializeObject<BindingList<Produkty>>(jsonResponse[2]);
                                IList<Produkty> productsDataList = productsResponseData;
                                ProductsJsonDataRepository.DataList = productsDataList;
                                break;
                            case "Purchase":
                                BindingList<Zakupy> purchaseResponseData = JsonConvert.DeserializeObject<BindingList<Zakupy>>(jsonResponse[2]);
                                IList<Zakupy> purchaseDataList = purchaseResponseData;
                                PurchaseJsonDataRepository.DataList = purchaseDataList;
                                break;
                            case "Receipts":
                                BindingList<Paragony> receiptsResponseData = JsonConvert.DeserializeObject<BindingList<Paragony>>(jsonResponse[2]);
                                IList<Paragony> receiptsDataList = receiptsResponseData;
                                ReceiptsJsonDataRepository.DataList = receiptsDataList;
                                break;
                        }
                        break;

                    case "DELETE":
                        /*
                        if (jsonResponse[1] == "SUCCES")
                        {
                            //MessageBox.Show("Pomyslnie usunięto wybraną pozycję.");
                        }
                        */
                        break;

                    case "GETPRODUCTS":
                        List<Produkty> products = JsonConvert.DeserializeObject<List<Produkty>>(jsonResponse[1]);
                        ProductsListDataRepository.DataList = products;
                        break;
                }
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // Connection with server on port 1234
                client.Connect("localhost", this.portNumber);
                MessageBox.Show("Połączono z serwerem.");

                loginTextBox.Enabled = true;
                passwordTextBox.Enabled = true;
                button1.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string user = loginTextBox.Text.ToString();
                string password = passwordTextBox.Text.ToString();


                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
                {
                    throw new Exception("Nie podano loginu lub hasla!");
                }

                string messege = "connect" + ":" + user + ":" + password + ":";
                client.WriteLineAndGetReply(messege, TimeSpan.FromSeconds(3));

                if (isLoggedIn)
                {
                    //Create an instance of Form2 and show it
                    Form2 form2 = new Form2(client);
                    this.Hide();
                    form2.Show();
                    form2.BringToFront();
                }
            }
            catch (Exception ex)
            {
                // Display error message
                MessageBox.Show("Wystapił nastepujący błąd: \n" + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            passwordTextBox.PasswordChar = '*';
        }

        private void loginTextBox_Click(object sender, EventArgs e)
        {
            loginTextBox.Clear();
        }

        private void passwordTextBox_Click(object sender, EventArgs e)
        {
            passwordTextBox.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Disconnect();
            Application.Exit();
        }

        int ILoginInfo.portnum { get => this.portNumber; set => this.portNumber = value; }

        string ILoginInfo.Username { get => this.loginTextBox.Text; set => this.loginTextBox.Text = value; }

        string ILoginInfo.Password { get => this.passwordTextBox.Text; set => this.passwordTextBox.Text = value; }

        event EventHandler ILoginInfo.ConnectToServer
        {
            add => buttonConnect.Click += value;
            remove => buttonConnect.Click -= value;
        }

        event EventHandler ILoginInfo.ConnectToDatabase
        {
                add => button1.Click += value;
                remove => button1.Click -= value;
        }
    }
}

