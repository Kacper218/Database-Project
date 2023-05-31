using NHibernate;
using NHibernate.Cfg;
using Projekt_bazodanowy.Models;
using Remotion.Linq.Parsing.ExpressionVisitors.Transformation.PredefinedTransformations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate.Mapping;
using System.Globalization;

namespace Projekt_bazodanowy
{
    public partial class Form4 : Form
    {
        public static Form4 instance;
        public readonly ISessionFactory sessionFactor;
        public readonly string identifier;

        public Form4(ISessionFactory sessionFactor, string receiptIdentifier)
        {
            InitializeComponent();
            instance = this;
            instance.CenterToScreen();
            this.sessionFactor = sessionFactor;
            this.Text = "Szczegóły Paragonu";
            identifier = receiptIdentifier;

            paragony_dataGridView.AutoResizeColumns();
            paragony_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            fillProducts();
            detailsFormInfoDisplay();
        }

        public void fillProducts()
        {
            ISession session = sessionFactor.OpenSession();
            using (session)
            {
                var produkty = session.Query<Produkty>().ToList();

                foreach (var produkt in produkty)
                {
                    produkty_comboBox.Items.Add(produkt.Nazwa);
                }
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
            ISession session = sessionFactor.OpenSession();
            using (session)
            {
                var query = session.QueryOver<Zakupy>();
                // Perform search based on provided criteria

                query = query.Where(c => c.IDDokumentu == identifier);

                var result = query.List();
                var bindingList = new BindingList<Zakupy>(result);
                paragony_dataGridView.DataSource = bindingList;
                paragony_dataGridView.AllowUserToAddRows = false;

                var paragony = session.Query<Paragony>().ToList();

                List<Paragony> filteredParagony;
                filteredParagony = paragony.Where(d => d.IDDokumentu == identifier).ToList();

                idDokumentu_label.Text = "ID Dokumentu: " + identifier;
                DataWystawienia_label.Text = "Data wystawienia: " + filteredParagony[0].DataZakupu;
                idKlienta_label.Text = "ID Klienta: " + filteredParagony[0].IDKlienta;
                kwotaCalkowita_label.Text = "Kwota: " + filteredParagony[0].KwotaCalkowita;

            }
            deleteRowButtonAdd();
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string getProductID()
        {
            ISession session = sessionFactor.OpenSession();
            string id="";
            using (session)
            {
                var query = session.Query<Produkty>().ToList();

                List<Produkty> produkt;
                produkt = query.Where(d => d.Nazwa == produkty_comboBox.Text).ToList();

                id = produkt[0].IDProduktu;
            }
            return id;
            
        }
        public string getProductPrice()
        {
            ISession session = sessionFactor.OpenSession();
            string price="";
            using (session)
            {
                var query = session.Query<Produkty>().ToList();

                List<Produkty> produkt;
                produkt = query.Where(d => d.Nazwa == produkty_comboBox.Text).ToList();

                price = produkt[0].CenaAktualna;
            }
            return price;

        }
        private void addRecipt_button_Click(object sender, EventArgs e)
        {
            try
            {
                using (var session = sessionFactor.OpenSession())
                {
                    var zakup = new Zakupy();
                    // Set fields based on user input

                    zakup.IDDokumentu = identifier;
                    zakup.Ilosc = ilosc_textBox.Text.ToString();
                    zakup.IDProduktu = getProductID();

                    // Specyfing '.' format for double values for easier database conversion
                    CultureInfo format;
                    format = CultureInfo.CreateSpecificCulture("en-CA");

                    zakup.CenaZakupu = (double.Parse(getProductPrice()) * double.Parse(zakup.Ilosc)).ToString(format);

                    session.Save(zakup);
                    session.Flush();
                    session.Clear();
                    detailsFormInfoDisplay();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Wystapił nastepujący błąd: \n" + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void paragony_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ISession session = sessionFactor.OpenSession();
            try
            {
                // Check if the delete button column is clicked
                if (e.ColumnIndex == 0)
                {
                    using (session)
                    {
                        DataGridViewRow row = paragony_dataGridView.Rows[e.RowIndex];
                        string rowIdentifier = row.Cells["IDZakupu"].Value.ToString();

                        Zakupy rowToDelete = session.Get<Zakupy>(rowIdentifier);
                        MessageBox.Show(rowToDelete.IDZakupu);


                        if (rowToDelete != null)
                        {
                            using (var transaction = session.BeginTransaction())
                            {
                                session.Delete(rowToDelete);
                                transaction.Commit();
                            }
                        }
                        paragony_dataGridView.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystapił nastepujący błąd: \n" + ex.ToString(), "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
