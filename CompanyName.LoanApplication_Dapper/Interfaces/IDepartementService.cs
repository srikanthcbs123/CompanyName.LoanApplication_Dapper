using CompanyName.LoanApplication_Dapper.Dtos;

namespace CompanyName.LoanApplication_Dapper.Interfaces
{
    public interface IDepartementService
    {
        Task<List<DepartementDto>> GetDepartMentDetails();
        Task<DepartementDto> GetDepartmentDetailsById(int deptid);
        Task<int> AddDeparment(DepartementDto deptdetail);
        Task<bool> DeleteDepartmentById(int deptid);
        Task<bool> UpdateDepartment(DepartementDto deptdetail);
    }
}
