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
        private void loadButton_Click(object sender, EventArgs e)
        {
            ISession session = sessionFactor.OpenSession();

            try { 
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
            } catch (Exception ex)
            {
                    MessageBox.Show("Wystapił nastepujący błąd: \n" + ex.ToString(),"Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Wystapił nastepujący błąd: \n" + ex.ToString(),"Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
