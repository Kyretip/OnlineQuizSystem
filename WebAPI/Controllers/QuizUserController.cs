using Business.Repository.Lesson;
using Business.Repository.Quiz;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizUserController : ControllerBase
    {
       private readonly IQuizUserService _quizUserService;

        public QuizUserController(IQuizUserService quizUserService)
        {
            _quizUserService = quizUserService;
        }

        [HttpPost("Add")]
        public IActionResult Add(QuizUser quizuser)
        {
            var result = _quizUserService.Add(quizuser);
            return (result.Success) ? Ok(result) : BadRequest(result);

        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _quizUserService.Delete(id);
            return (result.Success) ? Ok(result) : BadRequest(result);

        }

        [HttpPut("Update")]
        public IActionResult Update(QuizUser quizuser)
        {
            var result = _quizUserService.Update(quizuser);
            return (result.Success) ? Ok(result) : BadRequest(result);

        }

        [HttpPost("Addlist")]
        public IActionResult Addlist(List<QuizUser> userList)
        {
            var result = _quizUserService.AddList(userList);
            return (result.Success) ? Ok(result) : BadRequest(result);

        }


        [HttpPost("AddScore")]
        public IActionResult AddScore(QuizUser user, float score, bool success)
        {
            var result = _quizUserService.AddScore(user,score,success);
            return (result.Success) ? Ok(result) : BadRequest(result);

        }

        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            var result = _quizUserService.Get(id);
            return (result.Success) ? Ok(result) : BadRequest(result);

        }

        [HttpGet("GetAllByQuiz")]
        public IActionResult GetAllByQuiz(int id)
        {
            var result = _quizUserService.GetAllByQuiz(id);
            return (result.Success) ? Ok(result) : BadRequest(result);

        }

        [HttpPost("GetAllByUser")]
        public IActionResult GetAllByUser(int id)
        {
            var result = _quizUserService.GetAllByUser(id);
            return (result.Success) ? Ok(result) : BadRequest(result);

        }


        [HttpGet("GetAllByUserActive")]
        public IActionResult GetAllByUserActive(int id)
        {
            var result = _quizUserService.GetAllByUserActive(id);
            return (result.Success) ? Ok(result) : BadRequest(result);

        }

        [HttpGet("GetAllByUserNotActive")]
        public IActionResult GetAllByUserNotActive(int id)
        {
            var result = _quizUserService.GetAllByUserNotActive(id);
            return (result.Success) ? Ok(result) : BadRequest(result);

        }

        [HttpGet("GetAllQuizHistory")]
        public IActionResult GetAllQuizHistory(int id)
        {
            var result = _quizUserService.GettAllQuizHistory(id);
            return (result.Success) ? Ok(result) : BadRequest(result);

        }







    }
}
