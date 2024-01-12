using Business.Repository.Quiz;
using Business.Results.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }
        [HttpPost("Add")]
        public IActionResult Add(Entities.Concrete.Quiz quiz)
        {
            var result = _quizService.Add(quiz);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult delete(int id)
        {
            var result = _quizService.Delete(id);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
        [HttpPut("Update")]
        public IActionResult Update(Entities.Concrete.Quiz quiz)
        {
            var result = _quizService.Update(quiz);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _quizService.Get(id);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
        [HttpGet("GetAllbyUser")]
        public IActionResult GetAllbyUser(int UserId)
        {
            var result = _quizService.GetAllbyUser(UserId);
            return (result.Success) ? Ok(result) : BadRequest(result);

        }
        [HttpGet("GetByLessonandUserId")]
        public IActionResult GetByLessonandUserId(int userId)
        {
            var result = _quizService.GetByLessonandUserId(userId);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
        [HttpPost("GetFullQuizByQuizUser")]
        public IActionResult GetFullQuizByQuizUser([FromBody] QuizHomeDto quizHomeDto)
        {
            
            var result = _quizService.GetFullQuizByQuizUser(quizHomeDto);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
        [HttpPost("GetFullUserQuizForStudent")]
        public IActionResult GetFullUserQuizForStudent(QuizUser quizUser)
        {
            var result = _quizService.GetFullUserQuizForStudent(quizUser);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }

        
    }
}
