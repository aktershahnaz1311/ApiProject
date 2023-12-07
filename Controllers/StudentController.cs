using DemoProject.DbCon;
using DemoProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly DemoProjectDbContext _context;


        public StudentController(DemoProjectDbContext context)
        {
            _context = context;
        }

        // Get : Api/Student
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()   //control dot on student to recognize
        {
            return await _context.Students   .ToListAsync();
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Student>>GetStudent(int id)
        {
            return await _context.Students.FindAsync(id);
        }


        [HttpPost]

        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.Id},student);


             
        }
        [HttpPut("{id:int}")]
        public  async Task<ActionResult<Student>> PutStudent(int id , Student student)
        {
            if( id !=student.Id)
            {
                return BadRequest();
            }
            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            } catch(DbUpdateConcurrencyException)
            {

                if(!StudentExist(id))
                {
                    return NotFound();
                }

                throw;
            }
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult>DeleteStudent(int id)
        {
            if(!StudentExist(id))
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);

             _context.Students.Remove(student);
            await _context.SaveChangesAsync();


            return NoContent();

        }

        private bool StudentExist(int id)
        {
            return _context.Students.Any(x => x.Id == id);

        }
            
    }

}

