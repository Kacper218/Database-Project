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

        private void search_button_Click(object sender, EventArgs e)
        {
            ISession session = sessionFactor.OpenSession();
            dataGridView1.DataSource = null;
            switch (search_comboBox.Text.ToString())
            {
                case "Klienci":
                    {
                        //when user put all three parameters for search
                        if (!(string.IsNullOrEmpty(idKlienta_textBox.Text)) &&
                            (!(string.IsNullOrEmpty(imieNazwisko_textBox.Text) ||
                                !((string.IsNullOrEmpty(nazwaFirmy_textBox.Text))) &&
                            !(string.IsNullOrEmpty(email_textBox.Text)))))
                        {
                            if (!(string.IsNullOrEmpty(imieNazwisko_textBox.Text)) && !(string.IsNullOrEmpty(nazwaFirmy_textBox.Text)))
                            {
                                MessageBox.Show("Wpisano za dużo parametrów (Imie Nazwisko oraz Nazwa Firmy)", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if ((string.IsNullOrEmpty(imieNazwisko_textBox.Text)))
                                {
                                    //when user want to search with company name
                                    using (session)
                                    {
                                        dataGridView1.DataSource = session.QueryOver<Klienci>()
                                            .Select(c => c.IDKlienta, c => c.NazwaFirmy, c => c.Email)
                                            .Where(c => c.IDKlienta == idKlienta_textBox.Text && c.NazwaFirmy == nazwaFirmy_textBox.Text && c.Email == email_textBox.Text)
                                            .List<object[]>()
                                            .Select(c => new { IDKlienta = (string)c[0], NazwaFirmy = (string)c[1], Email = (string)c[2] })
                                            .ToList();
                                    }
                                }
                                else
                                {
                                    //when user want to search with name / surname
                                    using (session)
                                    {
                                        dataGridView1.DataSource = session.QueryOver<Klienci>()
                                            .Select(c => c.IDKlienta, c => c.ImieNazwisko, c => c.Email)
                                            .Where(c => c.IDKlienta == idKlienta_textBox.Text && c.ImieNazwisko == imieNazwisko_textBox.Text && c.Email == email_textBox.Text)
                                            .List<object[]>()
                                            .Select(c => new { IDKlienta = (string)c[0], NazwaFirmy = (string)c[1], Email = (string)c[2] })
                                            .ToList();
                                    }
                                }
                            }
                        }
                        //when user put ID and name / company name
                        else if (!(string.IsNullOrEmpty(idKlienta_textBox.Text)) &&
                            (!(string.IsNullOrEmpty(imieNazwisko_textBox.Text)) ||
                                !(string.IsNullOrEmpty(nazwaFirmy_textBox.Text))))
                        {
                            if (!(string.IsNullOrEmpty(imieNazwisko_textBox.Text)) && !(string.IsNullOrEmpty(nazwaFirmy_textBox.Text)))
                            {
                                MessageBox.Show("Wpisano za dużo parametrów (Imie Nazwisko oraz Nazwa Firmy)", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if ((string.IsNullOrEmpty(imieNazwisko_textBox.Text)))
                                {
                                    // ID and company name
                                    using (session)
                                    {
                                        dataGridView1.DataSource = session.QueryOver<Klienci>()
                                            .Select(c => c.IDKlienta, c => c.NazwaFirmy, c => c.Email)
                                            .Where(c => c.IDKlienta == idKlienta_textBox.Text && c.NazwaFirmy == nazwaFirmy_textBox.Text)
                                            .List<object[]>()
                                            .Select(c => new { IDKlienta = (string)c[0], Nazwa_Firmy = (string)c[1], Email = (string)c[2] })
                                            .ToList();
                                    }
                                }
                                else
                                {
                                    // ID and name / surname
                                    using (session)
                                    {
                                        dataGridView1.DataSource = session.QueryOver<Klienci>()
                                            .Select(c => c.IDKlienta, c => c.ImieNazwisko, c => c.Email)
                                            .Where(c => c.IDKlienta == idKlienta_textBox.Text && c.ImieNazwisko == imieNazwisko_textBox.Text)
                                            .List<object[]>()
                                            .Select(c => new { IDKlienta = (string)c[0], Imie_Nazwisko = (string)c[1], Email = (string)c[2] })
                                            .ToList();
                                    }
                                }
                            }
                        }
                        //when user put ID and email
                        else if (!(string.IsNullOrEmpty(idKlienta_textBox.Text)) &&
                            !(string.IsNullOrEmpty(email_textBox.Text)))
                        {
                            using (session)
                            {
                                dataGridView1.DataSource = session.QueryOver<Klienci>()
                                    .Select(c => c.IDKlienta, c => c.ImieNazwisko, c => c.NazwaFirmy, c => c.Email)
                                    .Where(c => c.IDKlienta == idKlienta_textBox.Text && c.Email == email_textBox.Text)
                                    .List<object[]>()
                                    .Select(c => new { IDKlienta = (string)c[0], Imie_Nazwisko = (string)c[1], Nazwa_Firmy = (string)c[2], Email = (string)c[3] })
                                    .ToList();
                            }
                        }
                        //when user put name / surname or company name and email
                        else if (!(string.IsNullOrEmpty(email_textBox.Text)) &&
                            (!(string.IsNullOrEmpty(imieNazwisko_textBox.Text)) ||
                                !(string.IsNullOrEmpty(nazwaFirmy_textBox.Text))))
                        {

                            if (!(string.IsNullOrEmpty(imieNazwisko_textBox.Text)) && !(string.IsNullOrEmpty(nazwaFirmy_textBox.Text)))
                            {
                                MessageBox.Show("Wpisano za dużo parametrów (Imie Nazwisko oraz Nazwa Firmy)", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if ((string.IsNullOrEmpty(imieNazwisko_textBox.Text)))
                                {
                                    // email and company name
                                    using (session)
                                    {
                                        dataGridView1.DataSource = session.QueryOver<Klienci>()
                                            .Select(c => c.IDKlienta, c => c.NazwaFirmy, c => c.Email)
                                            .Where(c => c.Email == email_textBox.Text && c.NazwaFirmy == nazwaFirmy_textBox.Text)
                                            .List<object[]>()
                                            .Select(c => new { IDKlienta = (string)c[0], Nazwa_Firmy = (string)c[1], Email = (string)c[2] })
                                            .ToList();
                                    }
                                }
                                else
                                {
                                    // email and name / surname
                                    using (session)
                                    {
                                        dataGridView1.DataSource = session.QueryOver<Klienci>()
                                            .Select(c => c.IDKlienta, c => c.ImieNazwisko, c => c.Email)
                                            .Where(c => c.Email == email_textBox.Text && c.ImieNazwisko == imieNazwisko_textBox.Text)
                                            .List<object[]>()
                                            .Select(c => new { IDKlienta = (string)c[0], Imie_Nazwisko = (string)c[1], Email = (string)c[2] })
                                            .ToList();
                                    }
                                }
                            }
                            /*
                                            using (session)
                                            {
                                                dataGridView1.DataSource = session.QueryOver<Klienci>()
                                                    .Select(c => c.IDKlienta, c => c.NazwaFirmy, c => c.Email)
                                                    .Where(c => c.IDKlienta == idKlienta_textBox.Text && c.NazwaFirmy == nazwaFirmy_textBox.Text && c.Email == email_textBox.Text)
                                                    .List<object[]>()
                                                    .Select(c => new { IDKlienta = (string)c[0], NazwaFirmy = (string)c[1], Email = (string)c[2] })
                                                    .ToList();
                                            }
                            */





                            if (!(string.IsNullOrEmpty(idKlienta_textBox.Text)))
                            {
                                string idKlienta = idKlienta_textBox.Text.ToString();
                            }
                            break;





                        }
                        //when user put only id
                        else if (!(string.IsNullOrEmpty(idKlienta_textBox.Text)))
                        {
                            using (session)
                            {
                                dataGridView1.DataSource = session.QueryOver<Klienci>()
                                    .Select(c => c.IDKlienta, c => c.ImieNazwisko,c => c.NazwaFirmy, c => c.Email)
                                    .Where(c => c.IDKlienta == idKlienta_textBox.Text)
                                    .List<object[]>()
                                    .Select(c => new { IDKlienta = (string)c[0], Imie_Nazwisko = (string)c[1], Nazwa_Firmy = (string)c[2], Email = (string)c[3] })
                                    .ToList();
                            }
                        }
                        //when user put only email 
                        else if (!(string.IsNullOrEmpty(email_textBox.Text)))
                        {
                            using (session)
                            {
                                dataGridView1.DataSource = session.QueryOver<Klienci>()
                                    .Select(c => c.IDKlienta, c => c.ImieNazwisko ,c => c.NazwaFirmy, c => c.Email)
                                    .Where(c => c.Email == email_textBox.Text)
                                    .List<object[]>()
                                    .Select(c => new { IDKlienta = (string)c[0], Imie_Nazwisko = (string)c[1], Nazwa_Firmy = (string)c[2], Email = (string)c[3] })
                                    .ToList();
                            }
                        }
                        //when user put only name/surname or company name
                        else if (!(string.IsNullOrEmpty(imieNazwisko_textBox.Text)) ||
                            !(string.IsNullOrEmpty(nazwaFirmy_textBox.Text)))
                        {
                            if (!(string.IsNullOrEmpty(imieNazwisko_textBox.Text)) && !(string.IsNullOrEmpty(nazwaFirmy_textBox.Text)))
                            {
                                MessageBox.Show("Wpisano za dużo parametrów (Imie Nazwisko oraz Nazwa Firmy)", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if ((string.IsNullOrEmpty(imieNazwisko_textBox.Text)))
                                {
                                    //when user want to search with company name only
                                    using (session)
                                    {
                                        dataGridView1.DataSource = session.QueryOver<Klienci>()
                                            .Select(c => c.IDKlienta,c => c.ImieNazwisko, c => c.NazwaFirmy, c => c.Email)
                                            .Where(c => c.NazwaFirmy == nazwaFirmy_textBox.Text)
                                            .List<object[]>()
                                            .Select(c => new { IDKlienta = (string)c[0], Imie_Nazwisko = (string)c[1], Nazwa_Firmy = (string)c[2], Email = (string)c[3] })
                                            .ToList();
                                    }
                                }
                                else
                                {
                                    //when user want to search with name / surname
                                    using (session)
                                    {
                                        dataGridView1.DataSource = session.QueryOver<Klienci>()
                                            .Select(c => c.IDKlienta,c => c.ImieNazwisko, c => c.NazwaFirmy, c => c.Email)
                                            .Where(c => c.ImieNazwisko == imieNazwisko_textBox.Text)
                                            .List<object[]>()
                                            .Select(c => new { IDKlienta = (string)c[0], Imie_Nazwisko = (string)c[1], Nazwa_Firmy = (string)c[2], Email = (string)c[3] })
                                            .ToList();
                                    }
                                }
                            }
                        }
                    break;
                    }
                case "Paragony":
                    if (!(string.IsNullOrEmpty(idDokumentu_textBox.Text)) ||
                        !(string.IsNullOrEmpty(dataZakupu_textBox.Text)) ||
                        !(string.IsNullOrEmpty(idKlienta_textBox.Text)) ||
                        !(string.IsNullOrEmpty(kwotaCalkowita_textBox.Text)))
                    {
                        using (session)
                        {
                            var query = session.QueryOver<Paragony>();
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

                            dataGridView1.DataSource = query
                                .Select(c => c.IDDokumentu, c => c.DataZakupu, c => c.IDKlienta, c => c.KwotaCalkowita)
                                .List<object[]>()
                                .Select(c => new { IDDokumentu = (string)c[0], DataZakupu = (DateTime)c[1], IDKlienta = (string)c[2], KwotaCalkowita = (string)c[3] })
                                .ToList();
                        }
                    }

                    break;
                case "Produkty":
                    break;
                case "Zakupy":
                    break;
            }
        }
        /*
                            using (session)
                            {
                                dataGridView1.DataSource = session.QueryOver<Klienci>()
                                    .Select(c => c.IDKlienta, c => c.NazwaFirmy, c => c.Email)
                                    .Where(c => c.IDKlienta == idKlienta_textBox.Text)
                                    .List<object[]>()
                                    .Select(c => new { IDKlienta = (string)c[0], Imie_Nazwisko = (string)c[1],Nazwa_Firmy = (string)c[2], Email = (string)c[3] })
                                    .ToList();
                            }

                                    using (session)
                                    {
                                        dataGridView1.DataSource = session.QueryOver<Klienci>()
                                            .Select(c => c.IDKlienta, c => c.NazwaFirmy, c => c.Email)
                                            .Where(c => c.Email == email_textBox.Text && c.NazwaFirmy == nazwaFirmy_textBox.Text)
                                            .List<object[]>()
                                            .Select(c => new { IDKlienta = (string)c[0], Nazwa_Firmy = (string)c[1], Email = (string)c[2] })
                                            .ToList();
                                    }
        */

        //------------------------------------------------------------//
        private void segment1_position_Click(object sender, EventArgs e)
        {
            segment1_all.Checked = false;
        }

        private void segment1_all_Click(object sender, EventArgs e)
        {
            segment1_position.Checked = false;
        }
        private void segment2_position_Click(object sender, EventArgs e)
        {
            segment2_all.Checked = false;
        }

        private void segment2_all_Click(object sender, EventArgs e)
        {
            segment2_position.Checked = false;
        }

        private void segment3_position_Click(object sender, EventArgs e)
        {
            segment3_all.Checked = false;
        }

        private void segment3_all_Click(object sender, EventArgs e)
        {
            segment4_position.Checked = false;
        }

        private void segment4_position_Click(object sender, EventArgs e)
        {
            segment4_all.Checked = false;
        }

        private void segment4_all_Click(object sender, EventArgs e)
        {
            segment4_position.Checked = false;
        }

        private void segment5_position_Click(object sender, EventArgs e)
        {
            segment5_all.Checked = false;
        }

        private void segment5_all_Click(object sender, EventArgs e)
        {
            segment5_position.Checked = false;
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

        private void segmentInfoGet(ComboBox search, ComboBox column,TextBox textBox, CheckBox position, CheckBox all)
        {
            if (all.Checked)
                {
                    ISession session = sessionFactor.OpenSession();
                    switch (search.Text.ToString())
                    {
                        case "Klienci":
                            switch (column.SelectedIndex)
                            {
                                case 0:
                                    using (session)
                                    {
                                        IList<string> prodInfo = session.QueryOver<Klienci>()
                                            .Select(c => c.IDKlienta)
                                            .List<string>();

                                        dataGridView1.DataSource = prodInfo.Select(c => new { IDKlienta = c }).ToList();
                                    }
                                    break;
                                case 1:
                                    using (session)
                                    {
                                        IList<string> prodInfo = session.QueryOver<Klienci>()
                                            .Select(c => c.ImieNazwisko)
                                            .Where(c => c.ImieNazwisko != "")
                                            .List<string>();

                                        dataGridView1.DataSource = prodInfo.Select(c => new { ImieNazwisko = c }).ToList();
                                    }
                                    break;
                                case 2:
                                    using (session)
                                    {
                                        IList<string> prodInfo = session.QueryOver<Klienci>()
                                            .Select(c => c.NazwaFirmy)
                                            .Where(c => c.NazwaFirmy != "")
                                            .List<string>();

                                        dataGridView1.DataSource = prodInfo.Select(c => new { NazwaFirmy = c }).ToList();
                                    }
                                    break;
                                case 3:
                                    using (session)
                                    {
                                        IList<string> prodInfo = session.QueryOver<Klienci>()
                                            .Select(c => c.Email)
                                            .Where(c => c.Email != "")
                                            .List<string>();

                                        dataGridView1.DataSource = prodInfo.Select(c => new { Email = c }).ToList();
                                    }
                                    break;
                            }
                            break;
                        case "Produkty":
                            switch (column.SelectedIndex)
                            {
                                case 0:
                                    using (session)
                                    {
                                        IList<int> prodInfo = session.QueryOver<Produkty>()
                                            .Select(c => c.IDProduktu)
                                            .List<int>();

                                        dataGridView1.DataSource = prodInfo.Select(c => new { IDProduktu = c }).ToList();
                                    }
                                    break;
                                case 1:
                                    using (session)
                                    {
                                        IList<string> prodInfo = session.QueryOver<Produkty>()
                                            .Select(c => c.Nazwa)
                                            .List<string>();

                                        dataGridView1.DataSource = prodInfo.Select(c => new { Nazwa = c }).ToList();
                                    }
                                    break;
                                case 2:
                                    using (session)
                                    {
                                        IList<string> prodInfo = session.QueryOver<Produkty>()
                                            .Select(c => c.CenaAktualna)
                                            .List<string>();

                                        dataGridView1.DataSource = prodInfo.Select(c => new { CenaAktualna = c }).ToList();
                                    }
                                    break;
                                case 3:
                                    using (session)
                                    {
                                        IList<string> prodInfo = session.QueryOver<Produkty>()
                                            .Select(c => c.Dostepnosc)
                                            .List<string>();

                                        dataGridView1.DataSource = prodInfo.Select(c => new { Dostepnosc = c }).ToList();
                                    }
                                    break;
                            }
                            break;
                        case "Paragony":
                            switch (column.SelectedIndex)
                            {
                                case 0:
                                    using (session)
                                    {
                                        IList<string> prodInfo = session.QueryOver<Paragony>()
                                            .Select(c => c.IDDokumentu)
                                            .List<string>();

                                        dataGridView1.DataSource = prodInfo.Select(c => new { IDDokumentu = c }).ToList();
                                    }
                                    break;
                                case 1:
                                    using (session)
                                    {
                                        IList<DateTime> prodInfo = session.QueryOver<Paragony>()
                                            .Select(c => c.DataZakupu)
                                            .List<DateTime>();

                                        dataGridView1.DataSource = prodInfo.Select(c => new { DataZakupu = c }).ToList();
                                    }
                                    break;
                                case 2:
                                    using (session)
                                    {
                                        IList<string> prodInfo = session.QueryOver<Paragony>()
                                            .Select(c => c.IDKlienta)
                                            .List<string>();

                                        dataGridView1.DataSource = prodInfo.Select(c => new { IDKlienta = c }).ToList();
                                    }
                                    break;
                                case 3:
                                    using (session)
                                    {
                                        IList<string> prodInfo = session.QueryOver<Paragony>()
                                            .Select(c => c.KwotaCalkowita)
                                            .List<string>();

                                        dataGridView1.DataSource = prodInfo.Select(c => new { KwotaCalkowita = c }).ToList();
                                    }
                                    break;
                            }
                            break;
                        case "Zakupy":
                            switch (column.SelectedIndex)
                            {
                                case 0:
                                    using (session)
                                    {
                                        IList<string> prodInfo = session.QueryOver<Zakupy>()
                                            .Select(c => c.IDZakupu)
                                            .List<string>();

                                        dataGridView1.DataSource = prodInfo.Select(c => new { IDZakupu = c }).ToList();
                                    }
                                    break;
                                case 1:
                                    using (session)
                                    {
                                        IList<string> prodInfo = session.QueryOver<Zakupy>()
                                            .Select(c => c.IDDokumentu)
                                            .List<string>();

                                        dataGridView1.DataSource = prodInfo.Select(c => new { IDDokumentu = c }).ToList();
                                    }
                                    break;
                                case 2:
                                    using (session)
                                    {
                                        IList<string> prodInfo = session.QueryOver<Zakupy>()
                                            .Select(c => c.IDProduktu)
                                            .List<string>();

                                        dataGridView1.DataSource = prodInfo.Select(c => new { IDProduktu = c }).ToList();
                                    }
                                    break;
                                case 3:
                                    using (session)
                                    {
                                        IList<string> prodInfo = session.QueryOver<Zakupy>()
                                            .Select(c => c.Ilosc)
                                            .List<string>();

                                        dataGridView1.DataSource = prodInfo.Select(c => new { Ilosc = c }).ToList();
                                    }
                                    break;
                                case 4:
                                    using (session)
                                    {
                                        IList<string> prodInfo = session.QueryOver<Zakupy>()
                                            .Select(c => c.CenaZakupu)
                                            .List<string>();

                                        dataGridView1.DataSource = prodInfo.Select(c => new { CenaZakupu = c }).ToList();
                                    }
                                    break;
                            }
                            break;
                    }
                }
            else if (position.Checked)
                {
                    string searchParameter = textBox.Text.ToString();

                    ISession session = sessionFactor.OpenSession();
                    switch(search.Text.ToString())
                {
                        case "Klienci":
                            switch(column.SelectedIndex)
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
                            switch(column.SelectedIndex)
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
                            switch(column.SelectedIndex)
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
                            switch(column.SelectedIndex)
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
        private void button1_Click(object sender, EventArgs e)
        {

            bool unlockedSeg2 = false, unlockedSeg3 = false, unlockedSeg4 = false, unlockedSeg5 = false;
                
            if (segment2_nextButton.Enabled) unlockedSeg2 = true;
            if (segment3_nextButton.Enabled) unlockedSeg3 = true;
            if (segment4_nextButton.Enabled) unlockedSeg4 = true;
            if (segment5_nextButton.Enabled) unlockedSeg5 = true;

            segmentInfoGet(segment1_search, segment1_column, segment1_textBox, segment1_position, segment1_all);
        }
    }
}
