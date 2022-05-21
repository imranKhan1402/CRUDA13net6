using Manager.Interface;
using Model.CardC;
using Model.Context;
using Service.Interface;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Repository
{
    public class CardManager : ICardManager
    {
        private readonly ICardService iCardService;
        private readonly CardsDbContext cardsDbContext;
        public CardManager(CardsDbContext _cardsDbContext)
        {
            cardsDbContext = _cardsDbContext;
            iCardService = new CardService(cardsDbContext);
        }
        public async Task<List<Card>> getAllCards()
        {
            return await iCardService.getAllCards();
        }
    }
}
