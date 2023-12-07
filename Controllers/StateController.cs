using DemoProject.DbCon;
using DemoProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly DemoProjectDbContext _context; //generate Constructor from Ctrl dot

       
        public object StateExist { get; private set; }


        public StateController(DemoProjectDbContext context)
        {
            _context = context;
        }

        // GET: api/<StateController>
        [HttpGet]
        public ActionResult <IEnumerable<State>> Get()
        {
          //  return _context.States.ToList();
            return   _context.States.Include(x=>x.Country).ToList();
        }

        // GET api/<StateController>/5
        [HttpGet("{id}")]
        public ActionResult<State> Get(int id)
        {
           // return _context.States.Find(id);
            return _context.States.Where(x=>x.Id==id).Include(x=>x.Country).FirstOrDefault();
        }

        // POST api/<StateController>
        [HttpPost]
        public ActionResult<State> Post([FromBody] State state)
        {
            _context.States.Add(state);
            _context.SaveChanges();
            return Ok(state);



        }

        // PUT api/<StateController>/5
        [HttpPut("{id}")]
        public ActionResult<State> Put(int id, [FromBody] State state)
        {
            var _state = _context.States.Find(id);

            if(_state == null)
            {
                return NotFound();

            }

            _state.Name = state.Name;
            _state.CountryId = state.CountryId;
            _state.updateDate = DateTime.UtcNow;
            _state.UpdateBy = 1;

            _context.Update(_state);
            _context.SaveChanges();
            return Ok(state);






            /*
             
            if(id != state.Id)
            {
                return BadRequest();
            }
            _context.Entry(state).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException){
                if(!StateExists(id) ) //generate varibale > generate property
                {
                    return NotFound();
                }
            }
            return Ok(state);

            */
        }

        

        // DELETE api/<StateController>/5
        [HttpDelete("{id}")]
        public ActionResult<State> Delete(int id)
        {
            var state = _context.States.Find(id);

            if(state != null)
            {
                _context.Remove(state);
                _context.SaveChanges();
                return Ok(state);
            }

            return NotFound();
        }


        private bool StateExists(int id)
        {
            return _context.States.Any(x => x.Id == id);
        }
    }
}
