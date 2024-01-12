using Business.Repository.User;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("add")]
        public IActionResult Add(Entities.Concrete.User user)
        {
          var result =  _userService.Add(user);
          return (result.Success) ? Ok(result) : BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Entities.Concrete.User user)
        {
            var result = _userService.Delete(user);
            return (result.Success) ? Ok(result) : BadRequest(result);

        }
        [HttpPut("update")]
        public IActionResult Update(Entities.Concrete.User user)
        {
            var result = _userService.Update(user);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _userService.Get(id);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll(int id)
        {
            var result = _userService.GetAll();
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
    }
}
