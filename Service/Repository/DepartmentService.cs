using Microsoft.EntityFrameworkCore;
using Model.CardC;
using Model.Context;
using Newtonsoft.Json;
using Service.Interface;
using SideClass.HelpingClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class DepartmentService : IDepartmentService
    {
        SideHelper sideHelper = new SideHelper();
        private readonly CardsDbContext cardsDbContext;
        public DepartmentService(CardsDbContext _cardsDbContext)
        {
            cardsDbContext = _cardsDbContext;
        }

        public async Task<string> createDepartment(Department department)
        {
            cardsDbContext.Departments.Add(department);
            await cardsDbContext.SaveChangesAsync();
            //return await Task.FromResult(JsonConvert.SerializeObject(department));
            return await Task.FromResult(sideHelper.DepartmentObjectStringBuilder(department, "Created").Result.ToString());
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await cardsDbContext.Departments.ToListAsync();
        }

        public async Task<string> GetDepartmentByID(int id)
        {
            return await Task.FromResult(sideHelper.DepartmentObjectStringBuilder((cardsDbContext.Departments.FirstOrDefaultAsync(dept => dept.DepartmentId == id)).Result, "Success").Result.ToString());//cardsDbContext.Departments.FirstOrDefaultAsync(dept => dept.DepartmentId == id);
        }
    }
}
