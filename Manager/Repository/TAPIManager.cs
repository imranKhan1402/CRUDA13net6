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
        private readonly IEmployeeService iEmployeeService;
        private readonly IUnitOfWork iUnitOfWork;
        private readonly CardsDbContext cardsDbContext;
        public TAPIManager(CardsDbContext _cardsDbContext, IUnitOfWork _iUnitOfWork)
        {
            cardsDbContext = _cardsDbContext;
            iEmployeeService = new EmployeeService(cardsDbContext);
            iUnitOfWork = _iUnitOfWork;
        }
        public async Task<string> createDepartment(Department department)
        {
            try
            {
                //var fetchData = cardsDbContext.Departments.FirstOrDefaultAsync(dept => dept.DepartmentName == department.DepartmentName);
                var fetchData = await iUnitOfWork.department.GetFirstOrDefault(dept => dept.DepartmentName == department.DepartmentName);
                if (fetchData == null)
                {
                    //return await iDepartmentService.createDepartment(department);
                    iUnitOfWork.department.Add(department);
                    iUnitOfWork.Save();
                    //return "Created Successfully";
                    return await Task.FromResult(sideHelper.DepartmentObjectStringBuilder(department, "Created").Result.ToString());
                }
                return await Task.FromResult(sideHelper.DepartmentObjectStringBuilder(fetchData, "Exists").Result.ToString());
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
            return await iUnitOfWork.department.GetAll();
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await iUnitOfWork.employee.GetAll();
            //return await iEmployeeService.GetAllEmployees();
        }

        public async Task<string> GetDepartmentByID(int id)
        {
            var data = await iUnitOfWork.department.GetFirstOrDefault(dept => dept.DepartmentId == id);
            if(data != null)
            {
                return await Task.FromResult(sideHelper.DepartmentObjectStringBuilder(data, "Department Found").Result.ToString());
            }
            return await Task.FromResult("Department Not Found");
        }

        public Task<Employee> GetEmployeeByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> deleteDepartment(int ID)
        {
            var data = await iUnitOfWork.department.GetFirstOrDefault(dept => dept.DepartmentId == ID);
            if (data != null)
            {
                iUnitOfWork.department.Remove(data);
                iUnitOfWork.Save();
                return await Task.FromResult("Department Deleted Successfully");
            }
            return await Task.FromResult("Department Not Found");
        }

        public async Task<List<Card>> GetAllCards()
        {
            return await iUnitOfWork.card.GetAll();
        }
    }
}
