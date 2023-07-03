using Projekt_bazodanowy.DataRepository;
using Projekt_bazodanowy.Models;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Projekt_bazodanowy
{
    public partial class Form4 : Form
    {
        public static Form4 instance;
        public readonly SimpleTcpClient connection;
        public readonly string identifier;

        public Form4(SimpleTcpClient connection, string receiptIdentifier)
        {
            InitializeComponent();
            instance = this;
            instance.CenterToScreen();
            this.connection = connection;
            this.Text = "Szczegóły Paragonu";
            identifier = receiptIdentifier;

            paragony_dataGridView.AutoResizeColumns();
            paragony_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            fillProducts();
            detailsFormInfoDisplay();
        }

        public void fillProducts()
        {
            string messege = "GETPRODUCTS;";
            connection.WriteLineAndGetReply(messege, TimeSpan.FromSeconds(2));
            List<Produkty> productsInfo = ProductsListDataRepository.DataList;

            foreach (var product in productsInfo)
            {
                produkty_comboBox.Items.Add(product.Nazwa);
            }
        }

        // Adds a delete button column to the DataGridView
        private void deleteRowButtonAdd()
        {
            DataGridViewButtonColumn delButton = new DataGridViewButtonColumn();
            delButton.HeaderText = "Usuń";
            delButton.Text = "-";
            delButton.Name = "delButton";
            delButton.UseColumnTextForButtonValue = true;
            paragony_dataGridView.Columns.Add(delButton);
        }
        public void detailsFormInfoDisplay()
        {
            paragony_dataGridView.Columns.Clear(); // Clears existing columns in the DataGridView
            paragony_dataGridView.DataSource = null; // Clears the data source of the DataGridView

            string recieptToSearch = "SEARCH;Receipts;" + identifier + ";-;-;-;";
            connection.WriteLineAndGetReply(recieptToSearch, TimeSpan.FromSeconds(2));
            IList<Paragony> recieptInfo = ReceiptsJsonDataRepository.DataList;
            Paragony paragon = recieptInfo.FirstOrDefault();

            idDokumentu_label.Text = "ID Dokumentu: " + identifier;
            DataWystawienia_label.Text = "Data wystawienia: " + paragon.DataZakupu;
            idKlienta_label.Text = "ID Klienta: " + paragon.IDKlienta;
            kwotaCalkowita_label.Text = "Kwota: " + paragon.KwotaCalkowita;

            string purchasesToSearch = "SEARCH;Purchase;-;" + identifier + ";-;-;-;";
            connection.WriteLineAndGetReply(purchasesToSearch, TimeSpan.FromSeconds(2));
            IList<Zakupy> purchaseInfo = PurchaseJsonDataRepository.DataList;
            paragony_dataGridView.DataSource = purchaseInfo;
            paragony_dataGridView.AllowUserToAddRows = false;

            deleteRowButtonAdd();
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string getProductID()
        {
            string id = "";
            List<Produkty> productsInfo = ProductsListDataRepository.DataList;
            foreach (var product in productsInfo)
            {
                if (product.Nazwa == produkty_comboBox.Text) id = product.IDProduktu;
            }
            return id;

        }
        private void addRecipt_button_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(ilosc_textBox.Text))
                {
                    throw new Exception("Nie wypełniono pola z ilością produktu.");
                }

                string messege = "ADD;Purchase;" + identifier + ";";
                messege += getProductID() + ";";
                messege += ilosc_textBox.Text + ";";

                CultureInfo format;
                format = CultureInfo.CreateSpecificCulture("en-CA");

                string price = "";
                List<Produkty> productsInfo = ProductsListDataRepository.DataList;

                foreach (var product in productsInfo)
                {
                    if (product.Nazwa == produkty_comboBox.Text) price = product.CenaAktualna;
                }

                double temp1, temp2;
                double.TryParse(price, out temp1);
                double.TryParse(ilosc_textBox.Text, out temp2);
                messege += (temp1 * temp2).ToString(format) + ";";
                connection.WriteLineAndGetReply(messege, TimeSpan.FromSeconds(2));
                detailsFormInfoDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystapił nastepujący błąd: \n" + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void paragony_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn clickedColumn = paragony_dataGridView.Columns[e.ColumnIndex];
            string columnName = clickedColumn.Name;
            try
            {
                if (columnName == "delButton")
                {
                    string messege = "DELETE;Purchase;";
                    DataGridViewRow row = paragony_dataGridView.Rows[e.RowIndex];
                    string rowIdentifier = row.Cells["IDZakupu"].Value.ToString();
                    messege += rowIdentifier + ";";
                    connection.WriteLineAndGetReply(messege, TimeSpan.FromSeconds(2));
                    detailsFormInfoDisplay();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystapił nastepujący błąd: \n" + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
