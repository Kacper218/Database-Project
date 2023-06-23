using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using Projekt_bazodanowy.DataRepository;
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
        // Event handler for the loadButton click event
        private void loadButton_Click(object sender, EventArgs e)
        {
            // Open a session for database operations
            //ISession session = sessionFactor.OpenSession();
            dataGridView1.Columns.Clear(); // Clears existing columns in the DataGridView
            dataGridView1.DataSource = null; // Clears the data source of the DataGridView

            try
            {
                // Perform different actions based on the selected add option
                switch (add_comboBox.Text.ToString())
                {
                    case "Klienci":
                        string messege = "SIMPLE_SEARCH:Clients:";
                        connection.WriteLineAndGetReply(messege, TimeSpan.FromSeconds(3));
                        IList<Klienci> clientsInfo = ClientsJsonDataRepository.DataList;
                        dataGridView1.DataSource = clientsInfo;
                        break;
                    case "Produkty":
                        string messege2 = "SIMPLE_SEARCH:Products:";
                        connection.WriteLineAndGetReply(messege2, TimeSpan.FromSeconds(3));
                        IList<Produkty> productsInfo = ProductsJsonDataRepository.DataList;
                        dataGridView1.DataSource = productsInfo;
                        break;
                    case "Paragony":
                        string messege3 = "SIMPLE_SEARCH:Receipts:";
                        connection.WriteLineAndGetReply(messege3, TimeSpan.FromSeconds(3));
                        IList<Paragony> receiptsInfo = ReceiptsJsonDataRepository.DataList;
                        dataGridView1.DataSource = receiptsInfo;
                        break;
                    case "Zakupy":
                        string messege4 = "SIMPLE_SEARCH:Purchase:";
                        connection.WriteLineAndGetReply(messege4, TimeSpan.FromSeconds(3));
                        IList<Zakupy> purchaseInfo = PurchaseJsonDataRepository.DataList;
                        dataGridView1.DataSource = purchaseInfo;
                        break;
                }
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs during loading
                MessageBox.Show("Wystapił bład podczas wczytywania podglądu:\n" + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for the addButton click event
        private void addButton_Click(object sender, EventArgs e)
            {
                // Open a session for database operations
                using (var session = sessionFactor.OpenSession())
                {
                    try
                    {
                        // Perform diffrent actions based on the selected add option
                        switch (add_comboBox.Text.ToString())
                        {
                            case "Klienci":
                                using (session)
                                {
                                    var klient = new Klienci();

                                    // Check if both ImieNazwisko and NazwaFirmy fields are filled
                                    if (!(field2_textBox.Text.ToString() == "") && !(field3_textBox.Text.ToString() == ""))
                                    {
                                        throw new Exception("Uzupelniono za duzo pól: Imię Nazwisko oraz Nazwa Firmy");
                                    }

                                    // Check if either ImieNazwisko and NazwaFirmy fields are empty
                                    if ((field2_textBox.Text.ToString() == "") && (field3_textBox.Text.ToString() == ""))
                                    {
                                        throw new Exception("Nie podano wystarczającej ilości informacji.");
                                    }

                                    // Set fields based on user input
                                    if (field3_textBox.Text.ToString() == "")
                                    {
                                        klient.ImieNazwisko = field2_textBox.Text.ToString();
                                        klient.NazwaFirmy = "";
                                    }
                                    if (field2_textBox.Text.ToString() == "")
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
                                    // Set fields based on user input
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
                                    // Set fields based on user input
                                    paragon.IDDokumentu = field1_textBox.Text.ToString();
                                    // Parse user date input to correct DateTime format
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
                                    // Set fields based on user input
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

                    catch (FormatException)
                    {
                        MessageBox.Show("Podano zły format daty", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (NHibernate.Exceptions.GenericADOException)
                    {
                        MessageBox.Show("Nie podano wystarczającej ilości informacji", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Wystapił nastepujący błąd: \n" + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Reset textBoxes when comboBox changed
            private void resetTextBoxes(object sender)
            {
                field1_textBox.Clear();
                field2_textBox.Clear();
                field3_textBox.Clear();
                field4_textBox.Clear();
                field5_textBox.Clear();
            }

            // Handel TextUpdate for comboBox with table selection
            private void add_comboBox_TextUpdate(object sender, EventArgs e)
            {
                switch (add_comboBox.Text.ToString())
                {
                    case "Klienci":
                        field1_textBox.Enabled = false;
                        field5_textBox.Enabled = false;
                        field1_label.Text = "ID Klienta";
                        field2_label.Text = "Imie i nazwisko";
                        field3_label.Text = "Nazwa Firmy";
                        field4_label.Text = "Email";
                        field5_label.Text = "-";
                        resetTextBoxes(sender);
                        break;
                    case "Produkty":
                        field1_textBox.Enabled = false;
                        field5_textBox.Enabled = false;
                        field1_label.Text = "ID Produktu";
                        field2_label.Text = "Nazwa";
                        field3_label.Text = "Aktualna Cena";
                        field4_label.Text = "Dostępna ilość";
                        field5_label.Text = "-";
                        resetTextBoxes(sender);
                        break;
                    case "Paragony":
                        field1_textBox.Enabled = true;
                        field5_textBox.Enabled = false;
                        field1_label.Text = "ID Dokumentu";
                        field2_label.Text = "Data Zakupu";
                        field3_label.Text = "ID Klienta";
                        field4_label.Text = "Kwota całkowita";
                        field5_label.Text = "-";
                        resetTextBoxes(sender);
                        break;
                    case "Zakupy":
                        field1_textBox.Enabled = false;
                        field5_textBox.Enabled = true;
                        field1_label.Text = "ID Zakupu";
                        field2_label.Text = "ID Dokumentu";
                        field3_label.Text = "ID Produktu";
                        field4_label.Text = "Ilość";
                        field5_label.Text = "Cena zakupu";
                        resetTextBoxes(sender);
                        break;
                }

            }
        }
}
