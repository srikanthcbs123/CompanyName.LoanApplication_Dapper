using CompanyName.LoanApplication_Dapper.Dtos;
using CompanyName.LoanApplication_Dapper.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyName.LoanApplication_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeServices _empservice;
        //EmployeeService obj = new EmployeeService();tightcouplyed

        public EmployeeController(IEmployeeServices empservice)
        {
            _empservice = empservice;
        }
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> Post([FromBody] EmployeeDtos empdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var empdata = await _empservice.AddEmployes(empdto);
                    return StatusCode(StatusCodes.Status201Created, empdata);
                }
            }
            catch (Exception ex)
            {//if you got any error we are using this statuscode:Status500InternalServerError
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpDelete]
        [Route("DeleteEmployeeByEmpid/{empid}")]
        public async Task<IActionResult> delete(int empid)
        {
            if (empid < 0)
            {//If input parameters are wrongly sent or empty, we will get 400 badrequest statuscode:Status400BadRequest
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var empdata = await _empservice.DeleteEmployesById(empid);
                if (empdata == null)
                {//in db if you get empty data we need to retrun this statuscode:Status404NotFound
                    return StatusCode(StatusCodes.Status404NotFound, "empdata not  found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "deleted successfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var empdata = await _empservice.GetEmployees();
                if (empdata == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "bad request");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, empdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }

        }
        [HttpGet]
        [Route("GetEmployeeByEmpid/{empid}")]
        public async Task<IActionResult> Get(int empid)
        {
            if (empid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var empdata = await _empservice.GetEmployeeById(empid);
                return StatusCode(StatusCodes.Status200OK, empdata);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server eror");
            }
        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> put([FromBody] EmployeeDtos empdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var empdata = await _empservice.UpdateEmploye(empdto);
                    return StatusCode(StatusCodes.Status200OK, empdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
    }
}
