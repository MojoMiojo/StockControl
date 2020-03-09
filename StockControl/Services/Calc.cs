using StockControl.Model;

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
            
            System.Console.WriteLine($"Vendas: {P.Sell}+ <> Compras: {P.Buy}-");
            return P.Sell - P.Buy;
        }

    }
}
