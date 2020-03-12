using StockControl.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace StockControl.Controller
{
    class SQLInstructions : ISQLInstructions
    {
        private SqlCommand cmd;
        private IConnectionController connection;

        //Insert in DB
        public void InsertDB(Product p)
        {

            connection = new ConnectionController();
            SqlConnection sc = new SqlConnection();
            sc = connection.Cn;

            //SQL Command
            cmd = new SqlCommand("INSERT INTO Products (Name, Quantity, PurchasePrice, SalePrice, Buy, Sell)" +
                "values (@Name, @Quantity, @PurchasePrice, @SalePrice, @Buy, @Sell)", sc);

            //Parameters
            cmd.Parameters.AddWithValue("@Name", p.Name);
            cmd.Parameters.AddWithValue("@Quantity", p.Quantity);
            cmd.Parameters.AddWithValue("@PurchasePrice", p.PurchasePrice);
            cmd.Parameters.AddWithValue("@SalePrice", p.SalePrice);
            cmd.Parameters.AddWithValue("@Buy", p.Buy);
            cmd.Parameters.AddWithValue("@Sell", p.Sell);

            try
            {
                //Object
                connection = new ConnectionController();
                //Connect to the DB
                cmd.Connection = connection.Connect();
                //Execute command
                cmd.ExecuteNonQuery();
                //Disconnect the DB
                cmd.Connection = connection.Disconnect();
            }
            catch (SqlException)
            {
                Console.WriteLine("Nome do produto excede o limite para registro, tente novamente.");
            }
            finally
            {
                connection.Disconnect();
            }
        }

        public void SelectDB(List<Product> list)
        {
            cmd = new SqlCommand();

            //SQL Command
            cmd.CommandText = "SELECT * FROM Products";

            try
            {
                //Object
                connection = new ConnectionController();
                Product p;
                SqlDataReader reader;

                //Connect to the DB
                cmd.Connection = connection.Connect();
                //Execute command
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    //Loop to read the rows and set in the object
                    while (reader.Read())
                    {
                        p = new Product();
                        p.ID = Convert.ToInt32(reader["ID"].ToString());

                        //Repeated data test by ID
                        if (!(p.ID <= list.Count))
                        {

                            p.Name = reader["Name"].ToString();
                            p.Quantity = Convert.ToInt32(reader["Quantity"].ToString());
                            p.PurchasePrice = double.Parse(reader["PurchasePrice"].ToString());
                            p.SalePrice = double.Parse(reader["SalePrice"].ToString());
                            p.Buy = double.Parse(reader["Buy"].ToString());
                            p.Sell = double.Parse(reader["Sell"].ToString());

                            list.Add(p);
                        }
                        else
                        {
                            list[p.ID - 1].Name = reader["Name"].ToString();
                            list[p.ID - 1].Quantity = Convert.ToInt32(reader["Quantity"].ToString());
                            list[p.ID - 1].PurchasePrice = double.Parse(reader["PurchasePrice"].ToString());
                            list[p.ID - 1].SalePrice = double.Parse(reader["SalePrice"].ToString());
                            list[p.ID - 1].Buy = double.Parse(reader["Buy"].ToString());
                            list[p.ID - 1].Sell = double.Parse(reader["Sell"].ToString());
                        }
                    }//end while
                }//end if
                reader.Close();

            }//Disconnect the DB
            catch (SqlException)
            {
                Console.WriteLine("Erro ao conectar ao banco de dados, tente novamente");
            }
            finally
            {
                connection.Disconnect();

            }
        }//end selectDB

        public void UpdateInsert(int ID, double quantity, double buy)
        {

            cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Products SET Quantity = @quantity, Buy = @buy WHERE ID = @id";
            connection = new ConnectionController();

            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@buy", buy);
            cmd.Parameters.AddWithValue("@id", ID);

            try
            {
                //Object
                connection = new ConnectionController();
                //Connect to the DB
                cmd.Connection = connection.Connect();
                //Execute command
                cmd.ExecuteNonQuery();
                //Disconnect
                cmd.Connection = connection.Disconnect();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro ao alterar dados no Banco.");
            }
            finally
            {
                //Disconnect the DB
                cmd.Connection = connection.Disconnect();
            }
        }

        public void UpdateRemove(int ID, double quantity, double sell)
        {

            cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Products SET Quantity = @quantity, Sell = @sell WHERE ID = @id";
            connection = new ConnectionController();

            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@sell", sell);
            cmd.Parameters.AddWithValue("@id", ID);

            try
            {
                //Object
                connection = new ConnectionController();
                //Connect to the DB
                cmd.Connection = connection.Connect();
                //Execute command
                cmd.ExecuteNonQuery();
                //Disconnect
                cmd.Connection = connection.Disconnect();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro ao alterar dados no Banco.");
            }
            finally
            {
                //Disconnect the DB
                cmd.Connection = connection.Disconnect();
            }
        }

    }
}
