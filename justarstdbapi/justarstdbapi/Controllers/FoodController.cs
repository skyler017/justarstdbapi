using Microsoft.AspNetCore.Mvc;
using rsntdb.Data;
using rsntdb.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rsntdb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IContext _context;

        public FoodController(IContext context)
        {
            _context = context;
        }

        // GET: api/<FoodController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodDTO>>> GetAll()
        {
            IEnumerable<FoodDTO> foods = await _context.GetAllFood();

            if (foods == null)
            {
                return NotFound();
            }

            return foods.ToList();
        }

        // GET api/<FoodController>/name
        [HttpGet("{foodname}")]
        public async Task<ActionResult<FoodDTO>> GetOne(string foodname)
        {
            var item = await _context.GetFoodByName(foodname);

            if (item == null) return NotFound();

            return item;
        }

        // POST api/<FoodController>
        [HttpPost]
        public void Post([FromBody] FoodDTO f)
        {
            _context.AddNewFood(f);
        }
/*
        // PUT api/<FoodController>/name
        [HttpPut("{foodname}")]
        public void Put(string foodname, [FromBody] FoodDTO f)
        {
            _context.UpdateFood(foodname, f);
        }

        // DELETE api/<FoodController>/name
        [HttpDelete("{foodname}")]
        public void Delete(string foodname)
        {
            _context.RemoveFood(foodname);
        }
*/
    }
}
