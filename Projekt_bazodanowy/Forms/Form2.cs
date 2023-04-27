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
                //var product = new Product { Name = "Tea23", Units = 15, Price = 86.5 };
                try
                {
                    /*
                    var klient = new Klienci();
                    klient.ImieNazwisko = "Karol";
                    klient.Email = "karol@mail";
                    */

                    //var paragon = new Paragony {IDDokumentu="fw/asdf", DataZakupu = DateTime.Now ,IDKlienta = 1, KwotaCalkowita = 80.5};
                    var paragon = new Paragony();
                    paragon.IDDokumentu = "fw/asddfd";
                    paragon.DataZakupu = DateTime.Now;
                    paragon.IDKlienta = 1;
                    paragon.KwotaCalkowita = 80.5;

                    session.Save(paragon);
                    session.Flush();

                    session.Clear();
                } catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
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
    }
}
