using StockControl.Model;

namespace StockControl.Controller
{
    interface IProductController
    {

        public void NewProduct();

        public void ShowProducts();

        public void IncrementProduct();

        public void RemoveProduct();

        public void ViewProfit();

        public string toScreen(string str, int space);
    }
}
