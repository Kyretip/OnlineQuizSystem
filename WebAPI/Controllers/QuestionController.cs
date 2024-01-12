using Business.Repository.Question;
using Business.Repository.Quiz;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        [HttpPost("Add")]
        public IActionResult Add(Question question)
        {
            var result = _questionService.Add(question);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _questionService.Delete(id);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(Question question)
        {
            var result = _questionService.update(question);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }

        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            var result = _questionService.Get(id);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllByQuiz")]
        public IActionResult GetAllByQuiz(int Quizid)
        {
            var result = _questionService.GetAllByQuiz(Quizid);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }



    }
}
