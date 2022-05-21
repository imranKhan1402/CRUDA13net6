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

        public async Task<List<Department>> GetAllDepartments()
        {
            return await cardsDbContext.Departments.ToListAsync();
        }
    }
}
