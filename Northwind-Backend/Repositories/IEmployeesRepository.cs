namespace Northwind_Backend.Repositories
{
    public interface IEmployeesRepository
    {
        Task<ActionResult<IEnumerable<Employee>>> GetAllEmployeesAsync();
        Task<ActionResult<Employee>> GetEmployeeByIdAsync(int id);
        Task<ActionResult> AddEmloyeeAsync(Employee employee);
        Task<ActionResult> UpdateEmployeeAsync (Employee employee);
        Task<ActionResult> DeleteEmployeeByIdAsync(int id);

    }
}
