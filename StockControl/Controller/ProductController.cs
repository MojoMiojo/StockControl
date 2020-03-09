using System;
using System.Globalization;
using System.Collections.Generic;
using StockControl.Model;

namespace StockControl.Controller
{
    class ProductController
    {
        public List<Product> list = new List<Product>();

        public ProductController()
        {
        }

        public Product NewProduct()
        {
            Console.Write("Entre com o nome do produto: ");
            string name = Console.ReadLine();
            Console.Write("Qual a quantidade atual a ser armazenada em estoque? ");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write("Qual o valor unitário deste produto? R$");
            double unitPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Product p = new Product(name, quantity, unitPrice);
            list.Sort();
            return p;
        }//end Pru

        public void ShowProducts()
        {
            int id = 1;
            if (list.Count == 0)
            {
                Console.WriteLine("Não há produtos cadastrados.");
            }
            else
            {
                foreach (Product p in list)
                {
                    Console.WriteLine("Codigo:" + id + " " + p);
                    id++;
                }
            }

        }
        public void IncrementProduct()
        {
            ShowProducts();
            Console.WriteLine();
            Console.Write("Em qual produto cadastrado deseja dar entrada? ");
            int cod = int.Parse(Console.ReadLine());
            Console.Write($"Quantos(as) {list[cod - 1].Name.ToUpper()} deseja incrementar? Atual:{list[cod - 1].Quantity} A incrementar: ");
            int quantity = int.Parse(Console.ReadLine());

            list[cod - 1].Quantity += quantity;
            Console.WriteLine("\nSucesso!");
            Console.ReadLine();
        }

        public void RemoveProduct()
        {
            ShowProducts();
            Console.WriteLine();
            Console.Write("Qual produto cadastrado deseja dar saída: ");
            int cod = int.Parse(Console.ReadLine());
            Console.Write($"Quantos(as) {list[cod - 1].Name.ToUpper()} deseja remover? Atual:{list[cod - 1].Quantity} A remover: ");
            int quantity = int.Parse(Console.ReadLine());

            list[cod - 1].Quantity -= quantity;
            Console.WriteLine("\nSucesso!");
            Console.ReadLine();
        }
    }
}
