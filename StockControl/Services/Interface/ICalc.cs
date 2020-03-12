using StockControl.Model;

namespace StockControl.Services
{
    interface ICalc
    {
        public double ProductValue(Product p);

        public double Profit(Product P);
    }
}
