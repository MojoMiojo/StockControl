namespace StockControl.Model
{
    class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }


        public Product(string name, int quantity, double price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public override string ToString()
        {
            return "Nome:" +Name
                + " Quantidade:" + Quantity
                + " Valor Unitário:" + Price.ToString("F2");
        }

    }//end class
}//end namespace
