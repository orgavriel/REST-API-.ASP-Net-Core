using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GradesAPI.Data;
using GradesAPI.Models;




namespace GradesAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private GradesDbContext _gradesDbContext;

        public GradesController(GradesDbContext gradesDbContext)
        {
            _gradesDbContext = gradesDbContext;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get(string sort)
        {
            IQueryable<Grades> grades;

            switch (sort)
            {
                case "desc": //sort by user id Desc
                    grades = _gradesDbContext.Grades.OrderByDescending(q => q.StudentName);
                    break;
                case "asc": //sort by user id Asc
                    grades = _gradesDbContext.Grades.OrderBy(q => q.StudentName);
                    break;
                default:
                    grades = _gradesDbContext.Grades;
                    break;
            }

            return Ok(_gradesDbContext.Grades);
        }

        [HttpGet]
        [Route("api/[controller]/{grade}")]
        public IActionResult Get(int grade)
        {
           var grades = _gradesDbContext.Grades.Where(x=>x.Grade>= grade);

            if (grades != null)
            {
                return Ok(grades);
            }

            return NotFound("No record found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Post([FromBody] Grades grades)
        {
            _gradesDbContext.Add(grades);
            _gradesDbContext.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult Put(int id, [FromBody] Grades grades)
        {
            var grade = _gradesDbContext.Grades.Find(id);

            if (grade != null)
            {
                grade.Grade = grades.Grade;
                grade.Course = grades.Course;
                _gradesDbContext.SaveChanges();
                return Ok("Updated successfully");
            }

            return NotFound("No record found");
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult Delete(int id)
        {
            var grade = _gradesDbContext.Grades.Find(id);

            if (grade != null)
            {
                _gradesDbContext.Grades.Remove(grade);
                _gradesDbContext.SaveChanges();
                return Ok("Deleted successfully");
            }

            return NotFound("No record found");
        }
    }
}
