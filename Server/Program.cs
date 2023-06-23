using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

        private static void Server_DataReceived(object sender, Message e)
        {

            string request = e.MessageString;
            string[] messageParts = request.Split(':');
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
                        string queryName = messageParts[1];
                        switch(queryName)
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
                }
            }
        }
    }
}
