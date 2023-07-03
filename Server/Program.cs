using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using Server.Models;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;

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
        public static byte[] GeneratePdfReport(List<Paragony> filteredParagony, Dictionary<int, int> productSales)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                // Create the document and specify the file path
                Document document = new Document();
                //string pathToSave = getFolderPath();
                //if (pathToSave == "") throw new Exception("Nie podano ścieżki do folderu");
                //string filePath = pathToSave + "\\sales_report_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".pdf";
                PdfWriter writer = PdfWriter.GetInstance(document, stream);
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

                byte[] bytesToReturn = stream.ToArray();
                return bytesToReturn;
            }
        }
        private static void Server_DataReceived(object sender, Message e)
        {
            string request = e.MessageString;
            string[] messageParts = request.Split(';');
            string command = messageParts[0];

            if (!isClientLoggedIn || command == "connect")
            {
                if (AuthenticateUser(request))
                {
                    isClientLoggedIn = true;
                    e.Reply("LOGIN_SUCCES");
                    Console.WriteLine("Klient został pomyślnie zalogowany");
                }
                else
                {
                    e.Reply("LOGIN_FAILED");
                    Console.WriteLine("Klient nie został zalogowany");
                }
            }
            else
            {
                ISession session = sessionFactor.OpenSession();
                switch (command)
                {
                    case "SIMPLE_SEARCH":
                        string queryNameSimpleSearch = messageParts[1];
                        switch (queryNameSimpleSearch)
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
                        try
                        {
                            switch (queryNameAdd)
                            {
                                case "Clients":
                                    Console.WriteLine("Otrzymalem zgłoszenie dodania nowej pozycji do tabeli Klienci.");
                                    using (session)
                                    {
                                        var klient = new Klienci();
                                        if (messageParts[2] == "Individual")
                                        {
                                            klient.ImieNazwisko = messageParts[3];
                                        }
                                        else if (messageParts[2] == "Company")
                                        {
                                            klient.NazwaFirmy = messageParts[3];
                                        }
                                        klient.Email = messageParts[4];
                                        session.Save(klient);
                                        session.Flush();
                                        session.Clear();
                                    }
                                    Console.WriteLine("Dodałem pozycje.");
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
                                    Console.WriteLine("Dodałem pozycje.");
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
                                        Console.WriteLine("Dodałem pozycje.");
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
                                    Console.WriteLine("Dodałem pozycje.");
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            string errorToReply = "ERROR;Dodawanie" + ex.Message + ";";
                            e.Reply(errorToReply);
                            Console.WriteLine("Nie udalo sie wygererować raportu: " + ex.ToString());
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

                        try
                        {

                            // Check for the case of an empty report
                            int numberOfReceipts = filteredParagony.Count;
                            if (numberOfReceipts == 0)
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
                        catch (Exception ex)
                        {
                            string errorToReply = "ERROR;Generowanie raportu" + ex.Message + ";";
                            e.Reply(errorToReply);
                            Console.WriteLine("Nie udalo sie wygererować raportu: " + ex.ToString());
                        }
                        break;

                    case "SEARCH":
                        Console.WriteLine("Otrzymalem zgłoszenie wyszukiwania.");

                        switch (messageParts[1])
                        {
                            case "Clients":
                                var query = session.QueryOver<Klienci>();

                                if (messageParts[2] != "-")
                                {
                                    query = query.Where(c => c.IDKlienta == messageParts[2]);
                                }
                                if (messageParts[3] != "-")
                                {
                                    query = query.WhereRestrictionOn(c => c.NazwaFirmy).IsInsensitiveLike("%" + messageParts[3] + "%");
                                }
                                if (messageParts[4] != "-")
                                {
                                    query = query.WhereRestrictionOn(c => c.ImieNazwisko).IsInsensitiveLike("%" + messageParts[4] + "%");
                                }
                                if (messageParts[5] != "-")
                                {
                                    query = query.WhereRestrictionOn(c => c.Email).IsInsensitiveLike("%" + messageParts[5] + "%");
                                }

                                var result = query.List();
                                var ClientsBindingList = new BindingList<Klienci>(result);

                                string clientsJson = JsonConvert.SerializeObject(ClientsBindingList);
                                string clientsMessageToReply = "SEARCH" + ";" + "Clients" + ";" + clientsJson;
                                e.Reply(clientsMessageToReply);
                                Console.WriteLine("Odeslalem wynik wyszukiwania dla tabeli Klienci");

                                break;

                            case "Products":
                                var query2 = session.QueryOver<Produkty>();
                                // Perform search based on provided criteria
                                if (messageParts[2] != "-")
                                {
                                    query2 = query2.Where(c => c.IDProduktu == messageParts[2]);
                                }
                                if (messageParts[3] != "-")
                                {
                                    query2 = query2.WhereRestrictionOn(c => c.Nazwa).IsInsensitiveLike("%" + messageParts[3] + "%");
                                }
                                if (messageParts[4] != "-")
                                {
                                    query2 = query2.Where(c => c.CenaAktualna == messageParts[4]);
                                }
                                if (messageParts[5] != "-")
                                {
                                    query2 = query2.WhereRestrictionOn(c => c.Dostepnosc).IsInsensitiveLike("%" + messageParts[5] + "%");
                                }

                                var result2 = query2.List();
                                var ProductsBindingList = new BindingList<Produkty>(result2);
                                string productJson = JsonConvert.SerializeObject(ProductsBindingList);
                                string productsMessageToReply = "SEARCH" + ";" + "Products" + ";" + productJson;
                                e.Reply(productsMessageToReply);
                                Console.WriteLine("Odeslalem wynik wyszukiwania dla tabeli Produkty");
                                break;

                            case "Purchase":
                                var query3 = session.QueryOver<Zakupy>();
                                // Perform search based on provided criteria

                                if (messageParts[2] != "-")
                                {
                                    query3 = query3.Where(c => c.IDZakupu == messageParts[2]);
                                }

                                if (messageParts[3] != "-")
                                {
                                    query3 = query3.Where(c => c.IDDokumentu == messageParts[3]);
                                }

                                if (messageParts[4] != "-")
                                {
                                    query3 = query3.Where(c => c.IDProduktu == messageParts[4]);
                                }

                                if (messageParts[5] != "-")
                                {
                                    query3 = query3.Where(c => c.Ilosc == messageParts[5]);
                                }

                                if (messageParts[6] != "-")
                                {
                                    query3 = query3.Where(c => c.CenaZakupu == messageParts[6]);
                                }
                                var result3 = query3.List();
                                var purchaseBindingList = new BindingList<Zakupy>(result3);
                                string purchaseJson = JsonConvert.SerializeObject(purchaseBindingList);
                                string purchaseMessageToReply = "SEARCH" + ";" + "Purchase" + ";" + purchaseJson;
                                e.Reply(purchaseMessageToReply);

                                Console.WriteLine("Odeslalem wynik wyszukiwania dla tabeli Zakupy");
                                break;

                            case "Receipts":
                                var query4 = session.QueryOver<Paragony>();
                                // Perform search based on provided criteria
                                if (messageParts[2] != "-")
                                {
                                    query4 = query4.Where(c => c.IDDokumentu == messageParts[2]);
                                }
                                if (messageParts[3] != "-")
                                {
                                    DateTime dataZakupu;
                                    if (DateTime.TryParse(messageParts[3], out dataZakupu))
                                    {
                                        query4 = query4.Where(c => c.DataZakupu == dataZakupu);
                                    }
                                }
                                if (messageParts[4] != "-")
                                {
                                    query4 = query4.Where(c => c.IDKlienta == messageParts[4]);
                                }
                                if (messageParts[5] != "-")
                                {
                                    query4 = query4.Where(c => c.KwotaCalkowita == messageParts[5]);
                                }
                                var result4 = query4.List();
                                var receiptsBindingList = new BindingList<Paragony>(result4);
                                string receiptsJson = JsonConvert.SerializeObject(receiptsBindingList);
                                string receiptsMessageToReply = "SEARCH" + ";" + "Receipts" + ";" + receiptsJson;
                                e.Reply(receiptsMessageToReply);

                                Console.WriteLine("Odeslalem wynik wyszukiwania dla tabeli Paragony");
                                break;
                        }
                        break;

                    case "DELETE":
                        try
                        {
                            string queryNameDelete = messageParts[1];
                            switch (queryNameDelete)
                            {
                                case "Clients":
                                    using (session)
                                    {

                                        Klienci rowToDelete = session.Get<Klienci>(messageParts[2]);

                                        // Check if the primary key is referenced in another table
                                        bool isReferenced = session.QueryOver<Paragony>()
                                            .Where(re => re.IDKlienta == messageParts[2])
                                            .RowCount() > 0;

                                        if (isReferenced)
                                        {
                                            throw new Exception("Nie można usunąć wiersza używanego przez inne tabele.");
                                        }

                                        if (rowToDelete != null)
                                        {
                                            using (var transaction = session.BeginTransaction())
                                            {
                                                session.Delete(rowToDelete);
                                                transaction.Commit();
                                            }
                                        }

                                        string clientsDeletedInfo = "DELETE;SUCCES;";
                                        e.Reply(clientsDeletedInfo);
                                    }
                                    break;
                                case "Receipts":
                                    using (session)
                                    {
                                        Paragony rowToDelete2 = session.Get<Paragony>(messageParts[2]);

                                        // Check if the primary key is referenced in another table
                                        bool isReferenced2 = session.QueryOver<Zakupy>()
                                            .Where(re => re.IDDokumentu == messageParts[2])
                                            .RowCount() > 0;

                                        if (isReferenced2)
                                        {
                                            throw new Exception("Nie można usunąć wiersza używanego przez inne tabele.");
                                        }

                                        if (rowToDelete2 != null)
                                        {
                                            using (var transaction = session.BeginTransaction())
                                            {
                                                session.Delete(rowToDelete2);
                                                transaction.Commit();
                                            }
                                        }

                                        string productsDeletedInfo = "DELETE;SUCCES;";
                                        e.Reply(productsDeletedInfo);

                                    }
                                    break;
                                case "Purchase":
                                    using (session)
                                    {

                                        session.BeginTransaction();

                                        Zakupy rowToDelete3 = session.Get<Zakupy>(messageParts[2]);

                                        string deleteQuery = "DELETE FROM Zakupy WHERE IDZakupu = :id";
                                        var query = session.CreateQuery(deleteQuery);
                                        query.SetParameter("id", messageParts[2]);
                                        // Execute the delete query
                                        int deletedCount = query.ExecuteUpdate();

                                        if (deletedCount > 0)
                                        {
                                            // Commit the transaction
                                            session.Transaction.Commit();
                                        }
                                        else
                                        {
                                            // Rollback the transaction
                                            session.Transaction.Rollback();
                                        }

                                        string purchaseDeletedInfo = "DELETE;SUCCES;";
                                        e.Reply(purchaseDeletedInfo);
                                    }
                                    break;
                                case "Products":
                                    using (session)
                                    {
                                        Produkty rowToDelete4 = session.Get<Produkty>(messageParts[2]);

                                        // Check if the primary key is referenced in another table
                                        bool isReferenced4 = session.QueryOver<Zakupy>()
                                            .Where(re => re.IDProduktu == messageParts[2])
                                            .RowCount() > 0;

                                        if (isReferenced4)
                                        {
                                            throw new Exception("Nie można usunąć wiersza używanego przez inne tabele.");
                                        }

                                        if (rowToDelete4 != null)
                                        {
                                            using (var transaction = session.BeginTransaction())
                                            {
                                                session.Delete(rowToDelete4);
                                                transaction.Commit();
                                            }
                                        }
                                        string receiptsDeletedInfo = "DELETE;SUCCES;";
                                        e.Reply(receiptsDeletedInfo);

                                    }
                                    break;

                            }
                            break;
                        }
                        catch (Exception ex)
                        {
                            string errorToReply = "ERROR;Usuwanie pozycji " + ex.Message + ";";
                            e.Reply(errorToReply);
                            Console.WriteLine("Nie udalo sie usunać pozycji: " + ex.ToString());
                        }
                        break;

                    case "DETAILS":
                        string queryNameDetails = messageParts[1];
                        switch (queryNameDetails)
                        {
                            case "Clients":
                                break;
                            case "Receipts":
                                break;
                        }
                        break;

                    case "GETPRODUCTS":
                        using (session)
                        {
                            var products = session.Query<Produkty>().ToList();
                            string productsJson = JsonConvert.SerializeObject(products);
                            string productsToReply = "GETPRODUCTS;" + productsJson + ";";
                            e.Reply(productsToReply);
                        }
                        break;
                }
            }
        }
    }
}
