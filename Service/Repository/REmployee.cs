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
    public class REmployee : Repository<Employee>, IEmployee
    {
        private readonly CardsDbContext cardsDbContext;
        public REmployee(CardsDbContext _cardsDbContext) : base(_cardsDbContext)
        {
            cardsDbContext = _cardsDbContext;
        }

        public void Update(Employee employee)
        {
            cardsDbContext.Update(employee);
        }
    }
}
