using CompanyName.LoanApplication_Dapper.Entities;

namespace CompanyName.LoanApplication_Dapper.Interfaces
{
    public interface IDepartementRepository
    {  //these are crud opertion methods.
        Task<List<Departement>> GetDepartMentDetails();
        Task<Departement> GetDepartmentDetailsById(int deptid);
        Task<int> AddDeparment(Departement deptdetail);
        Task<bool> DeleteDepartmentById(int deptid);
        Task<bool> UpdateDepartment(Departement deptdetail);
    }
}
