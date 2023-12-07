using DemoProject.DbCon;
using DemoProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly DemoProjectDbContext _context;
        public object CityExist { get; private set; }
        

        // GET: api/<CityController>

        public CityController(DemoProjectDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<City>> Get() 
        {
          //  return _context.Cities.ToList();

          return _context.Cities.Include(x=>x.State).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<City> Get(int id)
        {
            // return _context.Cities.Find(id);

            return _context.Cities.Where(x => x.Id == id).Include(x => x.State).FirstOrDefault();
        }

        // POST api/<CityController>
        [HttpPost]
        public ActionResult<City> Post([FromBody] City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
            return Ok(city);



        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public ActionResult<City> Put(int id, [FromBody] City city)
        {
            if (id != city.Id)
            {
                return BadRequest();
            }
            _context.Entry(city).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id)) //generate varibale > generate property
                {
                    return NotFound();
                }
            }
            return Ok(city);
        }

     
        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public ActionResult<City> Delete(int id)
        {
            var city = _context.Cities.Find(id);

            if (city != null)
            {
                _context.Remove(city);
                _context.SaveChanges();
                return Ok(city);
            }

            return NotFound();
        }

        private bool CityExists(int id)
        {
            return _context.States.Any(x => x.Id == id);
        }



    }
}
