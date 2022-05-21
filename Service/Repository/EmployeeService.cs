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
    public class EmployeeService : IEmployeeService
    {
        private readonly CardsDbContext cardsDbContext;
        public EmployeeService(CardsDbContext _cardsDbContext)
        {
            cardsDbContext = _cardsDbContext;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await cardsDbContext.Employees.ToListAsync();
        }
    }
}
