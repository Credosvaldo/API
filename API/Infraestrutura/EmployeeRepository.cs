using API.Models;
using System.Runtime.InteropServices;

namespace API.Infraestrutura
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContex _contex = new ConnectionContex();

        public void Add(Employee employee)
        {
            _contex.Employees.Add(employee);
            _contex.SaveChanges();
        }

        public void Delete(int id)
        {
            Employee e = FindById(id);
            _contex.Employees.Remove(e);
            _contex.SaveChanges();
        }

        public List<Employee> Get()
        {
            return _contex.Employees.ToList();
        }

        public Employee? FindById(int id)
        {
            return _contex.Employees.Find(id);
        }

    }
}
