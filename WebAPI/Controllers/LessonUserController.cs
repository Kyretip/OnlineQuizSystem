using Business.Repository.Lesson;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonUserController : ControllerBase
    {
        ILessonUserService _lessonUserService;

        public LessonUserController(ILessonUserService lessonUserService)
        {
            _lessonUserService = lessonUserService;
        }

        [HttpPost("add")]
        public IActionResult Add(LessonUser lessonUser)
        {
            var result = _lessonUserService.Add(lessonUser);
            return (result.Success) ? Ok(result) : BadRequest(result);

        }
        [HttpPost("addall")]
        public IActionResult AddAll(List<LessonUser> userList)
        {
            var result = _lessonUserService.AddAll(userList);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _lessonUserService.Delete(id);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(LessonUser lessonUser)
        {
            var result = _lessonUserService.Update(lessonUser);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _lessonUserService.Get(id);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _lessonUserService.GetAll();
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
        [HttpGet("GetAllByLesson")]
        public IActionResult GetAllByLesson(int lessonId)
        {
            var result = _lessonUserService.GetAllByLesson(lessonId);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
        [HttpGet("GetAllByLessonActive")]
        public IActionResult GetAllByLessonActive(int lessonId)
        {
            var result = _lessonUserService.GetAllByLessonActive(lessonId);
            return (result.Success) ? Ok(result) : BadRequest(result);

        }
        [HttpGet("GetAllByLessonNotActive")]
        public IActionResult GetAllByLessonNotActive(int lessonId)
        {
            var result = _lessonUserService.GetAllByLessonNotActive(lessonId);
            return (result.Success) ? Ok(result) : BadRequest(result);

        }
        [HttpGet("GetAllByStudendId")]
        public IActionResult GetAllByStudendId(int studendId)
        {
            var result = _lessonUserService.GetAllByStudendId(studendId);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
    }
}
