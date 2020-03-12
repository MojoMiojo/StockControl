using StockControl.Model;
using System.Collections.Generic;

namespace StockControl.Controller
{
    interface ISQLInstructions
    {
        public void InsertDB(Product p);

        public void SelectDB(List<Product> list);

        public void UpdateInsert(int ID, double quantity, double buy);

        public void UpdateRemove(int ID, double quantity, double sell);
    }
}
