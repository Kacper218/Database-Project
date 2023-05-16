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


namespace Projekt_bazodanowy
{
    public partial class Form2 : Form
    { 
        private void resetSearchTextBoxes ()
        {
            idKlienta_textBox.Clear();
            imieNazwisko_textBox.Clear();
            nazwaFirmy_textBox.Clear();
            email_textBox.Clear();
            idKlienta_textBox.Clear();
            idDokumentu_textBox.Clear();
            dataZakupu_textBox.Clear();
            kwotaCalkowita_textBox.Clear();
            idProduktu_textBox.Clear();
            nazwaProduktu_textBox.Clear();
            aktualnaCena_textBox.Clear();
            dostepnosc_textBox.Clear();
            idDokumentu_textBox.Clear();
            idProduktu_textBox.Clear();
            idZakupu_textBox.Clear();
            ilosc_textBox.Clear();
            cenaZakupu_textBox.Clear();

            idKlienta_textBox.Enabled = false;
            imieNazwisko_textBox.Enabled = false;
            nazwaFirmy_textBox.Enabled = false;
            email_textBox.Enabled = false;
            idKlienta_textBox.Enabled = false;
            idDokumentu_textBox.Enabled = false;
            dataZakupu_textBox.Enabled = false;
            kwotaCalkowita_textBox.Enabled = false;
            idProduktu_textBox.Enabled = false;
            nazwaProduktu_textBox.Enabled = false;
            aktualnaCena_textBox.Enabled = false;
            dostepnosc_textBox.Enabled = false;
            idDokumentu_textBox.Enabled = false;
            idProduktu_textBox.Enabled = false;
            idZakupu_textBox.Enabled = false;
            ilosc_textBox.Enabled = false;
            cenaZakupu_textBox.Enabled = false;
        }
        private void search_comboBox_TextChanged(object sender, EventArgs e)
        {
            switch (search_comboBox.Text.ToString())
            {
                case "Klienci":
                    resetSearchTextBoxes();
                    idKlienta_textBox.Enabled = true;
                    imieNazwisko_textBox.Enabled = true;
                    nazwaFirmy_textBox.Enabled = true;
                    email_textBox.Enabled = true;
                    break;
                case "Paragony":
                    resetSearchTextBoxes();
                    idKlienta_textBox.Enabled = true;
                    idDokumentu_textBox.Enabled = true;
                    dataZakupu_textBox.Enabled = true;
                    kwotaCalkowita_textBox.Enabled = true;
                    break;
                case "Produkty":
                    resetSearchTextBoxes();
                    idProduktu_textBox.Enabled = true;
                    nazwaProduktu_textBox.Enabled = true;
                    aktualnaCena_textBox.Enabled = true;
                    dostepnosc_textBox.Enabled = true;
                    break;
                case "Zakupy":
                    resetSearchTextBoxes();
                    idDokumentu_textBox.Enabled = true;
                    idProduktu_textBox.Enabled = true;
                    idZakupu_textBox.Enabled = true;
                    ilosc_textBox.Enabled = true;
                    cenaZakupu_textBox.Enabled = true;
                    break;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                ISession session = sessionFactor.OpenSession();
                switch (search_comboBox.Text.ToString())
                {
                    case "Klienci":
                        if (e.ColumnIndex == 4)
                        {
                            using (session)
                            {
                                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                                string rowIdentifier = row.Cells["IDKlienta"].Value.ToString();

                                Klienci rowToDelete = session.Get<Klienci>(rowIdentifier);

                                if (rowToDelete != null)
                                {
                                    using (var transaction = session.BeginTransaction())
                                    {
                                        session.Delete(rowToDelete);
                                        transaction.Commit();
                                    }
                                }

                                dataGridView1.Rows.RemoveAt(e.RowIndex);
                            }
                        }
                        break;
                    case "Paragony":
                        if (e.ColumnIndex == 4)
                        {
                            using (session)
                            {
                                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                                string rowIdentifier = row.Cells["IDDokumentu"].Value.ToString();

                                Paragony rowToDelete = session.Get<Paragony>(rowIdentifier);

                                if (rowToDelete != null)
                                {
                                    using (var transaction = session.BeginTransaction())
                                    {
                                        session.Delete(rowToDelete);
                                        transaction.Commit();
                                    }
                                }

                                dataGridView1.Rows.RemoveAt(e.RowIndex);
                            }
                        }
                        break;
                    case "Produkty":
                        if (e.ColumnIndex == 4)
                        {
                            using (session)
                            {
                                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                                string rowIdentifier = row.Cells["IDProduktu"].Value.ToString();

                                Produkty rowToDelete = session.Get<Produkty>(rowIdentifier);

                                if (rowToDelete != null)
                                {
                                    using (var transaction = session.BeginTransaction())
                                    {
                                        session.Delete(rowToDelete);
                                        transaction.Commit();
                                    }
                                }

                                dataGridView1.Rows.RemoveAt(e.RowIndex);
                            }
                        }
                        break;
                    case "Zakupy":
                        if (e.ColumnIndex == 5)
                        {
                            using (session)
                            {
                                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                                string rowIdentifier = row.Cells["IDZakupu"].Value.ToString();

                                Zakupy rowToDelete = session.Get<Zakupy>(rowIdentifier);

                                if (rowToDelete != null)
                                {
                                    using (var transaction = session.BeginTransaction())
                                    {
                                        session.Delete(rowToDelete);
                                        transaction.Commit();
                                    }
                                }

                                dataGridView1.Rows.RemoveAt(e.RowIndex);
                            }
                        }
                        break;
                }
        }
        private void deleteRowButtonAdd()
        {
            DataGridViewButtonColumn delButton = new DataGridViewButtonColumn();
            delButton.HeaderText = "Usuń";
            delButton.Text = "-";
            delButton.Name = "delButton";
            delButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(delButton);
        }
        private void search_button_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            ISession session = sessionFactor.OpenSession();
            try
            {
                switch (search_comboBox.Text.ToString())
                {
                    case "Klienci":
                        {
                            using (session)
                            {
                                var query = session.QueryOver<Klienci>();
                                if (!string.IsNullOrEmpty(idKlienta_textBox.Text))
                                {
                                    query = query.Where(c => c.IDKlienta == idKlienta_textBox.Text);
                                }

                                if (!string.IsNullOrEmpty(nazwaFirmy_textBox.Text))
                                {
                                    if (string.IsNullOrEmpty(imieNazwisko_textBox.Text))
                                    {
                                        query = query.WhereRestrictionOn(c => c.NazwaFirmy).IsInsensitiveLike("%" + nazwaFirmy_textBox.Text + "%");
                                    }
                                }

                                if (!string.IsNullOrEmpty(imieNazwisko_textBox.Text))
                                {
                                    if (string.IsNullOrEmpty(nazwaFirmy_textBox.Text))
                                    {
                                        query = query.WhereRestrictionOn(c => c.ImieNazwisko).IsInsensitiveLike("%" + imieNazwisko_textBox.Text + "%");
                                    }
                                }

                                if (!string.IsNullOrEmpty(imieNazwisko_textBox.Text))
                                {
                                    if (!string.IsNullOrEmpty(nazwaFirmy_textBox.Text))
                                    {
                                        MessageBox.Show("Wpisano za dużo parametrów (Imie Nazwisko oraz Nazwa Firmy)", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                if (!string.IsNullOrEmpty(email_textBox.Text))
                                {
                                    query = query.WhereRestrictionOn(c => c.Email).IsInsensitiveLike("%" + email_textBox.Text + "%");
                                }
                                var result = query.List();
                                var bindingList = new BindingList<Klienci>(result);
                                dataGridView1.DataSource = bindingList;
                                dataGridView1.AllowUserToAddRows = false;
                            }
                            break;
                        }
                    case "Paragony":
                        using (session)
                        {
                            var query = session.QueryOver<Paragony>();
                            if (!(string.IsNullOrEmpty(idDokumentu_textBox.Text)) ||
                                !(string.IsNullOrEmpty(dataZakupu_textBox.Text)) ||
                                !(string.IsNullOrEmpty(idKlienta_textBox.Text)) ||
                                !(string.IsNullOrEmpty(kwotaCalkowita_textBox.Text)))
                            {
                                if (!string.IsNullOrEmpty(idDokumentu_textBox.Text))
                                {
                                    query = query.Where(c => c.IDDokumentu == idDokumentu_textBox.Text);
                                }
                                if (!string.IsNullOrEmpty(dataZakupu_textBox.Text))
                                {
                                    DateTime dataZakupu;
                                    if (DateTime.TryParse(dataZakupu_textBox.Text, out dataZakupu))
                                    {
                                        query = query.Where(c => c.DataZakupu == dataZakupu);
                                    }
                                }
                                if (!string.IsNullOrEmpty(idKlienta_textBox.Text))
                                {
                                    query = query.Where(c => c.IDKlienta == idKlienta_textBox.Text);
                                }
                                if (!string.IsNullOrEmpty(kwotaCalkowita_textBox.Text))
                                {
                                    query = query.Where(c => c.KwotaCalkowita == kwotaCalkowita_textBox.Text);
                                }
                            }
                            var result = query.List();
                            var bindingList = new BindingList<Paragony>(result);
                            dataGridView1.DataSource = bindingList;
                            dataGridView1.AllowUserToAddRows = false;
                        }
                        break;
                    case "Produkty":
                        using (session)
                        {
                            var query = session.QueryOver<Produkty>();
                            if (!string.IsNullOrEmpty(idProduktu_textBox.Text))
                            {
                                query = query.Where(c => c.IDProduktu == idProduktu_textBox.Text);
                            }
                            if (!string.IsNullOrEmpty(nazwaProduktu_textBox.Text))
                            {
                                query = query.WhereRestrictionOn(c => c.Nazwa).IsInsensitiveLike("%" + nazwaProduktu_textBox.Text + "%");
                            }
                            if (!string.IsNullOrEmpty(aktualnaCena_textBox.Text))
                            {
                                query = query.Where(c => c.CenaAktualna == aktualnaCena_textBox.Text);
                            }
                            if (!string.IsNullOrEmpty(dostepnosc_textBox.Text))
                            {
                                query = query.WhereRestrictionOn(c => c.Dostepnosc).IsInsensitiveLike("%" + dostepnosc_textBox.Text + "%");
                            }
                            var result = query.List();
                            var bindingList = new BindingList<Produkty>(result);
                            dataGridView1.DataSource = bindingList;
                            dataGridView1.AllowUserToAddRows = false;
                        }
                        break;
                    case "Zakupy":
                        using (session)
                        {
                            var query = session.QueryOver<Zakupy>();

                            if (!string.IsNullOrEmpty(idZakupu_textBox.Text))
                            {
                                query = query.Where(c => c.IDZakupu == idZakupu_textBox.Text);
                            }

                            if (!string.IsNullOrEmpty(idDokumentu_textBox.Text))
                            {
                                query = query.Where(c => c.IDDokumentu == idDokumentu_textBox.Text);
                            }

                            if (!string.IsNullOrEmpty(idProduktu_textBox.Text))
                            {
                                query = query.Where(c => c.IDProduktu == idProduktu_textBox.Text);
                            }

                            if (!string.IsNullOrEmpty(ilosc_textBox.Text))
                            {
                                query = query.Where(c => c.Ilosc == ilosc_textBox.Text);
                            }

                            if (!string.IsNullOrEmpty(cenaZakupu_textBox.Text))
                            {
                                query = query.Where(c => c.CenaZakupu == cenaZakupu_textBox.Text);
                            }
                            var result = query.List();
                            var bindingList = new BindingList<Zakupy>(result);
                            dataGridView1.DataSource = bindingList;
                            dataGridView1.AllowUserToAddRows = false;
                        }
                        break;
                }
            deleteRowButtonAdd(); 
            } catch (Exception ex) { 
                MessageBox.Show("Wystapił nastepujący błąd: \n" + ex.ToString(),"Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
