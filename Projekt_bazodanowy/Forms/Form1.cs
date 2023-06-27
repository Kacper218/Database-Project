using System;
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

namespace Projekt_bazodanowy
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public ISessionFactory sessionFactor;
        private SimpleTcpClient client;
        private bool isLoggedIn = false;

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
            if(message == "LOGIN_SUCCES")
            {
                isLoggedIn = true;
                MessageBox.Show("Połączono z bazą danych.");
            } else if(message == "LOGIN_FAILED")
            {
                isLoggedIn = false;
                MessageBox.Show("Nie połączono z bazą danych.");
            } else
            {
                string[] jsonResponse = e.MessageString.Split(';');
                string command = jsonResponse[0];
                //MessageBox.Show(command);
                switch(command)
                {
                    case "SIMPLE_SEARCH":
                        string table = jsonResponse[1];
                        switch(table)
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
                        MessageBox.Show("Pomyslnie wygenerowano raport.","Git", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case "ERROR":
                        MessageBox.Show("Wystapil bład podczas generowania raportu:\n" + jsonResponse[1],"Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // Connection with server on port 1234
                client.Connect("localhost", 1234);
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

                if(isLoggedIn)
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
    }
}

