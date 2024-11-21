using DotNetCoreApplication.Data;
using DotNetCoreApplication.Interfaces;
using DotNetCoreApplication.Models;

namespace DotNetCoreApplication.Repository
{
    public class EmployeeRepo : IEmployee
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Employee> GetAllEmployee()
        {
            return _context.Employee.ToList();
        }

        public Employee GetEmployee(int id)
        {
            return _context.Employee.FirstOrDefault(x => x.ID == id);
        }
    }
}
