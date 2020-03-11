using System;
using System.Collections.Generic;
using System.Text;

namespace StockControl.Controller
{
    interface IProductController
    {
        public void NewProduct();

        public void ShowProducts();

        public void IncrementProduct();

        public void RemoveProduct();

        public void ViewProfit();
    }
}
