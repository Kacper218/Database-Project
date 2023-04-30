using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_bazodanowy.Models
{
    public class Klienci
    {
        public virtual string IDKlienta { get; set; }
        public virtual string ImieNazwisko { get; set; }
        public virtual string NazwaFirmy { get; set; }
        public virtual string Email { get; set; }
    }
}
