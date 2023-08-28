namespace API.Models
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);

        List<Employee> Get();

        void Delete(int id);

        Employee? FindById(int id);

    }

}
