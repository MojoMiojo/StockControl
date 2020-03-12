using StockControl.Controller;

namespace StockControl.Model
{
    class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public double Buy { get; set; }
        public double Sell { get; set; }

        IProductController input;

        public Product()
        {
        }

        public Product(string name, int quantity, double purchasePrice, double salePrice, double buy)
        {
            Name = name;
            Quantity = quantity;
            PurchasePrice = purchasePrice;
            SalePrice = salePrice;
            Buy = buy;
        }

        public override string ToString()
        {
            input = new ProductController();

            return "ID: " + input.toScreen(ID.ToString(), 4) 
                 + "   | Name: " + input.toScreen(Name, 20)
                 + "   | Quantidade: " + input.toScreen(Quantity.ToString(), 4)
                 + "   | Valor Unitário: R$" + input.toScreen(SalePrice.ToString("F2"),10);
        }

    }//end class
}//end namespace
