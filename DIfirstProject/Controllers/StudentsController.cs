using DIfirstProject.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DIfirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudents _students;

        public StudentsController(IStudents students)
        {
            _students = students;
        }

             // GET //    

        [HttpGet("All Students")]
        public ActionResult Get() 
        {
            return Ok(_students.GetStudents());
        }

        [HttpGet("Students By Id")]
        public ActionResult Get(int id)
        {
            try
            {
                if(_students.GetStudentById(id) != null)
                {
                    return Ok(_students.GetStudentById(id));
                }
                else
                {
                    return StatusCode(404);
                }

            }catch
            {
                return StatusCode(500);
            }
        }

            // POST //

        [HttpPost("Add Student")]
        public ActionResult ADDstdnt([FromBody]Students student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    student.Id = _students.GetStudents().Count + 1;
                    _students.AddStudent(student);

                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
                
            }
            catch
            {
                return StatusCode(500);
            }
           
        }

           // PUT //
           
        [HttpPut("UPDATE")]
        public ActionResult Updatestdnt( int id ,[FromBody] Students student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _students.UpdateStudent(id, student);
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
                
            }
            catch
            {
                return StatusCode(500);
            }
            
        }
        // DELETE //

        [HttpDelete("DELETE")]
        public ActionResult Delete(int id)
        {
            try
            {
                _students.DeleteStudent(id);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
            
        }
        
    }
}
