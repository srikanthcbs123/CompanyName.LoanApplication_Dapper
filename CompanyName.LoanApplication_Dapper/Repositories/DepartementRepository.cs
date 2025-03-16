using CompanyName.LoanApplication_Dapper.Entities;
using CompanyName.LoanApplication_Dapper.Interfaces;
using CompanyName.LoanApplication_Dapper.Utility;
using Dapper;
using System.Data;

namespace CompanyName.LoanApplication_Dapper.Repositories
{
    public class DepartementRepository : IDepartementRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public DepartementRepository(IConnectionFactory connectionFactory)
        {
                this._connectionFactory= connectionFactory;
        }
        public async Task<int> AddDeparment(Departement deptdetail)
        { //as per the dapper rule.please assign your connection string object to IDbconnection.
            using (IDbConnection con = _connectionFactory.Northwind_DBSqlConnectionString())
            {//Create object for DynamicParameters for storedure input parameter values binding purpose used.
                var p = new DynamicParameters();//DynamicParameters comming from Dapper package
                p.Add("@deptname", deptdetail.deptname);
                p.Add("@deptlocation", deptdetail.deptlocation);
                p.Add("@insertedvalue", DbType.Int32, direction: ParameterDirection.Output);
                await con.ExecuteScalarAsync<int>(StoredProcedureNames.AddDepartment, p, commandType: CommandType.StoredProcedure);
                int inserterdid = p.Get<int>("@insertedvalue");
                return inserterdid;
            }

        }

        public async Task<bool> DeleteDepartmentById(int deptid)
        {
            using (IDbConnection con = _connectionFactory.Northwind_DBSqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@deptid", deptid);
                await con.ExecuteScalarAsync(StoredProcedureNames.DeleteDepartment, p, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<List<Departement>> GetDepartMentDetails()
        {
            List<Departement> res;
            using (IDbConnection conn = _connectionFactory.Northwind_DBSqlConnectionString())
            {
                var queryresult = await conn.QueryAsync<Departement>(StoredProcedureNames.GetDepartment, CommandType.StoredProcedure);
                return res = queryresult.ToList();
            }
        }

        public async Task<Departement> GetDepartmentDetailsById(int deptid)
        {
            Departement dept;
            using (IDbConnection con = _connectionFactory.Northwind_DBSqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@deptid", deptid);
                var result = await con.QueryAsync<Departement>(StoredProcedureNames.GetDepartmentByDeptId, p, commandType: CommandType.StoredProcedure);
                return dept = result.FirstOrDefault();
               
            }
        }

        public async Task<bool> UpdateDepartment(Departement deptdetail)
        {
            using (IDbConnection con = _connectionFactory.Northwind_DBSqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@deptid", deptdetail.deptid);
                p.Add("@deptname", deptdetail.deptname);
                p.Add("@deptlocation", deptdetail.deptlocation);
                await con.ExecuteReaderAsync(StoredProcedureNames.UpdateDepartment, p, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
