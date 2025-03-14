using CompanyName.LoanApplication_Dapper.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CompanyName.LoanApplication_Dapper.Connection
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _config;
        public ConnectionFactory(IConfiguration config)
        {
                this._config = config;
        }
        //Don't hard code connecting sting like below.
        //always read the connection string from appsettings.json file
        // string connectionString = "data source=DESKTOP-AAO14OC;Encrypt=True;TrustServerCertificate=True;initial catalog=hotelmanagement;integrated security=yes";
        //Note:
        public IDbConnection MidLandSqlConnectionString()
        {
            var connStr = Convert.ToString(_config.GetSection("ConnectionStrings:MidLandSqlConnectionString").Value);
            //Creates an IDbConnection Object to store the sqlconnection.
            IDbConnection con = new SqlConnection(connStr);
            return con;
        }

        public IDbConnection Northwind_DBSqlConnectionString()
        {
            var connStr = Convert.ToString(_config.GetSection("ConnectionStrings:Northwind_DBSqlConnectionString").Value);
            // Creates an IDbConnection Object to store the sqlconnection.
            IDbConnection _connection = new SqlConnection(connStr);
            return _connection;
        }

        public IDbConnection hotelmanagementsqlConnectionString()
        {
            var connStr = Convert.ToString(_config.GetSection("ConnectionStrings:hotelmanagementsqlConnectionString").Value);
            // Creates an IDbConnection Object to store the sqlconnection.
            IDbConnection con = new SqlConnection(connStr);
            return con;
        }
    }
}
    

