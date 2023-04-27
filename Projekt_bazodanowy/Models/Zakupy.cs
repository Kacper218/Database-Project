using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_bazodanowy.Models
{
    public class Zakupy
    {
        public virtual int IDZakupu { get; set; }
        public virtual string IDDokumentu { get; set; }
        public virtual int IDProduktu { get; set; }
        public virtual int Ilosc { get; set; }
        public virtual double CenaZakupu { get; set; }
    }
}
