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
    public class RDepartment : Repository<Department>, IDepartment
    {
        private readonly CardsDbContext cardsDbContext;
        public RDepartment(CardsDbContext _cardsDbContext) : base(_cardsDbContext)
        {
            cardsDbContext = _cardsDbContext;
        }
        

        public void Update(Department department)
        {
            cardsDbContext.Update(department);
        }
    }
}
