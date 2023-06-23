using NHibernate;
using NHibernate.Cfg;
using Projekt_bazodanowy.Models;
using Remotion.Linq.Parsing.ExpressionVisitors.Transformation.PredefinedTransformations;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Sockets;
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
        private SimpleTcpClient connection;
        private static string json;
        public Form2(SimpleTcpClient connection)
        {
            InitializeComponent();
            instance = this;
            instance.CenterToScreen();
            this.connection = connection;
            this.sessionFactor = sessionFactor;
            this.Text = "Eksplorator Bazy Danych";

            dataGridView1.MultiSelect = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            add_comboBox.SelectedIndex = 0;
            search_comboBox.SelectedIndex = 0;

            idKlienta_textBox.Enabled = false;
            idZakupu_textBox.Enabled = false;
            idDokumentu_textBox.Enabled = false;
            idProduktu_textBox.Enabled = false;
            imieNazwisko_textBox.Enabled = false;
            nazwaFirmy_textBox.Enabled = false;
            email_textBox.Enabled = false;
            dataZakupu_textBox.Enabled = false;
            kwotaCalkowita_textBox.Enabled = false;
            nazwaProduktu_textBox.Enabled = false;
            aktualnaCena_textBox.Enabled = false;
            dostepnosc_textBox.Enabled = false;
            ilosc_textBox.Enabled = false;
            cenaZakupu_textBox.Enabled = false;

            dataGridView1.AutoResizeColumns();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

    }
}
