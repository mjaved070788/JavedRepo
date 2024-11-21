using DotNetCoreApplication.Models;

namespace DotNetCoreApplication.Interfaces
{
    public interface IEmployee
    {
        List<Employee> GetAllEmployee();

        Employee GetEmployee(int id);
    }
}
