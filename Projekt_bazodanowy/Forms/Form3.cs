using Projekt_bazodanowy.DataRepository;
using Projekt_bazodanowy.Models;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Projekt_bazodanowy
{
    public partial class Form3 : Form
    {
        public static Form3 instance;
        public readonly SimpleTcpClient connection;
        public readonly string identifier;

        public Form3(SimpleTcpClient connection, string clientIdentifier)
        {
            InitializeComponent();
            instance = this;
            instance.CenterToScreen();
            this.connection = connection;
            this.Text = "Szczegóły Klienta";
            identifier = clientIdentifier;

            klienci_dataGridView.AutoResizeColumns();
            klienci_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            detailsFormInfoDisplay();
        }

        // Adds a delete button column to the DataGridView
        private void deleteRowButtonAdd()
        {
            DataGridViewButtonColumn delButton = new DataGridViewButtonColumn();
            delButton.HeaderText = "Usuń";
            delButton.Text = "-";
            delButton.Name = "delButton";
            delButton.UseColumnTextForButtonValue = true;
            klienci_dataGridView.Columns.Add(delButton);
        }

        // Adds a details button column to the DataGridView
        private void detailsRowButtonAdd()
        {
            DataGridViewButtonColumn detailsButton = new DataGridViewButtonColumn();
            detailsButton.HeaderText = "Szczegóły";
            detailsButton.Name = "detailsButton";
            detailsButton.UseColumnTextForButtonValue = true;
            klienci_dataGridView.Columns.Add(detailsButton);
        }

        public void detailsFormInfoDisplay()
        {
            klienci_dataGridView.Columns.Clear(); // Clears existing columns in the DataGridView
            klienci_dataGridView.DataSource = null; // Clears the data source of the DataGridView

            string clientsToSearch = "SEARCH;Clients;" + identifier + ";-;-;-;";
            connection.WriteLineAndGetReply(clientsToSearch, TimeSpan.FromSeconds(2));
            IList<Klienci> clientsInfo = ClientsJsonDataRepository.DataList;
            Klienci klient = clientsInfo.FirstOrDefault();

            idKlienta_label.Text = "ID Klienta: " + identifier;
            email_label.Text = "Email: " + klient.Email;

            if (string.IsNullOrEmpty(klient.ImieNazwisko))
            {
                nazwaKlienta_label.Text = "Nazwa Firmy: " + klient.NazwaFirmy;
            }
            else
            {
                nazwaKlienta_label.Text = "Nazwa Klienta: " + klient.ImieNazwisko;
            }

            string receiptToSearch = "SEARCH;Receipts;-;-;" + identifier + ";-;";
            connection.WriteLineAndGetReply(receiptToSearch, TimeSpan.FromSeconds(2));
            IList<Paragony> receiptInfo = ReceiptsJsonDataRepository.DataList;
            klienci_dataGridView.DataSource = receiptInfo;
            klienci_dataGridView.AllowUserToAddRows = false;

            detailsRowButtonAdd();
            deleteRowButtonAdd();
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addRecipt_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(idDok_textBox.Text))
                {
                    throw new Exception("Nie wypełniono pola z id dokumentu.");
                }
                string receiptToAdd = "ADD;Receipts;";
                // Set fields based on user input
                receiptToAdd += idDok_textBox.Text + ";";
                // Parse user date input to correct DateTime format
                receiptToAdd += dataWyst_dateTimePicker.Value + ";";
                receiptToAdd += identifier + ";";
                receiptToAdd += "0" + ";";
                connection.WriteLineAndGetReply(receiptToAdd, TimeSpan.FromSeconds(2));
                detailsFormInfoDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystapił nastepujący błąd: \n" + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void klienci_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                DataGridViewColumn clickedColumn = klienci_dataGridView.Columns[e.ColumnIndex];
                string columnName = clickedColumn.Name;
                if (columnName == "delButton")
                {
                    string messege = "DELETE;Receipts;";
                    DataGridViewRow row = klienci_dataGridView.Rows[e.RowIndex];
                    string rowIdentifier = row.Cells["IDDokumentu"].Value.ToString();
                    messege += rowIdentifier + ";";
                    connection.WriteLineAndGetReply(messege, TimeSpan.FromSeconds(2));
                    detailsFormInfoDisplay();
                }
                else if (columnName == "detailsButton")
                {
                    DataGridViewRow row = klienci_dataGridView.Rows[e.RowIndex];
                    string rowIdentifier = row.Cells["IDDokumentu"].Value.ToString();

                    // Create an instance of Form4 and show it
                    Form4 form4 = new Form4(connection, rowIdentifier);
                    form4.Show();
                    form4.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystapił nastepujący błąd: \n" + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
