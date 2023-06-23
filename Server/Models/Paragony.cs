using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Paragony
    {
        public virtual string IDDokumentu { get; set; }
        public virtual DateTime  DataZakupu { get; set; }
        public virtual string IDKlienta { get; set; }
        public virtual string KwotaCalkowita { get; set; }
    }
}
