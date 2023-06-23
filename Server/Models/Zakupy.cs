using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Zakupy
    {
        public virtual string IDZakupu { get; set; }
        public virtual string IDDokumentu { get; set; }
        public virtual string IDProduktu { get; set; }
        public virtual string Ilosc { get; set; }
        public virtual string CenaZakupu { get; set; }
    }
}
