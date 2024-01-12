using Business.Repository.User;
using Business.Results.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        IUserTypeService _userTypeService;
        public UserTypeController(IUserTypeService userTypeService)
        {
            _userTypeService = userTypeService;
        }
        [HttpPost("add")]
        public ActionResult Add(UserType userType) {
           var result = _userTypeService.Add(userType);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("delete")]
        public ActionResult Delete(int UserTypeId) {
            var result = _userTypeService.Delete(UserTypeId);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
        [HttpPut("update")]
        public ActionResult Update(UserType userType) {
            var result = _userTypeService.Update(userType);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
        [HttpGet("get")]
        public ActionResult Get(int id){
            var result = _userTypeService.Get(id);
            return (result.Success)? Ok(result) : BadRequest(result);
          }
        [HttpGet("getAll")]
        public ActionResult GetAll()
        {
            var result = _userTypeService.GetAll();
            return (result.Success) ? Ok(result) : BadRequest(result);
        }


    }
}
