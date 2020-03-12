using System.Data.SqlClient;

namespace StockControl.Controller
{
    interface IConnectionController
    {
        public SqlConnection Cn { get; set; }

        public SqlConnection Connect();

        public SqlConnection Disconnect();
    }
}
