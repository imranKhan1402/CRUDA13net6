using Microsoft.EntityFrameworkCore;
using Model.CardC;
using Model.Context;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class DepartmentService : IDepartmentService
    {
        private readonly CardsDbContext cardsDbContext;
        public DepartmentService(CardsDbContext _cardsDbContext)
        {
            cardsDbContext = _cardsDbContext;
        }

        public async Task<Department> createDepartment(Department department)
        {
            cardsDbContext.Departments.Add(department);
            await cardsDbContext.SaveChangesAsync();
            return department;
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await cardsDbContext.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentByID(int id)
        {
            return await cardsDbContext.Departments.FirstOrDefaultAsync(dept => dept.DepartmentId == id);
        }
    }
}
