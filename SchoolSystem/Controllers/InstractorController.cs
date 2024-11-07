using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Models.Entities;
using SchoolSystem.Services;

namespace SchoolSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstractorController : ControllerBase
    {
        private readonly IInstractorService _instractorService;
        public InstractorController(IInstractorService instractorService)
        {
            _instractorService = instractorService;
        }

        [HttpPost("Regestration")]
        public IActionResult Regestration([FromForm] InstractorDto dto)
        {
            try
            {
                string result = _instractorService.InstractorRegestration(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("DeleteInstractor")]
        public IActionResult DeleteInstractor(int id)
        {
            try
            {
                string result = _instractorService.RemoveInstractor(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateInstractorData/{id}")]
        public IActionResult UpdateInstractorData(int id, [FromForm] InstractorDto instractorDto)
        {
            try
            {
                string result = _instractorService.UpdateInstractorData(id, instractorDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllInstractors")]
        public IActionResult GetAllInstractors()
        {
            try
            {
                var result = _instractorService.GetAllInstractorsAndSubjects();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddInstractorStudent")]
        public IActionResult AddInstractorStudent([FromQuery] int instractorId, [FromQuery] int studentId)
        {
            try
            {
                _instractorService.AddStudentInstractor(studentId,instractorId);
                return Ok("Sutdent Set Successfully, try getAll to check!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
