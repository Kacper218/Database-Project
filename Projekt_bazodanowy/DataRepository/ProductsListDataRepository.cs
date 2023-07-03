using Projekt_bazodanowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_bazodanowy.DataRepository
{
    public class ProductsListDataRepository
    {
        private static List<Produkty> _dataList;
        public static List<Produkty> DataList
        {
            get { return _dataList; }
            set { _dataList = value; }
        }
    }
}
