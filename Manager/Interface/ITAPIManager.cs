using Model.CardC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Interface
{
    public interface ITAPIManager
    {
        Task<List<Department>> GetAllDepartments();
        Task<string> GetDepartmentByID(int id);
        Task<string> createDepartment(Department department);
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeByID(int id);
        Task<Employee> createEmployee(Employee employee);
    }
}
