using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Price.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PriceController : ControllerBase
    {

        private readonly PriceContext db;

        public PriceController(PriceContext context)
        {
            db = context;
        }


        //[HttpGet(Name = "GETPrice")]
        //public List<Price> GETPrice(string name,int sum)
        //{
        //    List<Price> resultDBPrice = db.Prices.Where(x => x.Name == name && x.Price1 > sum).ToList();

        //    return resultDBPrice;

        //}


        [HttpGet(Name = "GETPrice")]
        public Price GETPrice(int price_id)
        {
            Price resultDBPrice = db.Prices.Where(x => x.PriceId == price_id ).First();

            return resultDBPrice;
        }

    }
}
