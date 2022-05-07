namespace Northwind_Backend.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeeController(IEmployeesRepository employeesRepository) 
        {
            _employeesRepository = employeesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            try
            {
                var employess = await _employeesRepository.GetAllEmployeesAsync();
                if (employess.Count() == 0)
                    return Ok("no Employees available");
                return Ok(employess);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _employeesRepository.GetEmployeeByIdAsync(id);
                if (employee == null)
                    return BadRequest("Employee doesn't exist");
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            try
            {
                var addedEmployee = await _employeesRepository.AddEmployeeAsync(employee);
                if (addedEmployee == null)
                    return BadRequest("try again");
                return Ok(addedEmployee);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                var updated = await _employeesRepository.UpdateEmployeeAsync(id, employee);
                if (!updated)
                    return BadRequest("unable to update employee");
                return Ok(await _employeesRepository.GetEmployeeByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                var prod = await _employeesRepository.DeleteEmployeeAsync(id);
                if (prod)
                    return Ok($"employee with {id} deleted successfully");
                return BadRequest($"Problem deleting Employee with id {id}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
