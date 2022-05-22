using Manager.Interface;
using Microsoft.EntityFrameworkCore;
using Model.CardC;
using Model.Context;
using Newtonsoft.Json;
using Service.Interface;
using Service.Repository;
using SideClass.HelpingClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Repository
{
    public class TAPIManager : ITAPIManager
    { 
        SideHelper sideHelper = new SideHelper();
        private readonly IDepartmentService iDepartmentService;
        private readonly IEmployeeService iEmployeeService;
        private readonly CardsDbContext cardsDbContext;
        public TAPIManager(CardsDbContext _cardsDbContext)
        {
            cardsDbContext = _cardsDbContext;
            iDepartmentService = new DepartmentService(cardsDbContext);
            iEmployeeService = new EmployeeService(cardsDbContext);
        }
        public async Task<string> createDepartment(Department department)
        {
            try
            {
                var fetchData = cardsDbContext.Departments.FirstOrDefaultAsync(dept => dept.DepartmentName == department.DepartmentName);
                if (fetchData.Result == null)
                {
                    return await iDepartmentService.createDepartment(department);
                }
                return await Task.FromResult(sideHelper.DepartmentObjectStringBuilder(fetchData.Result, "Exists").Result.ToString());
            }
            catch (Exception ex)
            {

                return await Task.FromResult(ex.ToString());
            }
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
