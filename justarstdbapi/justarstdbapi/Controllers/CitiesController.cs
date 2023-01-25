using Microsoft.AspNetCore.Mvc;
using rsntdb.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rsntdb.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IContext _context;

        public CitiesController(IContext context)
        {
            _context = context;
        }

        // GET: api/<CitiesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAll()
        {
            IEnumerable<string> citylist = await _context.GetCities();

            if (citylist == null) return NotFound();

            return citylist.ToList();
        }

        /*
        // GET api/<CitiesController>/city
        [HttpGet("{cityname}")]
        public string Get(string cityname)
        {
            return "value";
        }
        */

        // POST api/<CitiesController>
        [HttpPost]
        public void Post([FromBody] string cityname)
        {
            _context.AddNewCity(cityname);
        }

    }
}
