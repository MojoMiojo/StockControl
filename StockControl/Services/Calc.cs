using StockControl.Model;
using System.Globalization;

namespace StockControl.Services
{
    class Calc
    {
        
        public Calc()
        {
        }

        public double ProductValue(Product p)
        {
            return p.Price * p.Quantity;
        }

        public double Profit(Product P)
        {
            
            System.Console.WriteLine("Vendas: " +P.Sell.ToString("F2")+" <> Compras: "+P.Buy.ToString("F2")+"-");
            return P.Sell - P.Buy;
        }

    }
}
