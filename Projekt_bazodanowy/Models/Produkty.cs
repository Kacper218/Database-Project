using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_bazodanowy.Models
{
    public class Produkty
    {
        public virtual string IDProduktu { get; set; }
        public virtual string Nazwa { get; set; }   
        public virtual string CenaAktualna { get; set; }
        public virtual string Dostepnosc { get; set; } 
    }
}
