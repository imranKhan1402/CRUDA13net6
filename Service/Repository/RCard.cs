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
    public class RCard : Repository<Card>, ICard
    {
        private readonly CardsDbContext cardsDbContext;
        public RCard(CardsDbContext _cardsDbContext) : base(_cardsDbContext)
        {
            cardsDbContext = _cardsDbContext;   
        }

        public void Update(Card card)
        {
            cardsDbContext.Update(card);
        }
    }
}
