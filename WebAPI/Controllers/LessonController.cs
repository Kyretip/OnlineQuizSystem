using Business.Repository.Lesson;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
       ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        [HttpPost("add")]
        public IActionResult Add(Entities.Concrete.Lesson lesson){ 
            var result = _lessonService.Add(lesson);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _lessonService.Delete(id);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Entities.Concrete.Lesson lesson)
        {
            var result = _lessonService.Update(lesson);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _lessonService.Get(id);
            return (result.Success) ? Ok(result) : BadRequest(result);

        }
        [HttpGet("getall")]
        public IActionResult getall()
        {
            var result = _lessonService.GetAll(); 
            return (result.Success) ? Ok(result) : BadRequest(result);

        }

        [HttpGet("getallbyuser")]
        public IActionResult getallByUser(int userId)
        {
            var result = _lessonService.GetAllByUser(userId);
            return (result.Success) ? Ok(result) : BadRequest(result);

        }

        [HttpGet("getforteacher")]
        public IActionResult getforteacher(int userId)
        {
            var result = _lessonService.GetForTeacher(userId);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }

    }
}
