/*Aproveitando o final de semana,
 *gostaria que você desenvolvesse um projeto em C#,
 *que simulasse o controle de estoque, ou seja, 
 *cadastrar um item, depois dar saída e entrada no mesmo.

Necessário:
Utilizar um SGBD
Aplicar o conceito de injeção de dependência 

Desejável:
Criar camadas lógicas, interface, negócio e dados.*/

using System;
using System.Threading;
using StockControl.Controller;

namespace StockControl
{
    class Program
    {

        /*
         * Method to advise
         * the wrong input
         */
        static void InvalidInput()
        {
            Console.WriteLine("\nEntrada inválida!");
            Thread.Sleep(750);
            Console.Clear();
        }

        static void Main(string[] args)
        {

            int option = -1;

            //Interface object and DataBase initializer
            IProductController pc = new ProductController(new SQLInstructions());

            while (option != 0)
            {
                try
                {
                    Console.WriteLine("-Controle de Estoque-\n");

                    Console.WriteLine("1 - Cadastrar Produto\n" +
                                      "2 - Mostrar produtos cadastrados\n"
                                    + "3 - Entrada de produtos\n" +
                                      "4 - Saída de produtos\n"
                                    + "5 - Visão de Lucros\n" +
                                      "0 - Sair\n");


                    Console.Write("Escolha a opção desejada: ");
                    option = int.Parse(Console.ReadLine());

                    Console.Clear();

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("-Cadastro de produtos-\n");
                            pc.NewProduct();
                            break;
                        case 2:
                            Console.WriteLine("-Lista de Produtos Cadastros-\n");
                            pc.ShowProducts();
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("-Entrada de Estoque-\n");
                            pc.IncrementProduct();
                            break;
                        case 4:
                            Console.WriteLine("-Saída de Estoque-\n");
                            pc.RemoveProduct();
                            break;
                        case 5:
                            Console.WriteLine("-Visão de Lucros-\n");
                            pc.ViewProfit();
                            break;
                        case 0:
                            break;
                        default:
                            Console.WriteLine("-Controle de Estoque-\n");
                            Console.WriteLine("1 - Cadastrar Produto\n" +
                                              "2 - Mostrar produtos cadastrados\n"
                                            + "3 - Entrada de produtos\n" +
                                              "4 - Saída de produtos\n"
                                            + "5 - Visão de Lucros\n" +
                                              "0 - Sair\n");
                            Console.Write("Escolha a opção desejada: ");
                            InvalidInput();
                            break;
                    }//end Switch
                    Console.Clear();
                }
                catch (FormatException)
                {
                    InvalidInput();
                }
                catch (OverflowException)
                {
                    InvalidInput();
                }
            }//end While

        }
    }
}
