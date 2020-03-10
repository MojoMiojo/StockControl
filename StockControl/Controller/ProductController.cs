using System;
using System.Globalization;
using System.Collections.Generic;
using StockControl.Model;
using StockControl.Services;

namespace StockControl.Controller
{
    class ProductController
    {
        public List<Product> list = new List<Product>();
        private Calc _calc = new Calc();

        public ProductController()
        {
        }

        public Product NewProduct()
        {
            double buy = 0, salePrice = 0, purchasePrice = 0;
            string name;
            int quantity;

            Console.Write("Entre com o nome do produto: ");
            name = Console.ReadLine();
            Console.Write("Qual a quantidade atual a ser armazenada em estoque? ");
            quantity = int.Parse(Console.ReadLine());

            //If the quantity to be register is bigger than zero, request the purchase price.
            if (quantity > 0)
            {
                Console.Write("Valor de compra: R$");
                purchasePrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                buy = purchasePrice * quantity;
            }

            Console.Write("Valor de Venda: R$");
            salePrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Product p = new Product(name, quantity, purchasePrice, salePrice);
            //If quantity bigger than zero in register moment
            if (buy > 0)
            {
                p.Buy = buy;
            }

            list.Sort();
            return p;
        }//end Pru

        public void ShowProducts()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Não há produtos cadastrados.");
                
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine("|Id: " + (i + 1) + " " + list[i] + " Valor em estoque: R$" + _calc.ProductValue(list[i]).ToString("F2") + "|");
                }
                
            }
            
        }//end ShowProducts();

        public void IncrementProduct()
        {
            int cod, quantity;
            double purchaseValue;

            if (list.Count == 0)
            {
                ShowProducts();
                Console.ReadLine();
            }
            else
            {
                ShowProducts();
                Console.WriteLine();
                Console.Write("Em qual produto cadastrado deseja dar entrada? Código: ");
                cod = int.Parse(Console.ReadLine());
                Console.Write($"Quantos(as) {list[cod - 1].Name.ToUpper()} deseja incrementar? Atual:{list[cod - 1].Quantity} | A incrementar: ");
                quantity = int.Parse(Console.ReadLine());
                Console.Write("Valor de compra: R$");
                purchaseValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                list[cod - 1].Quantity += quantity;
                list[cod - 1].Buy += quantity * purchaseValue;
                Console.WriteLine("\nSucesso!");
                Console.ReadLine();
            }
        }

        public void RemoveProduct()
        {
            int cod, quantity;
            double sell;

            if (list.Count == 0)
            {
                ShowProducts();
                
            }
            else
            {
                ShowProducts();
                Console.WriteLine();
                Console.Write("Qual produto cadastrado deseja dar saída? Código: ");
                cod = int.Parse(Console.ReadLine());
                Console.Write($"Quantos(as) {list[cod - 1].Name.ToUpper()} deseja remover? Atual:{list[cod - 1].Quantity} | A remover: ");
                quantity = int.Parse(Console.ReadLine());

                list[cod - 1].Quantity -= quantity;
                sell = (list[cod - 1].SalePrice) * quantity;
                list[cod - 1].Sell += sell;

                Console.WriteLine("\nSucesso!");
                
            }
            Console.ReadLine();
        }

        public void ViewProfit()
        {
            double sum = 0, profit = 0;

            for (int i = 0; i < list.Count; i++)
            {
                profit = _calc.Profit(list[i]);
                sum += profit;
                Console.WriteLine(list[i].Name + " Lucro: R$" + profit.ToString("F2"),CultureInfo.InvariantCulture);
                Console.WriteLine();
            }
            Console.WriteLine("Lucro total: R$" + sum.ToString("F2"),CultureInfo.InvariantCulture);
            Console.ReadLine();
        }
    }
}
