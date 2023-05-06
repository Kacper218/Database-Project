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
        private void segment1_position_Click(object sender, EventArgs e)
        {
            segment1_all.Checked = false;
        }

        private void segment1_all_Click(object sender, EventArgs e)
        {
            segment1_position.Checked = false;
        }

        private void segmentUnlock(ComboBox search, ComboBox column, Button button, TextBox textBox, CheckBox position, CheckBox all)
        {
            search.Enabled = true;
            column.Enabled = true;
            textBox.Enabled = true;
            button.Enabled = true;
            position.Enabled = true;
            all.Enabled = true;
        }

        private void searchComboBoxOptions(string segment, ComboBox column)
        {
            switch(segment)
            {
                case "Klienci":
                    column.Items.Clear();
                    column.Items.Add("ID Klienta");
                    column.Items.Add("Imie i Nazwisko");
                    column.Items.Add("Nazwa firmy");
                    column.Items.Add("Email");
                    break;
                case "Produkty":
                    column.Items.Clear();
                    column.Items.Add("ID produktu");
                    column.Items.Add("Nazwa produktu");
                    column.Items.Add("Aktualna cena produktu");
                    column.Items.Add("Dostępna ilość");
                    break;
                case "Paragony":
                    column.Items.Clear();
                    column.Items.Add("Nr paragonu/faktury");
                    column.Items.Add("Data zakupu");
                    column.Items.Add("ID Klienta");
                    column.Items.Add("Kwota całkowita");
                    break;
                case "Zakupy":
                    column.Items.Clear();
                    column.Items.Add("ID Zakupu");
                    column.Items.Add("Nr paragonu/faktury");
                    column.Items.Add("ID Produktu");
                    column.Items.Add("Zakupiona ilość");
                    column.Items.Add("Cena zakupu");
                    break;
            }
        
        }

        private void segment1_nextButton_Click(object sender, EventArgs e)
        {
            segmentUnlock(segment2_search, segment2_column, segment2_nextButton, segment2_textBox, segment2_position, segment2_all);
        }
        private void segment2_nextButton_Click(object sender, EventArgs e)
        {
            segmentUnlock(segment3_search, segment3_column, segment3_nextButton, segment3_textBox, segment3_position, segment3_all);
        }
        private void segment3_nextButton_Click(object sender, EventArgs e)
        {
            segmentUnlock(segment4_search, segment4_column, segment4_nextButton, segment4_textBox, segment4_position, segment4_all);
        }

        private void segment4_nextButton_Click(object sender, EventArgs e)
        {
            segmentUnlock(segment5_search, segment5_column, segment5_nextButton, segment5_textBox, segment5_position, segment5_all);
        }

        private void segment1_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            segment1_column.SelectedIndex = -1;
            searchComboBoxOptions(segment1_search.Text.ToString(), segment1_column);
        }
        private void segment2_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            segment2_column.SelectedIndex = -1;
            searchComboBoxOptions(segment2_search.Text.ToString(), segment2_column);
        }
        private void segment3_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            segment3_column.SelectedIndex = -1;
            searchComboBoxOptions(segment3_search.Text.ToString(), segment3_column);
        }

        private void segment4_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            segment4_column.SelectedIndex = -1;
            searchComboBoxOptions(segment4_search.Text.ToString(), segment4_column);
        }

        private void segment5_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            segment5_column.SelectedIndex = -1;
            searchComboBoxOptions(segment5_search.Text.ToString(), segment5_column);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(segment1_all.Checked)
            {
                ISession session = sessionFactor.OpenSession();
                switch(segment1_search.Text.ToString())
                {
                    case "Klienci":
                        switch(segment1_column.SelectedIndex)
                        {
                            case 0:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Klienci>()
                                        .Select(c => c.IDKlienta)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {IDKlienta = c}).ToList();
                                }
                                break;
                            case 1:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Klienci>()
                                        .Select(c => c.ImieNazwisko)
                                        .Where(c => c.ImieNazwisko != "")
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {ImieNazwisko = c}).ToList();
                                }
                                break;
                            case 2:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Klienci>()
                                        .Select(c => c.NazwaFirmy)
                                        .Where(c => c.NazwaFirmy != "")
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {NazwaFirmy = c}).ToList();
                                }
                                break;
                            case 3:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Klienci>()
                                        .Select(c => c.Email)
                                        .Where(c => c.Email != "")
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {Email = c}).ToList();
                                }
                                break;
                        }
                        break;
                    case "Produkty":
                        switch(segment1_column.SelectedIndex)
                        {
                            case 0:
                                using (session)
                                {
                                    IList<int>prodInfo = session.QueryOver<Produkty>()
                                        .Select(c => c.IDProduktu)
                                        .List<int>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {IDProduktu = c}).ToList();
                                }
                                break;
                            case 1:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Produkty>()
                                        .Select(c => c.Nazwa)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {Nazwa = c}).ToList();
                                }
                                break;
                            case 2:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Produkty>()
                                        .Select(c => c.CenaAktualna)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {CenaAktualna = c}).ToList();
                                }
                                break;
                            case 3:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Produkty>()
                                        .Select(c => c.Dostepnosc)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {Dostepnosc = c}).ToList();
                                }
                                break;
                        }
                        break; 
                    case "Paragony":
                        switch(segment1_column.SelectedIndex)
                        {
                            case 0:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Paragony>()
                                        .Select(c => c.IDDokumentu)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {IDDokumentu = c}).ToList();
                                }
                                break;
                            case 1:
                                using (session)
                                {
                                    IList<DateTime>prodInfo = session.QueryOver<Paragony>()
                                        .Select(c => c.DataZakupu)
                                        .List<DateTime>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {DataZakupu = c}).ToList();
                                }
                                break;
                            case 2:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Paragony>()
                                        .Select(c => c.IDKlienta)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {IDKlienta = c}).ToList();
                                }
                                break;
                            case 3:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Paragony>()
                                        .Select(c => c.KwotaCalkowita)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {KwotaCalkowita = c}).ToList();
                                }
                                break;
                        }
                        break;
                    case "Zakupy":
                        switch(segment1_column.SelectedIndex)
                        {
                            case 0:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Zakupy>()
                                        .Select(c => c.IDZakupu)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {IDZakupu = c}).ToList();
                                }
                                break;
                            case 1:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Zakupy>()
                                        .Select(c => c.IDDokumentu)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {IDDokumentu = c}).ToList();
                                }
                                break;
                            case 2:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Zakupy>()
                                        .Select(c => c.IDProduktu)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {IDProduktu = c}).ToList();
                                }
                                break;
                            case 3:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Zakupy>()
                                        .Select(c => c.Ilosc)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {Ilosc = c}).ToList();
                                }
                                break;
                            case 4:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Zakupy>()
                                        .Select(c => c.CenaZakupu)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {CenaZakupu = c}).ToList();
                                }
                                break;
                        }
                        break;
                }
            }
            else if(segment1_position.Checked)
            {
                string searchParameter = segment1_textBox.Text.ToString();

                ISession session = sessionFactor.OpenSession();
                switch(segment1_search.Text.ToString())
                {
                    case "Klienci":
                        switch(segment1_column.SelectedIndex)
                        {
                            case 0:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Klienci>()
                                        .Select(c => c.IDKlienta)
                                        .Where(c => c.IDKlienta == searchParameter)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {IDKLienta = c}).ToList();
                                }
                                break;
                            case 1:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Klienci>()
                                        .Select(c => c.ImieNazwisko)
                                        .Where(c => c.ImieNazwisko == searchParameter)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {ImieNazwisko = c}).ToList();
                                }
                                break;
                            case 2:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Klienci>()
                                        .Select(c => c.NazwaFirmy)
                                        .Where(c => c.NazwaFirmy == searchParameter)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {NazwaFirmy = c}).ToList();
                                }
                                break;
                            case 3:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Klienci>()
                                        .Select(c => c.Email)
                                        .Where(c => c.Email == searchParameter)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {Email = c}).ToList();
                                }
                                break;
                        }
                        break;
                    case "Produkty":
                        switch(segment1_column.SelectedIndex)
                        {
                            case 0:
                                using (session)
                                {
                                    IList<int> prodInfo = session.QueryOver<Produkty>()
                                        .Select(c => c.IDProduktu)
                                        .Where(c => c.IDProduktu == Int32.Parse(searchParameter))
                                        .List<int>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {IDProduktu = c}).ToList();
                                }
                                break;
                            case 1:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Produkty>()
                                        .Select(c => c.Nazwa)
                                        .Where(c => c.Nazwa == searchParameter)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {Nazwa = c}).ToList();
                                }
                                break;
                            case 2:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Produkty>()
                                        .Select(c => c.CenaAktualna)
                                        .Where(c => c.CenaAktualna == searchParameter)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {CenaAktualna = c}).ToList();
                                }
                                break;
                            case 3:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Produkty>()
                                        .Select(c => c.Dostepnosc)
                                        .Where(c => c.Dostepnosc == searchParameter)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {Dostepnosc = c}).ToList();
                                }
                                break;
                        }
                        break; 
                    case "Paragony":
                        switch(segment1_column.SelectedIndex)
                        {
                            case 0:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Paragony>()
                                        .Select(c => c.IDDokumentu)
                                        .Where(c => c.IDDokumentu == searchParameter)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {IDDokumentu = c}).ToList();
                                }
                                break;
                            case 1:
                                using (session)
                                {
                                    IList<DateTime>prodInfo = session.QueryOver<Paragony>()
                                        .Select(c => c.DataZakupu)
                                        .Where(c => c.DataZakupu == DateTime.Parse(searchParameter))
                                        .List<DateTime>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {DataZakupu = c}).ToList();
                                }
                                break;
                            case 2:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Paragony>()
                                        .Select(c => c.IDKlienta)
                                        .Where(c => c.IDKlienta == searchParameter)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {IDKlienta = c}).ToList();
                                }
                                break;
                            case 3:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Paragony>()
                                        .Select(c => c.KwotaCalkowita)
                                        .Where(c => c.KwotaCalkowita == searchParameter)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {KwotaCalkowita = c}).ToList();
                                }
                                break;
                        }
                        break;
                    case "Zakupy":
                        switch(segment1_column.SelectedIndex)
                        {
                            case 0:
                                using (session)
                                {
                                    IList<int >prodInfo = session.QueryOver<Zakupy>()
                                        .Select(c => c.IDZakupu)
                                        .Where(c => c.IDZakupu == Int32.Parse(searchParameter))
                                        .List<int>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {IDZakupu = c}).ToList();
                                }
                                break;
                            case 1:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Zakupy>()
                                        .Select(c => c.IDDokumentu)
                                        .Where(c => c.IDDokumentu == searchParameter)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {IDDokumentu = c}).ToList();
                                }
                                break;
                            case 2:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Zakupy>()
                                        .Select(c => c.IDProduktu)
                                        .Where(c => c.IDProduktu == searchParameter)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {IDProduktu = c}).ToList();
                                }
                                break;
                            case 3:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Zakupy>()
                                        .Select(c => c.Ilosc)
                                        .Where(c => c.Ilosc == searchParameter)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {Ilosc = c}).ToList();
                                }
                                break;
                            case 4:
                                using (session)
                                {
                                    IList<string >prodInfo = session.QueryOver<Zakupy>()
                                        .Select(c => c.CenaZakupu)
                                        .Where(c => c.CenaZakupu == searchParameter)
                                        .List<string>();

                                    dataGridView1.DataSource = prodInfo.Select(c => new {CenaZakupu = c}).ToList();
                                }
                                break;
                        }
                        break;
                }
            }
        }
    }
}
