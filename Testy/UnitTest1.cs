using DodatkoweElementy;
using Projekt_bazodanowy;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;
using SimpleTCP;
using System.Windows.Forms;

namespace Testy
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestButtonConnectToServerPass()
        {
            var user = new DummyLogin();
            var presenter = new LoginInfoPresenter(user);

            user.portnum = 1234;
            Assert.That(actual: testConn(user, 1), Is.EqualTo(expected: "Po³¹czono z serwerem"));
        }

        [Test]
        public void TestButtonConnectToServerFail()
        {
            var user = new DummyLogin();
            var presenter = new LoginInfoPresenter(user);

            user.portnum = 12345;
            Assert.That(actual: testConn(user, 2), Is.EqualTo(expected: "Nieprawid³owy port"));
        }

        private string testConn(DummyLogin user, int type)
        {
            SimpleTcpClient tcpClient = new SimpleTcpClient();
            SimpleTcpServer tcpServer = new SimpleTcpServer();
            int serverPass = 1234;
            int serverFail = 1235;
            if (type == 1) tcpServer.Start(serverPass);
            else tcpServer.Start(serverFail);
            try
            {
                // Test connection with different values provided by user
                tcpClient.Connect("localhost", user.portnum);

                //loginTextBox.Enabled = true;
                //passwordTextBox.Enabled = true;
                //button1.Enabled = true;
                return "Po³¹czono z serwerem";
            }
            catch (Exception)
            {
                return "Nieprawid³owy port";
            }
        }
    }

    class DummyLogin : ILoginInfo
    {
        public int portnum { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public event EventHandler ConnectToServer;
        public event EventHandler ConnectToDatabase;
    }
}