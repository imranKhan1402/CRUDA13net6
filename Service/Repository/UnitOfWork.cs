using Model.Context;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CardsDbContext cardsDbContext;
        public UnitOfWork(CardsDbContext _cardsDbContext) 
        {
            cardsDbContext = _cardsDbContext;
            department = new RDepartment(cardsDbContext);
            employee = new REmployee(cardsDbContext);
            card = new RCard(cardsDbContext);

        }
        public IDepartment department { get; private set; }

        public IEmployee employee { get; private set; }

        public ICard card { get; private set; }

        public void Save()
        {
            cardsDbContext.SaveChanges();
        }
    }
}
