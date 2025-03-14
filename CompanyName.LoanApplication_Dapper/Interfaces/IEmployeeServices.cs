using CompanyName.LoanApplication_Dapper.Dtos;

namespace CompanyName.LoanApplication_Dapper.Interfaces
{
    public interface IEmployeeServices
    {
        Task<List<EmployeeDtos>> GetEmployees();
        Task<EmployeeDtos> GetEmployeeById(int empid);
        Task<int> AddEmployes(EmployeeDtos empdetail);
        Task<bool> DeleteEmployesById(int empid);
        Task<bool> UpdateEmploye(EmployeeDtos empdetail);
    }
}
