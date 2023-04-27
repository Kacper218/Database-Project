using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_bazodanowy.Models
{
    public class Paragony
    {
        public virtual string IDDokumentu { get; set; }
        public virtual DateTime  DataZakupu { get; set; }
        public virtual int IDKlienta { get; set; }
        public virtual double KwotaCalkowita { get; set; }
    }
}
