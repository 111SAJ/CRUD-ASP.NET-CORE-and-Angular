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
    public class LoginController : ControllerBase
    {
        protected readonly ApplicationDbContext _context;
        protected readonly ErrorResponseService _errorResponseService;

        public LoginController(ApplicationDbContext context, ErrorResponseService errorResponseService)
        {
            _context = context;
            _errorResponseService = errorResponseService;
        }

        //POST: Login
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    login.isLoggedIn = false;
                    var loggedIn = await _context.Employee.FirstOrDefaultAsync(e => e.EmployeeEmail == login.EmployeeEmail && e.Password == login.Password);
                    if (loggedIn == null)
                    {
                        login.isLoggedIn = false;
                        var errorResponse = _errorResponseService.CreateErrorResponse(400, "Username or password is incorrect");
                        return BadRequest(errorResponse);
                    }

                    login.isLoggedIn = true;
                    var response = new
                    {
                        Status = 200,
                        Message = "Logged in successful",
                        Data = new
                        {
                            login.EmployeeEmail,
                            login.isLoggedIn
                        }
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
    }
}
