using Business.Repository.Question;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Answer answer)
        {
            var result = _answerService.Add(answer);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _answerService.Delete(id);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(Answer answer)
        {
            var result = _answerService.Update(answer);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }


        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            var result = _answerService.Get(id);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll(int questionId)
        {
            var result = _answerService.GetAll(questionId);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }








    }
}
