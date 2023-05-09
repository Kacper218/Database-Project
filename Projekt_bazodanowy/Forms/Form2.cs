﻿using NHibernate;
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

            idKlienta_textBox.Enabled = false;
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

            //-------------------------------//

            segment2_search.Enabled = false;
            segment3_search.Enabled = false;
            segment4_search.Enabled = false;
            segment5_search.Enabled = false;

            segment2_column.Enabled = false;
            segment3_all.Enabled = false;
            segment4_column.Enabled = false;
            segment5_column.Enabled = false;

            segment2_textBox.Enabled = false;
            segment3_textBox.Enabled = false;
            segment4_textBox.Enabled = false;
            segment5_textBox.Enabled = false;

            segment2_position.Enabled = false;
            segment3_position.Enabled = false;
            segment4_position.Enabled = false;
            segment5_position.Enabled = false;

            segment2_all.Enabled = false;
            segment3_column.Enabled = false;
            segment4_all.Enabled = false;
            segment5_all.Enabled = false;

            segment2_nextButton.Enabled = false;
            segment3_nextButton.Enabled = false;
            segment4_nextButton.Enabled = false;
            segment5_nextButton.Enabled = false;
            segment5_nextButton.Hide();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
