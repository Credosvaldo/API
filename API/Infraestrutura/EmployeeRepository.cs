using API.Models;

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

        public List<Employee> Get()
        {
            return _contex.Employees.ToList();
        }
    }
}
