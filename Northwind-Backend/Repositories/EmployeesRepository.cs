namespace Northwind_Backend.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly DataContext _dataContext;

        public EmployeesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            _dataContext.Employees.Add(employee);
            if (await _dataContext.SaveChangesAsync() > 0)
            {
                var id = employee.Id;
                return await _dataContext.Employees.FindAsync(id);
            }
            return null;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _dataContext.Employees.FindAsync(id);
            if (employee != null)
                _dataContext.Employees.Remove(employee);
            else
                return false;

            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _dataContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _dataContext.Employees.FindAsync(id);
            if (employee == null)
                return null;

            return employee;
        }

        public async Task<bool> UpdateEmployeeAsync(int id, Employee newEmployee)
        {
            var employee = await _dataContext.Employees.FindAsync(id);

            if (employee == null)
                return false;
            employee.BirthDate = newEmployee.BirthDate;
            employee.Firstname = newEmployee.Firstname;
            employee.Lastname = newEmployee.Lastname;
            employee.City = newEmployee.City;
            employee.Country = newEmployee.Country;
            employee.Title = newEmployee.Title;
            if(newEmployee.ImageName != "")
                employee.ImageName = newEmployee.ImageName;

            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
