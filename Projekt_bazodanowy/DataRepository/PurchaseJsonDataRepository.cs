using Projekt_bazodanowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_bazodanowy.DataRepository
{
    public class PurchaseJsonDataRepository
    {
        private static IList<Zakupy> _dataList;
        public static IList<Zakupy> DataList
        {
            get { return _dataList; }
            set { _dataList = value; }
        }
    }
}
