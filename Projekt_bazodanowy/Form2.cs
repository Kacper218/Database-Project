using NHibernate;
using NHibernate.Cfg;
using Projekt_bazodanowy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void button1_Click(object sender, EventArgs e)
        {
            using (var session = sessionFactor.OpenSession())
            {
                var product = new Product { Name = "Tea23", Units = 15, Price = 86.5 };
                session.Save(product);

                session.Clear();
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
