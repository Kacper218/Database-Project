using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using Projekt_bazodanowy.Models;
using System.Web;

namespace Projekt_bazodanowy
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());        
        }
    }
}
