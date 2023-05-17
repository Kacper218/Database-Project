using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
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

    public enum Period
    {
        Day,
        Week,
        Month
    }
    public partial class Form2 : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime selectedDate;
            selectedDate = report_dateTimePicker.Value;
            Period selectedPeriod = Period.Day;
            DateTime startDate = DateTime.UtcNow, endDate = DateTime.UtcNow;
            ISession session = sessionFactor.OpenSession();
            // Retrieve sales data from the database
            var paragony = session.Query<Paragony>().ToList();
            var zakupy = session.Query<Zakupy>().ToList();

            // Process sales for the selected period
            List<Paragony> filteredParagony;
            switch (selectedPeriod)
            {
                case Period.Day:
                    filteredParagony = paragony.Where(p => p.DataZakupu.Date == selectedDate.Date).ToList();
                    break;
                case Period.Week:
                    var startDateOfWeek = selectedDate.AddDays(-(int)selectedDate.DayOfWeek);
                    var endDateOfWeek = startDateOfWeek.AddDays(6);
                    filteredParagony = paragony.Where(p => p.DataZakupu.Date >= startDateOfWeek.Date && p.DataZakupu.Date <= endDateOfWeek.Date).ToList();
                    break;
                case Period.Month:
                    filteredParagony = paragony.Where(p => p.DataZakupu.Month == selectedDate.Month && p.DataZakupu.Year == selectedDate.Year).ToList();
                    break;
                default:
                    filteredParagony = paragony;
                    break;
            }

            // Generate sales report
            int numberOfReceipts = filteredParagony.Count;

            var productSales = new Dictionary<int, int>(); // ProductID -> TotalQuantitySold
            foreach (var paragon in filteredParagony)
            {
                foreach (var zakup in zakupy)
                {
                    if (zakup.IDDokumentu == paragon.IDDokumentu)
                    {
                        if (productSales.ContainsKey(int.Parse(zakup.IDProduktu)))
                        {
                            productSales[int.Parse(zakup.IDProduktu)] += int.Parse(zakup.Ilosc);
                        }
                        else
                        {
                            productSales[int.Parse(zakup.IDProduktu)] = int.Parse(zakup.Ilosc);
                        }
                    }
                }
            }

            var topSellingProducts = productSales.OrderByDescending(kv => kv.Value).Take(3).ToList();

            dataGridView1.DataSource = productSales;
        }
    }
}
