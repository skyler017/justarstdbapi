using Microsoft.AspNetCore.Mvc;
using rsntdb.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rsntdb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuisineController : ControllerBase
    {
        private readonly IContext _context;

        public CuisineController(IContext context)
        {
            _context = context;
        }

        // GET: api/<CuisineController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetCuisine()
        {
            IEnumerable<string> cuislist = await _context.GetCuisines();

            if (cuislist == null) return NotFound();

            return cuislist.ToList();
        }

        // GET api/<CuisineController>/name
        [HttpGet("{cuisine}")]
        public async Task<ActionResult<IEnumerable<string>>> GetFoodsOfCuisine(string cuisine)
        {
            IEnumerable<string> foods = await _context.GetFoodByCuisine(cuisine);

            if (foods == null) return NotFound();

            return foods.ToList();
        }

        // POST api/<CuisineController>
        [HttpPost]
        public void Post([FromBody] string cuisinename)
        {
            _context.AddNewCuisine(cuisinename);
        }
    }
}
