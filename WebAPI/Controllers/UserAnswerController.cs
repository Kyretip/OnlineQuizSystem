using Business.Repository.Question;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAnswerController : ControllerBase
    {
        IUserAnswerService _userAnswerService;
        public UserAnswerController(IUserAnswerService userAnswerService)
        {
            _userAnswerService = userAnswerService;
        }

        [HttpPost("Add")]
        public IActionResult Add(UserAnswer userAnswer)
        {
            var result = _userAnswerService.Add(userAnswer);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _userAnswerService.Delete(id);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }


        [HttpPut("updateByTeacher")]
        public IActionResult updateByTeacher(UserAnswer userAnswer)
        {
            var result = _userAnswerService.updateByTeacher(userAnswer);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }

        [HttpPut("updateByStudent")]
        public IActionResult updateByStudent(UserAnswer userAnswer)
        {
            var result = _userAnswerService.updateByStudent(userAnswer);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllByUserId")]
        public IActionResult GetAllByUserID(int userID, int QuizId)
        {
            var result = _userAnswerService.GetAllByUserId(userID,QuizId);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }


    }
}
