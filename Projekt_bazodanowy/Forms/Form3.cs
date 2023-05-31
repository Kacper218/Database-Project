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

namespace Projekt_bazodanowy
{
    public partial class Form3 : Form
    {
        public static Form3 instance;
        public readonly ISessionFactory sessionFactor;
        public readonly string identifier;

        public Form3(ISessionFactory sessionFactor, string clientIdentifier)
        {
            InitializeComponent();
            instance = this;
            instance.CenterToScreen();
            this.sessionFactor = sessionFactor;
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
            ISession session = sessionFactor.OpenSession();
            using (session)
            {
                var query = session.QueryOver<Paragony>();
                // Perform search based on provided criteria

                query = query.Where(c => c.IDKlienta == identifier);

                var result = query.List();
                var bindingList = new BindingList<Paragony>(result);
                klienci_dataGridView.DataSource = bindingList;
                klienci_dataGridView.AllowUserToAddRows = false;

                var klienci = session.Query<Klienci>().ToList();

                List<Klienci> filteredKlienci;
                filteredKlienci = klienci.Where(d => d.IDKlienta == identifier).ToList();

                idKlienta_label.Text = "ID Klienta: " + identifier;
                email_label.Text = "Email: " + filteredKlienci[0].Email;

                if (string.IsNullOrEmpty(filteredKlienci[0].ImieNazwisko))
                {
                    nazwaKlienta_label.Text = "Nazwa Firmy: " + filteredKlienci[0].NazwaFirmy;
                }
                else
                {
                    nazwaKlienta_label.Text = "Nazwa Klienta: " + filteredKlienci[0].ImieNazwisko;
                }
            }
            detailsRowButtonAdd();
            deleteRowButtonAdd();
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addRecipt_button_Click(object sender, EventArgs e)
        {
            using (var session = sessionFactor.OpenSession())
            {
                var paragon = new Paragony();
                // Set fields based on user input
                paragon.IDDokumentu = idDok_textBox.Text.ToString();
                // Parse user date input to correct DateTime format
                paragon.DataZakupu = dataWyst_dateTimePicker.Value;
                paragon.IDKlienta = identifier;
                paragon.KwotaCalkowita = "0";
                session.Save(paragon);
                session.Flush();
                session.Clear();
                detailsFormInfoDisplay();
            }
        }

        private void klienci_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ISession session = sessionFactor.OpenSession();
            try
            {
                DataGridViewColumn clickedColumn = klienci_dataGridView.Columns[e.ColumnIndex];
                string columnName = clickedColumn.Name;
                // Check if the delete button column is clicked
                if (columnName == "delButton")
                {
                    using (session)
                    {
                        DataGridViewRow row = klienci_dataGridView.Rows[e.RowIndex];
                        string rowIdentifier = row.Cells["IDDokumentu"].Value.ToString();

                        Paragony rowToDelete = session.Get<Paragony>(rowIdentifier);

                        // Check if the primary key is referenced in another table
                        bool isReferenced = session.QueryOver<Zakupy>()
                        .Where(re => re.IDDokumentu == rowIdentifier)
                        .RowCount() > 0;

                        if (isReferenced)
                        {
                            throw new Exception("Nie można usunąć wiersza używanego przez inne tabele.");
                        }

                        if (rowToDelete != null)
                        {
                            using (var transaction = session.BeginTransaction())
                            {
                                session.Delete(rowToDelete);
                                transaction.Commit();
                            }
                        }
                        klienci_dataGridView.Rows.RemoveAt(e.RowIndex);
                    }
                } else if (columnName == "detailsButton")
                {
                    DataGridViewRow row = klienci_dataGridView.Rows[e.RowIndex];
                    string rowIdentifier = row.Cells["IDDokumentu"].Value.ToString();

                    // Create an instance of Form4 and show it
                    Form4 form4 = new Form4(sessionFactor, rowIdentifier);
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
