using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodatkoweElementy
{
    public interface ILoginInfo
    {
        int portnum { get; set; }
        string Username { get; set; }

        string Password { get; set; }

        event EventHandler ConnectToServer;

        event EventHandler ConnectToDatabase;
    }
}
