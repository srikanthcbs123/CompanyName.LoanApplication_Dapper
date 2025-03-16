using CompanyName.LoanApplication_Dapper.Dtos;
using CompanyName.LoanApplication_Dapper.Entities;
using CompanyName.LoanApplication_Dapper.Interfaces;

namespace CompanyName.LoanApplication_Dapper.Sevices
{
    public class DepartementService : IDepartementService
    {
        private readonly IDepartementRepository _departementRepository;
        public DepartementService(IDepartementRepository departementRepository)
        {
                this._departementRepository = departementRepository;
        }
        public async Task<int> AddDeparment(DepartementDto deptdetail)
        {
            Departement objDept = new Departement();
            objDept.deptname = deptdetail.deptname;
            objDept.deptlocation = deptdetail.deptlocation;
            objDept.deptid = deptdetail.deptid;
            var res = await _departementRepository.AddDeparment(objDept);
            return res;
        }

        public async Task<bool> DeleteDepartmentById(int deptid)
        {
            await _departementRepository.DeleteDepartmentById(deptid);
            return true;
        }

        public async Task<List<DepartementDto>> GetDepartMentDetails()
        {
            List<DepartementDto> lstempdto = new List<DepartementDto>();
            var res = await _departementRepository.GetDepartMentDetails();
            foreach (Departement dept in res)
            {
                DepartementDto deptdto = new DepartementDto();
                deptdto.deptid = dept.deptid;
                deptdto.deptname = dept.deptname;
                deptdto.deptlocation = dept.deptlocation;
                lstempdto.Add(deptdto);

            }
            return lstempdto;
        }

        public async Task<DepartementDto> GetDepartmentDetailsById(int deptid)
        {
            var res = await _departementRepository.GetDepartmentDetailsById(deptid);
            DepartementDto deptdto = new DepartementDto();
            deptdto.deptid = res.deptid;
            deptdto.deptname = res.deptname;
            deptdto.deptlocation = res.deptlocation;
            return deptdto;
        }

        public async Task<bool> UpdateDepartment(DepartementDto deptdetail)
        {
            Departement objDept = new Departement();
            objDept.deptid = deptdetail.deptid;
            objDept.deptname = deptdetail.deptname;
            objDept.deptlocation = deptdetail.deptlocation;
            await _departementRepository.UpdateDepartment(objDept);
            return true;
        }
    }
}
