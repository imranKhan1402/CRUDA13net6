using Manager.Interface;
using Manager.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Context;
using Newtonsoft.Json;
using Service.Interface;

namespace CRUDA13net6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ITAPIManager iTAPIManager;
        public CardsController(ITAPIManager _iTAPIManager)
        {
            iTAPIManager = _iTAPIManager;
        }

        //private readonly CardsDbContext cardsDbContext;

        //public CardsController(CardsDbContext _cardsDbContext)
        //{
        //    cardsDbContext = _cardsDbContext;
        //}
        //public ICardManager iCardManager = new CardManager(cardsDbContext);
        //All data
        [HttpGet]
        public async Task<IActionResult> getAllCards()
        {
            //var cards = await cardsDbContext.Cards.ToListAsync();
            return Ok(JsonConvert.SerializeObject(await iTAPIManager.GetAllCards()));
        }
        //[HttpGet]
        //public string GetAllEmployee()
        //{
        //    string result = string.Empty;
        //    try
        //    {

        //        var data = iCardManager.getAllCards();
        //        result = JsonConvert.SerializeObject(data);
        //    }
        //    catch (Exception ex)
        //    {

        //        result = ex.Message;
        //    }
        //    return result;
        //}


        //Get Card by ID
        //[HttpGet]
        //[Route("{id:guid}")]
        //[ActionName("getAllCardsById")]
        //public async Task<IActionResult> getAllCardsById([FromRoute] Guid id)
        //{
        //    var card = await cardsDbContext.Cards.FirstOrDefaultAsync(x => x.Id == id);
        //    if (card != null)
        //    {
        //        return Ok(JsonConvert.SerializeObject(card));
        //    }

        //    return NotFound("Card Not Found");
        //}

        ////Add Card
        //[HttpPost]
        //public async Task<IActionResult> addCard([FromBody] Card card)
        //{
        //    var exist = await cardsDbContext.Cards.FirstOrDefaultAsync(x => x.CardNumber == card.CardNumber);
        //    if(exist == null)
        //    {
        //        card.Id = Guid.NewGuid();
        //        await cardsDbContext.Cards.AddAsync(card);
        //        await cardsDbContext.SaveChangesAsync();
        //        return CreatedAtAction(nameof(getAllCardsById),new { id = card.Id },card);
        //    }
        //    return NotFound("Card Already Exists");
        //}


        ////Update Card
        //[HttpPut]
        //[Route("{id:guid}")]
        //public async Task<IActionResult> updateCard([FromRoute] Guid id, [FromBody] Card card)
        //{
        //    var exist = await cardsDbContext.Cards.FirstOrDefaultAsync(x => x.Id == id);
        //    if (exist != null)
        //    {
        //        exist.CardNumber = card.CardNumber;
        //        exist.CardHolderName = card.CardHolderName;
        //        exist.ExpiryYear = card.ExpiryYear;
        //        exist.ExpiryMonth = card.ExpiryMonth;
        //        exist.CVC   = card.CVC;
        //        await cardsDbContext.SaveChangesAsync();
        //        return Ok(JsonConvert.SerializeObject(exist));
        //    }
        //    return NotFound("Card Not Found");
        //}

        ////Delete Card
        //[HttpDelete]
        //[Route("{id:guid}")]
        //public async Task<IActionResult> deletCard([FromRoute] Guid id)
        //{
        //    var exist = await cardsDbContext.Cards.FirstOrDefaultAsync(x => x.Id == id);
        //    if (exist != null)
        //    {
        //        cardsDbContext.Cards.Remove(exist);
        //        await cardsDbContext.SaveChangesAsync();
        //        return Ok(JsonConvert.SerializeObject(exist));
        //    }
        //    return NotFound("Card Not Found");
        //}
    }
}
