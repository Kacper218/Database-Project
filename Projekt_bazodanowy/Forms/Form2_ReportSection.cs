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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using NHibernate.Linq.Functions;

namespace Projekt_bazodanowy
{

    public enum Period
    {
        Day,
        Week,
        Month,
        Year
    }


    public partial class Form2 : Form
    {
        private void checkBoxesChanged(object sender, EventArgs e)
        {
            var clickedCheckbox = (CheckBox)sender;

            if (clickedCheckbox.Name != dayReport_checkBox.Name)
            {
                dayReport_checkBox.Checked = false;
            }

            if (clickedCheckbox.Name != weekReport_checkBox.Name)
            {
                weekReport_checkBox.Checked = false;
            }

            if (clickedCheckbox.Name != monthReport_checkBox.Name)
            {
                monthReport_checkBox.Checked = false;
            }
            if (clickedCheckbox.Name != yearReport_checkBox.Name)
            {
                yearReport_checkBox.Checked = false;
            }
        }

        private Period whichPeriod()
        {
            Period selectedPeriod = Period.Week;

            if (dayReport_checkBox.Checked) selectedPeriod = Period.Day;
            else if (weekReport_checkBox.Checked) selectedPeriod = Period.Week;
            else if (monthReport_checkBox.Checked) selectedPeriod = Period.Month;
            else if (yearReport_checkBox.Checked) selectedPeriod = Period.Year;

            return selectedPeriod;
        }

        private string getFolderPath()
        {
            string path="";
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    return fbd.SelectedPath;
                }
            }
            return path;
        }

        public void GeneratePdfReport(List<Paragony> filteredParagony, Dictionary<int, int> productSales, ISession session)
        {
            // Create the document and specify the file path
            Document document = new Document();
            string pathToSave = getFolderPath();
            if (pathToSave == "") throw new Exception("Nie podano ścieżki do folderu");
            string filePath = pathToSave + "\\sales_report_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".pdf";
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

            // Open the document for writing
            document.Open();

            // Add a title to the report
            Paragraph title = new Paragraph("Sales Report");
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            // Add the filtered paragony data to the report
            foreach (var paragon in filteredParagony)
            {
                Paragraph paragonData = new Paragraph($"Paragon ID: {paragon.IDDokumentu}, Date: {paragon.DataZakupu}, Customer ID: {paragon.IDKlienta}, Total Amount: {paragon.KwotaCalkowita}");
                document.Add(paragonData);
            }

            // Add the top selling products data to the report
            foreach (var kv in productSales)
            {
                int productId = kv.Key;
                int quantitySold = kv.Value;

                // Retrieve the product name from the database using the productId
                var product = session.Get<Produkty>(productId.ToString());
                string productName = product?.Nazwa;

                Paragraph productData = new Paragraph($"Product: {productName}, Quantity Sold: {quantitySold}");
                document.Add(productData);
            }

            // Close the document
            document.Close();
        }

        private void report_button_Click(object sender, EventArgs e)
        {
            DateTime selectedDate;
            selectedDate = report_dateTimePicker.Value;
            DateTime startDate = DateTime.UtcNow, endDate = DateTime.UtcNow;
            ISession session = sessionFactor.OpenSession();
            // Retrieve sales data from the database
            var paragony = session.Query<Paragony>().ToList();
            var zakupy = session.Query<Zakupy>().ToList();


            Period selectedPeriod = whichPeriod();

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
                    //filteredParagony = paragony.Where(p => p.DataZakupu.Year == selectedDate.Year).ToList();
                    break;
                case Period.Year:
                    filteredParagony = paragony.Where(p => p.DataZakupu.Year == selectedDate.Year).ToList();
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

            try { 
                GeneratePdfReport(filteredParagony, productSales,session);
            } catch (Exception ex) { 
                MessageBox.Show("Wystapil bład:\n" + ex.Message,"Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
