using CompanyName.LoanApplication_Dapper.Dtos;
using CompanyName.LoanApplication_Dapper.Entities;
using CompanyName.LoanApplication_Dapper.Interfaces;

namespace CompanyName.LoanApplication_Dapper.Sevices
{
    public class EmployeeServices : IEmployeeServices
    {
        IEmployeeRepository _repository;
        public EmployeeServices(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddEmployes(EmployeeDtos empdetail)
        {
            Employee emp = new Employee();
            emp.empid = empdetail.empid;
            emp.empsalary = empdetail.empsalary;
            emp.empname = empdetail.empname;
            var res = await _repository.AddEmployes(emp);
            return res;
        }

        public  async Task<bool> DeleteEmployesById(int empid)
        {
            await _repository.DeleteEmployesById(empid);
            return true;
        }

        public async Task<EmployeeDtos> GetEmployeeById(int empid)
        {
            var res = await _repository.GetEmployeeById(empid);
            EmployeeDtos empdto = new EmployeeDtos();
            empdto.empid = res.empid;
            empdto.empname = res.empname;
            empdto.empsalary = res.empsalary;
            return empdto;
        }

        public async Task<List<EmployeeDtos>> GetEmployees()
        {
            List<EmployeeDtos> lstempdto = new List<EmployeeDtos>();
            var res = await _repository.GetEmployees();
            foreach (Employee emp in res)
            {
                EmployeeDtos empdto = new EmployeeDtos();
                empdto.empid = emp.empid;
                empdto.empsalary = emp.empsalary;
                empdto.empname = emp.empname;
                lstempdto.Add(empdto);

            }
            return lstempdto;
        }

        public async Task<bool> UpdateEmploye(EmployeeDtos empdetail)
        {
            Employee emp = new Employee();
            emp.empid = empdetail.empid;
            emp.empsalary = empdetail.empsalary;
            emp.empname = empdetail.empname;
            await _repository.UpdateEmploye(emp);
            return true;
        }
    }
}
