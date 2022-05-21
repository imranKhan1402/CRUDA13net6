using Microsoft.EntityFrameworkCore;
using Model.CardC;
using Model.Context;
using Newtonsoft.Json;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class CardService : ICardService
    {
        private readonly CardsDbContext cardsDbContext;
        public CardService(CardsDbContext _cardsDbContext)
        {
            cardsDbContext = _cardsDbContext;
        }
        public async Task<List<Card>> getAllCards()
        {
            return await cardsDbContext.Cards.ToListAsync();
        }

        public Task<Card> getCardByID(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
