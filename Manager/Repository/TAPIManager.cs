using Manager.Interface;
using Model.CardC;
using Model.Context;
using Service.Interface;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Repository
{
    public class TAPIManager : ITAPIManager
    {
        private readonly IDepartmentService iDepartmentService;
        private readonly IEmployeeService iEmployeeService;
        private readonly CardsDbContext cardsDbContext;
        public TAPIManager(CardsDbContext _cardsDbContext)
        {
            cardsDbContext = _cardsDbContext;
            iDepartmentService = new DepartmentService(cardsDbContext);
            iEmployeeService = new EmployeeService(cardsDbContext);
        }
        public Task<Department> createDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> createEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await iDepartmentService.GetAllDepartments();
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await iEmployeeService.GetAllEmployees();
        }

        public Task<Department> GetDepartmentByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
