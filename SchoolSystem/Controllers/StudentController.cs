using SchoolSystem.Models;
using SchoolSystem.Models.Entities;
using SchoolSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SchoolSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;
        public StudentController(IStudentService _studentService)
        {
            studentService = _studentService;
        }

        [HttpPost("Regestration")]
        public IActionResult Regestration([FromForm]StudentDTO dto)
        {
            try
            {
                string result = studentService.StudentRegestration(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpDelete("DeleteStudent")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                string result = studentService.RemoveStudent(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateStudentName/{id}")]
        public IActionResult UpdateStudentName(int id, string NewName)
        {
            try
            {
                string result = studentService.UpdateSudentName(id, NewName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            try
            {
                var result = studentService.GetAllStudentsAndSubjects();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("StudentLogin")]
        public IActionResult StudentLogin(string userName, string password)
        {
            try
            {
                var result = studentService.StudentLogin(userName, password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
