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
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using Projekt_bazodanowy.Models;

namespace Projekt_bazodanowy
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public ISessionFactory sessionFactor;

        public Form1()
        {
            InitializeComponent();
            instance = this;
            instance.CenterToScreen();
        }

        public void connectToDataSource(string connStr)
        {
            var config = new Configuration();
            config.DataBaseIntegration(d =>
            {
                d.ConnectionString = connStr;
                d.Dialect<MsSql2012Dialect>();
                d.Driver<SqlClientDriver>();
            });
            config.AddAssembly(Assembly.GetExecutingAssembly());

            var session= config.BuildSessionFactory();
            sessionFactor = session;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string user = loginTextBox.Text.ToString();
                string password = passwordTextBox.Text.ToString();
                if(string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
                {
                    throw new Exception("Nie podano loginu lub hasla!");
                }
                // change databaseName to yours data base name
                string databaseName = "DESKTOP-9QOBELFasd\\SQLEXPRESS";

                string connStr = "Data Source=" + databaseName + "; Initial Catalog=master; User Id=" + user + "; Password=" + password;

                connectToDataSource(connStr);
                Form2 form2 = new Form2(sessionFactor);
                this.Hide();
                form2.Show();
                form2.BringToFront();

            } catch (Exception ex) { 
                MessageBox.Show("Wystapił nastepujący błąd: \n" + ex.Message,"Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            passwordTextBox.PasswordChar = '*';
        }
        private void loginTextBox_Click(object sender, EventArgs e)
        {
            loginTextBox.Clear();
        }

        private void passwordTextBox_Click(object sender, EventArgs e)
        {
            passwordTextBox.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
