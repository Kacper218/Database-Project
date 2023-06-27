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
using NHibernate.Mapping;

namespace Projekt_bazodanowy
{
    public partial class Form2 : Form
    {
        // Event handler for when any checkbox is clicked
        private void checkBoxesChanged(object sender, EventArgs e)
        {
            // Uncheck other checkboxes when a checkbox is clicked
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

        // Determine the selected period based on the checked checkbox
        private string whichPeriod()
        {
            string selectedPeriod = "Week";

            if (dayReport_checkBox.Checked) selectedPeriod = "Day";
            else if (weekReport_checkBox.Checked) selectedPeriod = "Week";
            else if (monthReport_checkBox.Checked) selectedPeriod = "Month";
            else if (yearReport_checkBox.Checked) selectedPeriod = "Year";

            return selectedPeriod;
        }

        // Open a folder browser dialog and return the selected folder path
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

        // Generate raport to pdf file
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

            // Add spacing after the title
            title.SpacingAfter = 10f; // Adjust the spacing value as needed
            document.Add(title);

            // Add the filtered paragony data to the report
            PdfPTable paragonTable = new PdfPTable(4); // Number of columns in the table
            paragonTable.WidthPercentage = 100;

            // Add table headers
            paragonTable.AddCell("Paragon ID");
            paragonTable.AddCell("Date");
            paragonTable.AddCell("Customer ID");
            paragonTable.AddCell("Total Amount");

            // Add table data
            foreach (var paragon in filteredParagony)
            {
                paragonTable.AddCell(paragon.IDDokumentu.ToString());
                paragonTable.AddCell(paragon.DataZakupu.ToString());
                paragonTable.AddCell(paragon.IDKlienta.ToString());
                paragonTable.AddCell(paragon.KwotaCalkowita.ToString());
            }

            document.Add(paragonTable);

            // Add a title to the report
            Paragraph Salestitle = new Paragraph("Best selling products");
            Salestitle.Alignment = Element.ALIGN_CENTER;
            // Add spacing after the title
            Salestitle.SpacingBefore = 10f; // Adjust the spacing value as needed
            // Add spacing after the title
            Salestitle.SpacingAfter = 10f; // Adjust the spacing value as needed
            document.Add(Salestitle);

            // Add the top selling products data to the report
            PdfPTable productTable = new PdfPTable(2); // Number of columns in the table
            productTable.WidthPercentage = 100;

            // Add table headers
            productTable.AddCell("Product");
            productTable.AddCell("Quantity Sold");

            var sortedDict = from entry in productSales orderby entry.Value descending select entry;

            // Add table data
            foreach (var kv in sortedDict)
            {
                int productId = kv.Key;
                int quantitySold = kv.Value;

                // Retrieve the product name from the database using the productId
                var product = session.Get<Produkty>(productId.ToString());
                string productName = product?.Nazwa;

                productTable.AddCell(productName);
                productTable.AddCell(quantitySold.ToString());
            }

            document.Add(productTable);

            // Close the document
            document.Close();
        }


        // Handle click event on report button
        private void report_button_Click(object sender, EventArgs e)
        {
            DateTime selectedDate;
            selectedDate = report_dateTimePicker.Value;
            DateTime startDate = DateTime.UtcNow, endDate = DateTime.UtcNow;

            string pathToSave = getFolderPath();
            string selectedPeriod = "REPORT;" + whichPeriod() + ";" + selectedDate.ToString("yyyy-MM-ddTHH:mm:ss") + ";" + pathToSave + ";";
            connection.WriteLineAndGetReply(selectedPeriod, TimeSpan.FromSeconds(2));
        }
    }
}
