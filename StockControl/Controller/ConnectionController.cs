using System.Data.SqlClient;

namespace StockControl.Controller
{
    class ConnectionController : IConnectionController
    {

        public SqlConnection cn;

        public ConnectionController()
        {
            cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=KUCHIYOSE;Initial Catalog=SC;Persist Security Info=True;User ID=sa;Password=fordev";
        }

        public SqlConnection Cn { get; set; }

        //If the connection is closed(disconnected)
        public SqlConnection Connect()
        {
            if (cn.State == System.Data.ConnectionState.Closed)
            {
                cn.Open();
            }//end if
            return cn;
        }//end Connect

        //If the SqlConnection is open(Connected)
        public SqlConnection Disconnect()
        {
            if (cn.State == System.Data.ConnectionState.Open)
            {
                cn.Close();
            }//end if
            return cn;
        }//end Disconnect



    }//end class
}//end namespace
