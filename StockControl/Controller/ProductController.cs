using System;
using System.Globalization;
using System.Collections.Generic;
using StockControl.Model;
using StockControl.Services;

namespace StockControl.Controller
{
    class ProductController
    {
        //Objects
        public List<Product> list = new List<Product>();
        private Calc _calc = new Calc();

        //Constructor
        public ProductController()
        {
        }

        /*
         * Method to insert a
         * new product in the List
         */
        public void NewProduct()
        {
            double buy = 0, salePrice = 0, purchasePrice = 0;
            string name;
            int quantity;
            Product p;

            //Exceptions
            try
            {
                Console.Write("Entre com o nome do produto: ");
                name = Console.ReadLine();
                Console.Write("Qual a quantidade atual a ser armazenada em estoque? ");
                quantity = int.Parse(Console.ReadLine());

                //If the quantity less than zero
                if (quantity < 0)
                {
                    //While the quantity be wrong
                    do
                    {
                        Console.WriteLine("\nNão é possível armazenar uma quantidade negativa de produtos. Por favor, tente novamente.\n");
                        Console.Write("Qual a quantidade a ser armazenada em estoque: ");
                        quantity = int.Parse(Console.ReadLine());
                    } while (quantity < 0);
                }
                //If the quantity to register are bigger than zero, request the purchase price.
                if (quantity > 0)
                {
                    Console.Write("Valor de compra: R$");
                    purchasePrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    //If the user insert a negative purchase value
                    if (purchasePrice < 0)
                    {
                        do
                        {
                            Console.WriteLine("\nO valor de compra não pode ser negativo. Por favor, tente novamente.\n");
                            Console.Write("Valor de compra: R$");
                            purchasePrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        } while (purchasePrice < 0);
                    }//end if purchasePrice < 0

                    buy = purchasePrice * quantity;
                }//end else if quantity > 0, the value can be zero.

                //Read the sale price
                Console.Write("Valor de Venda: R$");
                salePrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                //The sale price can't be negative
                if (salePrice < 0)
                {
                    do
                    {
                        Console.WriteLine("\nO valor de venda não pode ser negativo. Por favor, tente novamente.\n");
                        Console.Write("Valor de venda: R$");
                        salePrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    } while (salePrice < 0);
                }

                //Instancing the object
                p = new Product(name, quantity, purchasePrice, salePrice, buy);

                //Insert in the Products list
                list.Add(p);
                Console.WriteLine("\nSucesso!");
                Console.ReadLine();

            }//end Try
            catch (FormatException)
            {
                Console.WriteLine("\nEntrada inválida, verifique e tente novamente.");
                Console.ReadLine();
            }//end catch
        }//end NewProduct( )

        /*
         * Method to show in the screen
         * all the registered products
         */
        public void ShowProducts()
        {
            //If the list is null
            if (list.Count == 0)
            {
                Console.WriteLine("Não há produtos cadastrados.");
            }
            else
            {   //Products in the list
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine("|Id: " + (i + 1) + " " + list[i] + " Valor em estoque: R$" + _calc.ProductValue(list[i]).ToString("F2") + "|");
                }//end for
            }//end else
        }//end ShowProducts();

        /*
        * Method to insert a new
        * quantity in a register product
        */
        public void IncrementProduct()
        {
            int cod, quantity = 0;
            double purchaseValue = -1;

            //Exceptions test
            try
            {
                //The list cannot be null
                if (list.Count == 0)
                {
                    ShowProducts();
                    Console.ReadLine();
                }// if don't so
                else
                {
                    ShowProducts();
                    Console.WriteLine();

                    //Read the ID of the product that will be added
                    Console.Write("Em qual produto cadastrado deseja dar entrada? Código: ");
                    cod = int.Parse(Console.ReadLine());

                    //Quantity input
                    do
                    {
                        Console.Write($"\nQuantos(as) {list[cod - 1].Name.ToUpper()} deseja dar entrada? Atual:{list[cod - 1].Quantity} | A entrar: ");
                        quantity = int.Parse(Console.ReadLine());
                        //Null quantity test
                        if (quantity <= 0)
                        {
                            Console.WriteLine("\nA entrada de produtos não pode ser nula, negativa ou fracionária.");
                        }
                    } while (quantity <= 0);

                    //Purchase value input
                    do
                    {
                        Console.Write("\nValor de compra: R$");
                        purchaseValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        //The purchase value cannot be null ou negative
                        if (purchaseValue <= 0)
                        {
                            Console.WriteLine("\nO valor de compra não pode ser nulo ou negativo.");
                        }
                    } while (purchaseValue <= 0);

                    //Adding the new quantity 
                    list[cod - 1].Quantity += quantity;
                    //Calculating the new buys value
                    list[cod - 1].Buy += quantity * purchaseValue;

                    Console.WriteLine("\nSucesso!");
                    Console.ReadLine();
                }//end else 
            }//end try
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("\nCódigo Inválido!\nPressione Enter para volta ao Menu.");
                Console.ReadLine();
            }//end catch
        }//end IncrementProduct

        /*
         *Method to do the withdraw 
         *of the products.
         */
        public void RemoveProduct()
        {
            int cod, quantity = 0;
            
            //Exceptions test
            try
            {
                //If the list be null 
                if (list.Count == 0)
                {
                    ShowProducts();

                }
                //If don't so
                else
                {
                    ShowProducts();
                    Console.WriteLine();

                    //Read the ID of the product that will be withdrew
                    Console.Write("Qual produto cadastrado deseja dar saída? Código: ");
                    cod = int.Parse(Console.ReadLine());

                    //Loop to test the quantity and ID product to withdrawn
                    do
                    {
                        Console.Write($"\nQuantos(as) {list[cod - 1].Name.ToUpper()} deseja dar baixa? Atual:{list[cod - 1].Quantity} | Baixa: ");
                        quantity = int.Parse(Console.ReadLine());
                        if (quantity <= 0)
                        {
                            Console.WriteLine("\nO valor de baixa não pode pode ser nulo, negativo ou fracionário.");
                        }
                        else if (quantity > list[cod - 1].Quantity)
                        {
                            Console.WriteLine("\nQuantidade indisponível para baixa.");
                        }
                    } while (quantity <= 0 || quantity > list[cod - 1].Quantity);

                    //Updating the withdraw
                    list[cod - 1].Quantity -= quantity;
                    //Updating the value of the new sales in the object
                    list[cod - 1].Sell += (list[cod - 1].SalePrice) * quantity;

                    Console.WriteLine("\nSucesso!");

                }//end else
                Console.ReadLine();
            }//end try
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("\nCódigo Inválido!\nPressione Enter para volta ao Menu.");
                Console.ReadLine();
            }//end catch
        }//end RemoveProduct( )

        /*
         * Method to view
         * the sales balance
         */
        public void ViewProfit()
        {
            double sum = 0, profit = 0;

            //List loop
            for (int i = 0; i < list.Count; i++)
            {
                //profit receives the diference between the sales and buys
                profit = _calc.Profit(list[i]);
                //sum calculate the whole profit
                sum += profit;

                Console.WriteLine(list[i].Name + " Lucro: R$" + profit.ToString("F2"), CultureInfo.InvariantCulture);
                Console.WriteLine();
            }
            Console.WriteLine("Lucro total: R$" + sum.ToString("F2"), CultureInfo.InvariantCulture);
            Console.ReadLine();
        }//end ViewProfit( )
    }//end ProductController
}//end namespace
