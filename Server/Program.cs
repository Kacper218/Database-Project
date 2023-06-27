using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using Server.Models;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Server
{
    internal class Program
    {
        private static SimpleTcpServer server;
        private static bool isClientLoggedIn;
        public static ISessionFactory sessionFactor;
        static void Main(string[] args)
        {
            try
            {
                // Inicjalizacja serwera nasłuchującego na porcie 1234
                server = new SimpleTcpServer();
                server.StringEncoder = System.Text.Encoding.UTF8;
                server.DataReceived += Server_DataReceived;
                server.ClientConnected += Server_ClientConnected;
                server.ClientDisconnected += Server_ClientDisconnected;
                server.Start(1234);

                Console.WriteLine("Serwer nasłuchuje na porcie 1234...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd: " + ex.Message);
            }
            finally
            {
                // Zatrzymanie serwera
                server?.Stop();
            }
        }

        private static void Server_ClientDisconnected(object sender, TcpClient e)
        {
            isClientLoggedIn = false;
            Console.WriteLine("Klient nie jest połączony z serwerem");
        }
        private static void Server_ClientConnected(object sender, TcpClient e)
        {
            isClientLoggedIn = false;
            Console.WriteLine("Klient połączył się z serwerem");
        }

        private static bool AuthenticateUser(string credentials)
        {
            string[] loginParts = credentials.Split(':');
            string user = loginParts[1];
            string password = loginParts[2];

            Console.WriteLine($"Otrzymałem dane z próba zalogowania dla użytkownika: {user}");  
            try
            {
                var config = new Configuration();

                string databaseName = "DESKTOP-9QOBELF\\SQLEXPRESS";

                string connStr = "Data Source=" + databaseName + "; Initial Catalog=master; User Id=" + user + "; Password=" + password; 
                // Configure the database integration
                config.DataBaseIntegration(d =>
                {
                    d.ConnectionString = connStr;
                    d.Dialect<MsSql2012Dialect>();
                    d.Driver<SqlClientDriver>();
                });

                // Add the assembly
                config.AddAssembly(Assembly.GetExecutingAssembly());

                // Build the session factory
                var session = config.BuildSessionFactory();
                sessionFactor = session;

                return true;
                }
            catch (Exception ex)
            {
                // Display error message
                Console.WriteLine("Wystapił nastepujący błąd: \n" + ex.Message, "Błąd");
                return false;
            }
        }
        public static byte []GeneratePdfReport(List<Paragony> filteredParagony, Dictionary<int, int> productSales)
        {
            using (MemoryStream stream = new MemoryStream())
            {
            // Create the document and specify the file path
            Document document = new Document();
            //string pathToSave = getFolderPath();
            //if (pathToSave == "") throw new Exception("Nie podano ścieżki do folderu");
            //string filePath = pathToSave + "\\sales_report_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".pdf";
            PdfWriter writer = PdfWriter.GetInstance(document,stream);
            ISession session = sessionFactor.OpenSession();

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
                            if (paragon.KwotaCalkowita != null)
                            {
                                paragonTable.AddCell(paragon.KwotaCalkowita.ToString());
                            }
                            else
                            {
                                paragonTable.AddCell(string.Empty);
                            }
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

            byte[] bytesToReturn=stream.ToArray();
            return bytesToReturn;
            }
        }
        private static void Server_DataReceived(object sender, Message e)
        {
            string request = e.MessageString;
            string[] messageParts = request.Split(';');
            string command = messageParts[0];

            if(!isClientLoggedIn || command == "connect")
            {
                if(AuthenticateUser(request))
                {
                    isClientLoggedIn = true;
                    e.Reply("LOGIN_SUCCES");
                    Console.WriteLine("Klient został pomyślnie zalogowany");
                } else
                {
                    e.Reply("LOGIN_FAILED");
                    Console.WriteLine("Klient nie został zalogowany");
                }
            } else
            {
                ISession session = sessionFactor.OpenSession();
                switch(command)
                {
                    case "SIMPLE_SEARCH":
                        string queryNameSimpleSearch = messageParts[1];
                        switch(queryNameSimpleSearch)
                        {
                            case "Clients":
                                Console.WriteLine("Otrzymalem zgłoszenie szybkiego wyszukiwania tabeli Klienci.");
                                IQuery clientsQuery = session.CreateQuery("FROM Klienci");
                                IList<Models.Klienci> clientInfo = clientsQuery.List<Models.Klienci>();
                                string clientsJson = JsonConvert.SerializeObject(clientInfo);
                                string clientsMessageToReply = "SIMPLE_SEARCH" + ";" + "Clients" + ";" + clientsJson;
                                e.Reply(clientsMessageToReply);
                                Console.WriteLine("Odeslalem dane");
                                break;
                            case "Products":
                                Console.WriteLine("Otrzymalem zgłoszenie szybkiego wyszukiwania tabeli Produkty.");
                                IQuery productsQuery = session.CreateQuery("FROM Produkty");
                                IList<Models.Produkty> prodInfo = productsQuery.List<Models.Produkty>();
                                string productsJson = JsonConvert.SerializeObject(prodInfo);
                                string productsMessageToReply = "SIMPLE_SEARCH" + ";" + "Products" + ";" + productsJson;
                                e.Reply(productsMessageToReply);
                                Console.WriteLine("Odeslalem dane");
                                break;
                            case "Receipts":
                                Console.WriteLine("Otrzymalem zgłoszenie szybkiego wyszukiwania tabeli Paragony.");
                                IQuery receiptsQuery = session.CreateQuery("FROM Paragony");
                                IList<Models.Paragony> receiptsInfo = receiptsQuery.List<Models.Paragony>();
                                string receiptsJson = JsonConvert.SerializeObject(receiptsInfo);
                                string receiptsMessageToReply = "SIMPLE_SEARCH" + ";" + "Receipts" + ";" + receiptsJson;
                                e.Reply(receiptsMessageToReply);
                                Console.WriteLine("Odeslalem dane");
                                break;
                            case "Purchase":
                                Console.WriteLine("Otrzymalem zgłoszenie szybkiego wyszukiwania tabeli Zakupy.");
                                IQuery purchaseQuery = session.CreateQuery("FROM Zakupy");
                                IList<Models.Zakupy> purchaseInfo = purchaseQuery.List<Models.Zakupy>();
                                string purchaseJson = JsonConvert.SerializeObject(purchaseInfo);
                                string purchaseMessageToReply = "SIMPLE_SEARCH" + ";" + "Purchase" + ";" + purchaseJson;
                                e.Reply(purchaseMessageToReply);
                                Console.WriteLine("Odeslalem dane");
                                break;
                        }
                        break;

                    case "ADD":
                        string queryNameAdd = messageParts[1];
                        switch(queryNameAdd)
                        {
                            case "Clients":
                                Console.WriteLine("Otrzymalem zgłoszenie dodania nowej pozycji do tabeli Klienci.");
                                using (session)
                                {
                                    var klient = new Klienci();
                                    if (messageParts[2] == "Individual")
                                    {
                                        klient.ImieNazwisko = messageParts[3];
                                    } else if (messageParts[2] == "Company")
                                    {
                                        klient.NazwaFirmy = messageParts[3];
                                    }
                                    klient.Email = messageParts[4];
                                    session.Save(klient);
                                    session.Flush();
                                    session.Clear();
                                }
                                break;
                            case "Products":
                                Console.WriteLine("Otrzymalem zgłoszenie dodania nowej pozycji do tabeli Produkty.");
                                using (session)
                                {
                                    var produkt = new Produkty();
                                    produkt.Nazwa = messageParts[2];
                                    produkt.CenaAktualna = messageParts[3];
                                    produkt.Dostepnosc = messageParts[4];
                                    session.Save(produkt);
                                    session.Flush();
                                    session.Clear();
                                }
                                break;
                            case "Receipts":
                                Console.WriteLine("Otrzymalem zgłoszenie dodania nowej pozycji do tabeli Paragony.");
                                using (session)
                                {
                                    var paragon = new Paragony();
                                    paragon.IDDokumentu = messageParts[2];
                                    paragon.DataZakupu = DateTime.Parse(messageParts[3]);
                                    paragon.IDKlienta = messageParts[4];
                                    paragon.KwotaCalkowita = messageParts[5];
                                    session.Save(paragon);
                                    session.Flush();
                                    session.Clear();
                                }
                                break;
                            case "Purchase":
                                Console.WriteLine("Otrzymalem zgłoszenie dodania nowej pozycji do tabeli Zakupy.");
                                using (session)
                                {
                                    var zakup = new Zakupy();
                                    zakup.IDDokumentu = messageParts[2];
                                    zakup.IDProduktu = messageParts[3];
                                    zakup.Ilosc = messageParts[4];
                                    zakup.CenaZakupu = messageParts[5];
                                    session.Save(zakup);
                                    session.Flush();
                                    session.Clear();
                                }
                                break;
                        }
                        break;

                    case "REPORT":
                        Console.WriteLine("Otrzymalem zgłoszenie wygenerowania raportu ");
                        DateTime selectedDate;
                        DateTime startDate = DateTime.UtcNow, endDate = DateTime.UtcNow;
                        var paragony = session.Query<Paragony>().ToList();
                        var zakupy = session.Query<Zakupy>().ToList();
                        List<Paragony> filteredParagony;
                        selectedDate = DateTime.ParseExact(messageParts[2], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                        Console.WriteLine("Dla okresu: " + messageParts[1]);

                        switch (messageParts[1])
                        {
                            // Based on selected period filter Paragony table 
                            case "Day":
                                filteredParagony = paragony.Where(p => p.DataZakupu.Date == selectedDate.Date).OrderBy(p => p.DataZakupu).ToList();
                                break;
                            case "Week":
                                var startDateOfWeek = selectedDate.AddDays(-(int)selectedDate.DayOfWeek);
                                var endDateOfWeek = startDateOfWeek.AddDays(6);
                                filteredParagony = paragony.Where(p => p.DataZakupu.Date >= startDateOfWeek.Date && p.DataZakupu.Date <= endDateOfWeek.Date).OrderBy(p => p.DataZakupu).ToList();
                                break;
                            case "Month":
                                var startDateOfMonth = selectedDate.AddDays(-(int)selectedDate.DayOfWeek);
                                var endDateOfMonth = startDateOfMonth.AddDays(30);
                                filteredParagony = paragony.Where(p => p.DataZakupu.Date >= startDateOfMonth.Date && p.DataZakupu.Date <= endDateOfMonth.Date).OrderBy(p => p.DataZakupu).ToList();
                                break;
                            case "Year":
                                var startDateOfYear = selectedDate.AddDays(-(int)selectedDate.DayOfWeek);
                                var endDateOfYear = startDateOfYear.AddDays(365);
                                filteredParagony = paragony.Where(p => p.DataZakupu.Date >= startDateOfYear.Date && p.DataZakupu.Date <= endDateOfYear.Date).OrderBy(p => p.DataZakupu).ToList();
                                break;
                            default:
                                filteredParagony = paragony;
                                break;
                        }

                        try { 

                            // Check for the case of an empty report
                            int numberOfReceipts = filteredParagony.Count;
                            if(numberOfReceipts == 0)
                            {
                                throw new Exception("Raport z tego okresu nie posiada żadnych pozycji.");
                            }

                            Console.WriteLine("Zaczynam zbierać potrzebne informacje...");
                            // Prepare data for report genereting
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
                            // Generate sales report
                            Console.WriteLine("Zebrałem potrzebne informacje, generuje raport...");
                            byte[] reportBytes = GeneratePdfReport(filteredParagony, productSales);
                            string base64String = Convert.ToBase64String(reportBytes);

                            PdfReportDto reportDto = new PdfReportDto
                            {
                                Base64Data = base64String,
                            };

                            string filePath = messageParts[3] + "\\sales_report_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".pdf";

                            string json = "REPORT;" + filePath + ";" + JsonConvert.SerializeObject(reportDto) + ";";
                            e.Reply(json);
                            Console.WriteLine("Wysłałem odpowiedź.");

                        }
                        catch (Exception ex) {
                            string errorToReply = "ERROR;" + ex.Message + ";";
                            e.Reply(errorToReply);
                            Console.WriteLine("Nie udalo sie wygererować raportu: " + ex.ToString()) ;
                        }
                        break;
                }
            }
        }
    }
}
