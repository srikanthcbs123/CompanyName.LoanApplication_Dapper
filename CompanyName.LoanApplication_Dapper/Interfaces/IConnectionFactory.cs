using System.Data;

namespace CompanyName.LoanApplication_Dapper.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection MidLandSqlConnectionString();
        IDbConnection Northwind_DBSqlConnectionString();
        IDbConnection hotelmanagementsqlConnectionString();
    }
}
