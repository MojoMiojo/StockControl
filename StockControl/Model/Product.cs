using System.Globalization;

namespace StockControl.Model
{
    class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public double Buy { get; set; }
        public double Sell { get; set; }

        public Product()
        {
        }

        public Product(string name, int quantity, double price, double salePrice, double buy)
        {
            Name = name;
            Quantity = quantity;
            PurchasePrice = price;
            SalePrice = salePrice;
            Buy = buy;
        }

        public override string ToString()
        {
            return "|Nome:" + Name
                + "| Quantidade: " + Quantity
                + "| Valor Unitário: R$" + SalePrice.ToString("F2") + "|";
        }

    }//end class
}//end namespace
