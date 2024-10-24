using SchoolSystem.Models;
using SchoolSystem.Models.Entities;
using SchoolSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace SchoolSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        [HttpPost("AddSubject")]
        public IActionResult AddSubject(SubjectDTO subjDto)
        {
            try
            {
                string result = _subjectService.NewSubject(subjDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("SetSubjectToStudent/{studentId}")]
        public IActionResult SetSubjectToStudent(int studentId, int subjectId)
        {
            try
            {
                var result = _subjectService.Enrollment(studentId, subjectId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetSubjectStudents")]
        public IActionResult GetSubjectStudents()
        {
            var result = _subjectService.GetEnrolledStudents();
            return Ok(result);
        }
    }
}
