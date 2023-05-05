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

        public static Form2 instance;
        public readonly ISessionFactory sessionFactor;
        public Form2(ISessionFactory sessionFactor)
        {
            InitializeComponent();
            instance = this;
            this.sessionFactor = sessionFactor;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            ISession session = sessionFactor.OpenSession();

            switch (comboBox1.Text.ToString())
            {
                case "Klienci":
                    using (session)
                    {
                        IQuery query = session.CreateQuery("FROM Klienci");
                        IList<Models.Klienci> prodInfo = query.List<Models.Klienci>();
                        dataGridView1.DataSource = prodInfo;
                        break;
                    }
                case "Produkty":
                    using (session)
                    {
                        IQuery query1 = session.CreateQuery("FROM Produkty");
                        IList<Models.Produkty> prodInfo1 = query1.List<Models.Produkty>();
                        dataGridView1.DataSource = prodInfo1;
                        break;
                    }
                case "Paragony":
                    using (session)
                    {
                        IQuery query2 = session.CreateQuery("FROM Paragony");
                        IList<Models.Paragony> prodInfo2 = query2.List<Models.Paragony>();
                        dataGridView1.DataSource = prodInfo2;
                        break;
                    }
                case "Zakupy":
                    using (session)
                    {
                        IQuery query3 = session.CreateQuery("FROM Zakupy");
                        IList<Models.Zakupy> prodInfo3 = query3.List<Models.Zakupy>();
                        dataGridView1.DataSource = prodInfo3;
                        break;
                    }
            }

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (var session = sessionFactor.OpenSession())
            {
                try
                {
                    switch (comboBox1.Text.ToString())
                    {
                        case "Klienci":
                            using (session)
                            {
                                var klient = new Klienci();
                                if(textBox3.Text.ToString() == "")
                                {
                                    klient.ImieNazwisko = textBox2.Text.ToString();
                                    klient.NazwaFirmy = "";
                                }
                                if(textBox2.Text.ToString() == "")
                                {

                                    klient.ImieNazwisko = "";
                                    klient.NazwaFirmy = textBox3.Text.ToString();
                                }
                                klient.Email = textBox4.Text.ToString();
                                session.Save(klient);
                                session.Flush();
                                session.Clear();
                                break;
                            }
                        case "Produkty":
                            using (session)
                            {
                                var produkt = new Produkty();
                                produkt.Nazwa = textBox2.Text.ToString();
                                produkt.CenaAktualna = textBox3.Text.ToString();
                                produkt.Dostepnosc = textBox4.Text.ToString();
                                session.Save(produkt);
                                session.Flush();
                                session.Clear();
                                break;
                            }
                        case "Paragony":
                            using (session)
                            {
                                var paragon = new Paragony();
                                paragon.IDDokumentu = textBox1.Text.ToString();
                                paragon.DataZakupu = DateTime.Parse(textBox2.Text.ToString());
                                paragon.IDKlienta = textBox3.Text.ToString();
                                paragon.KwotaCalkowita = textBox4.Text.ToString();
                                session.Save(paragon);
                                session.Flush();
                                session.Clear();
                                break;
                            }
                        case "Zakupy":
                            using (session)
                            {
                                var zakup = new Zakupy();
                                zakup.IDDokumentu = textBox2.Text.ToString();
                                zakup.IDProduktu = textBox3.Text.ToString();
                                zakup.Ilosc = textBox4.Text.ToString();
                                zakup.CenaZakupu = textBox5.Text.ToString();
                                session.Save(zakup);
                                session.Flush();
                                session.Clear();
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }
        
        private void resetTextBoxes(object sender)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            switch (comboBox1.Text.ToString())
            {
                case "Klienci":
                    textBox1.Enabled = false;
                    textBox5.Enabled = false;
                    resetTextBoxes(sender);
                    break;
                case "Produkty":
                    textBox1.Enabled = false;
                    textBox5.Enabled = false;
                    resetTextBoxes(sender);
                    break;
                case "Paragony":
                    textBox1.Enabled = true;
                    textBox5.Enabled = false;
                    resetTextBoxes(sender);
                    break;
                case "Zakupy":
                    textBox1.Enabled = false;
                    textBox5.Enabled = true;
                    resetTextBoxes(sender);
                    break;
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox2.Text.ToString())
            {
                case "Klienci":
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("ID Klienta");
                    comboBox3.Items.Add("Imie i Nazwisko");
                    comboBox3.Items.Add("Nazwa firmy");
                    comboBox3.Items.Add("Email");
                    break;
                case "Produkty":
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("ID produktu");
                    comboBox3.Items.Add("Nazwa produktu");
                    comboBox3.Items.Add("Aktualna cena produktu");
                    comboBox3.Items.Add("Dostępna ilość");
                    break;
                case "Paragony":
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("Nr paragonu/faktury");
                    comboBox3.Items.Add("Data zakupu");
                    comboBox3.Items.Add("ID Klienta");
                    comboBox3.Items.Add("Kwota całkowita");
                    break;
                case "Zakupy":
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("ID Zakupu");
                    comboBox3.Items.Add("Nr paragonu/faktury");
                    comboBox3.Items.Add("ID Produktu");
                    comboBox3.Items.Add("Zakupiona ilość");
                    comboBox3.Items.Add("Cena zakupu");
                    break;
            }
        }
        private void checkBox1_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
            {
                ISession session = sessionFactor.OpenSession();
                switch(comboBox2.Text.ToString())
                {
                    case "Klienci":
                        switch(comboBox3.SelectedIndex)
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
                        switch(comboBox3.SelectedIndex)
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
                        switch(comboBox3.SelectedIndex)
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
                        switch(comboBox3.SelectedIndex)
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
            else if(checkBox1.Checked)
            {
                string searchParameter = textBox11.Text.ToString();

                ISession session = sessionFactor.OpenSession();
                switch(comboBox2.Text.ToString())
                {
                    case "Klienci":
                        switch(comboBox3.SelectedIndex)
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
                        switch(comboBox3.SelectedIndex)
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
                        switch(comboBox3.SelectedIndex)
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
                        switch(comboBox3.SelectedIndex)
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
