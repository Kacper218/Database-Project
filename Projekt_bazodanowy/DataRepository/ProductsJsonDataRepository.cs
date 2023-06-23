using Projekt_bazodanowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_bazodanowy.DataRepository
{
    public class ProductsJsonDataRepository
    {
        private static IList<Produkty> _dataList;
        public static IList<Produkty> DataList
        {
            get { return _dataList; }
            set { _dataList = value; }
        }
    }
}
