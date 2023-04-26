using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_bazodanowy.Models
{
    public class Product
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual double Price { get; set; }
        public virtual int Units { get; set; }
    }
}
