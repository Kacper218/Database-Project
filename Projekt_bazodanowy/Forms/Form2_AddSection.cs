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
                switch (add_comboBox.Text.ToString())
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
                    switch (add_comboBox.Text.ToString())
                    {
                        case "Klienci":
                            using (session)
                            {
                                var klient = new Klienci();
                                if(field3_textBox.Text.ToString() == "")
                                {
                                    klient.ImieNazwisko = field2_textBox.Text.ToString();
                                    klient.NazwaFirmy = "";
                                }
                                if(field2_textBox.Text.ToString() == "")
                                {

                                    klient.ImieNazwisko = "";
                                    klient.NazwaFirmy = field3_textBox.Text.ToString();
                                }
                                klient.Email = field4_textBox.Text.ToString();
                                session.Save(klient);
                                session.Flush();
                                session.Clear();
                                break;
                            }
                        case "Produkty":
                            using (session)
                            {
                                var produkt = new Produkty();
                                produkt.Nazwa = field2_textBox.Text.ToString();
                                produkt.CenaAktualna = field3_textBox.Text.ToString();
                                produkt.Dostepnosc = field4_textBox.Text.ToString();
                                session.Save(produkt);
                                session.Flush();
                                session.Clear();
                                break;
                            }
                        case "Paragony":
                            using (session)
                            {
                                var paragon = new Paragony();
                                paragon.IDDokumentu = field1_textBox.Text.ToString();
                                paragon.DataZakupu = DateTime.Parse(field2_textBox.Text.ToString());
                                paragon.IDKlienta = field3_textBox.Text.ToString();
                                paragon.KwotaCalkowita = field4_textBox.Text.ToString();
                                session.Save(paragon);
                                session.Flush();
                                session.Clear();
                                break;
                            }
                        case "Zakupy":
                            using (session)
                            {
                                var zakup = new Zakupy();
                                zakup.IDDokumentu = field2_textBox.Text.ToString();
                                zakup.IDProduktu = field3_textBox.Text.ToString();
                                zakup.Ilosc = field4_textBox.Text.ToString();
                                zakup.CenaZakupu = field5_textBox.Text.ToString();
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
            field1_textBox.Clear();
            field2_textBox.Clear();
            field3_textBox.Clear();
            field4_textBox.Clear();
            field5_textBox.Clear();
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            switch (add_comboBox.Text.ToString())
            {
                case "Klienci":
                    field1_textBox.Enabled = false;
                    field5_textBox.Enabled = false;
                    resetTextBoxes(sender);
                    break;
                case "Produkty":
                    field1_textBox.Enabled = false;
                    field5_textBox.Enabled = false;
                    resetTextBoxes(sender);
                    break;
                case "Paragony":
                    field1_textBox.Enabled = true;
                    field5_textBox.Enabled = false;
                    resetTextBoxes(sender);
                    break;
                case "Zakupy":
                    field1_textBox.Enabled = false;
                    field5_textBox.Enabled = true;
                    resetTextBoxes(sender);
                    break;
            }

        }
    }
}
