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
        private readonly ILogger<FoodController> _logger;
        private readonly IContext _context;

        public FoodController(IContext context, ILogger<FoodController> logger)
        {
            _context = context;
            _logger = logger;
        }


            // GET: api/<FoodController>
            [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FoodController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetOne(int id)
        {
            _logger.LogInformation("api/food/{id} triggered");

            var item = await _context.GetFoodById(id);

            if (item == null) return NotFound();

            return item;
        }

        // POST api/<FoodController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FoodController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FoodController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
