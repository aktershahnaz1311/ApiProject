using DemoProject.DbCon;
using DemoProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly DemoProjectDbContext _context;

        public CountryController(DemoProjectDbContext context)
        {
            _context = context;
        }

        // Get : Api/county
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Country>>> GetCountys()   //control dot on student to recognize
        {
             return await _context.Countrys.ToListAsync();
           
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            return await _context.Countrys.FindAsync(id);
        }


        [HttpPost]

        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            _context.Countrys.Add(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);


        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Country>> PutCountry(int id, Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }
            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!CountryExist(id))
                {
                    return NotFound();
                }

                throw;
            }
            return NoContent();
        }

        


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Country(int id)
        {


            if (!CountryExist(id))
            {
                return NotFound();
            }

            var country = await _context.Countrys.FindAsync(id);

            _context.Countrys.Remove(country);
            await _context.SaveChangesAsync();


            return NoContent();

        }

        private bool CountryExist(int id)
        {
            return _context.Countrys.Any(x => x.Id == id);

        }




    }
}
