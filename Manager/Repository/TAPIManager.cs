using Manager.Interface;
using Microsoft.EntityFrameworkCore;
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
        public async Task<Department> createDepartment(Department department)
        {
            var exist = cardsDbContext.Departments.FirstOrDefaultAsync(dept => dept.DepartmentName == department.DepartmentName);
            if (exist.Result == null)
            {
                return await iDepartmentService.createDepartment(department);
            }
            return await exist;
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

        public async Task<Department> GetDepartmentByID(int id)
        {
            return await iDepartmentService.GetDepartmentByID(id);
        }

        public Task<Employee> GetEmployeeByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
