﻿namespace StockControl.Model
{
    class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double SalePrice { get; set; }
        public double Buy { get; set; }
        public double Sell{ get; set; }

        

        public Product(string name, int quantity, double price, double salePrice )
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            SalePrice = salePrice;
        }

        public override string ToString()
        {
            return "|Nome:" +Name
                + "| Quantidade: "+ Quantity
                + "| Valor Unitário: R$" + Price.ToString("F2") + "|";
        }

    }//end class
}//end namespace
