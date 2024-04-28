using CRUD_API.Data;
using CRUD_API.Model;
using CRUD_API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ErrorResponseService _errorResponseService;

        public EmployeeController(ApplicationDbContext context, ErrorResponseService errorResponseService)
        {
            _context = context;
            _errorResponseService = errorResponseService;
        }

        //GET: List Employee
        [HttpGet("index")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            try
            {
                var employeeList = await _context.Employee.ToListAsync();

                if (employeeList == null || employeeList.Count == 0)
                {
                    var errorResponse = _errorResponseService.CreateErrorResponse(404, "Employee not found");
                    return BadRequest(errorResponse);
                }

                var response = new
                {
                    Status = 200,
                    Message = "Action Performed Successfully",
                    Data = employeeList
                };

                return Created("", employeeList);

            }

            catch (Exception)
            {
                var errorResponse = _errorResponseService.CreateErrorResponse(500, "Internal Server Error");
                return StatusCode(500, errorResponse);
            }
        }

        //POST: Create Employee 
        [HttpPost("create")]
        public async Task<ActionResult<Employee>> EmployeeRegister(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Check if email already exist
                    var existEmployee = await _context.Employee.FirstOrDefaultAsync(e => e.EmployeeEmail == employee.EmployeeEmail);
                    if (existEmployee != null)
                    {
                        var errorResponse = _errorResponseService.CreateErrorResponse(400, "Employee already exist");
                        return BadRequest(errorResponse);
                    }

                    _context.Employee.Add(employee);
                    await _context.SaveChangesAsync();

                    var response = new
                    {
                        Status = 200,
                        Message = "Employee registered Successfully",
                        Data = employee
                    };

                    return Created("", response);
                }
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                var errorResponse = _errorResponseService.CreateErrorResponse(500, "Internal Server Error");
                return StatusCode(500, errorResponse);
            }
        }

        //POST: Update Employee
        [HttpPost("update")]
        public async Task<ActionResult<Employee>> EmployeeUpdate(int employeeId, [FromBody] Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existEmployee = await _context.Employee.FindAsync(employeeId);

                    if (existEmployee == null)
                    {
                        var errorResponse = _errorResponseService.CreateErrorResponse(404, "No employee matches");
                        return BadRequest(errorResponse);
                        
                    }

                    existEmployee.EmployeeName = employee.EmployeeName;
                    existEmployee.EmployeeEmail = employee.EmployeeEmail;
                    existEmployee.Password = employee.Password;
                    existEmployee.Address = employee.Address;

                    await _context.SaveChangesAsync();

                    var response = new
                    {
                        Status = 200,
                        Message = "Employee updated Successfully",
                        Data = existEmployee
                    };

                    return Created("", response);
                }
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                var errorResponse = _errorResponseService.CreateErrorResponse(500, "Internal Server Error");
                return StatusCode(500, errorResponse);
            }
        }

        //POST: Delete Employee
        [HttpPost("delete")]
        public async Task<ActionResult<Employee>> EmployeeDelete(int employeeId)
        {
            try
            {
                var existEmployee = await _context.Employee.FindAsync(employeeId);

                if (existEmployee == null)
                {
                    var errorResponse = _errorResponseService.CreateErrorResponse(404, "Wrong employee id selected");
                    return BadRequest(errorResponse);
                }

                _context.Employee.Remove(existEmployee);
                await _context.SaveChangesAsync();

                var response = new
                {
                    Status = 200,
                    Messaage = "Employee deleted Successfully",
                    Data = existEmployee
                };
                return Created("", response);
            }
            catch (Exception)
            {
                var errorResponse = _errorResponseService.CreateErrorResponse(500, "Internal Server Error");
                return StatusCode(500, errorResponse);
            }
        }
    }
}
