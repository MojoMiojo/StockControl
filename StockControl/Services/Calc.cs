using StockControl.Model;
using System.Globalization;

namespace StockControl.Services
{
    class Calc
    {
        //Constructor
        public Calc()
        {
        }

        /*
         * Method to calculate
         * the sum of the products value
         */
        public double ProductValue(Product p)
        {
            return p.PurchasePrice * p.Quantity;
        }//end ProductValue

        /*
         * Method to calculate
         * the profit balance
         */
        public double Profit(Product P)
        {
            System.Console.WriteLine("Vendas: R$" +P.Sell.ToString("F2")+"+ <> Compras: R$"+P.Buy.ToString("F2")+"-");
            return P.Sell - P.Buy;
        }//end Profit()
    }//end Calc
}//end namespace
