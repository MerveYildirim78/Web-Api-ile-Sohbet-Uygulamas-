using ChatApp.Common.Dto;
using Microsoft.AspNetCore.Mvc;
using ChatApp.Business.Concrete;
using ChatApp.DataLayer.Entity;

namespace ChattApplication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        UserManager _userManager;

        public UserController(UserManager userManager)
        {
            _userManager = userManager;
        }


        [Route ("Add")]
        [HttpPost]
        public IActionResult Add([FromBody]UserDTO dto)
        {
            var result = _userManager.Add (dto);
            if (result.Errors == null)
            {
                return Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
        [Route("Delete")]
        [HttpDelete]
        public IActionResult Delete([FromBody] UserDTO dto)
        {
            var result = _userManager.Delete(dto);
            if (result.Errors == null)
            {
                return Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
        [Route("GetByID")]
        [HttpGet]
        public IActionResult GetByID(int id)
        {
            var result = _userManager.GetByID(id);
            if (result.Errors == null)
            {
                return Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
        [Route("GetByUsername")]
        [HttpGet]
        public IActionResult GetByUsername(string userName)
        {
            var result = _userManager.GetByUsername(userName);
            if (result.Errors == null)
            {
                return Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
        [Route("GetUsers")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            var result = _userManager.GetUsers();
            if (result.Errors == null)
            {
                return Ok((result.Value as List<User>)
                    .Select(x=> new UserDTO() { Email=x.Email, Name=x.Name}));
            }
            return NotFound(result.Errors);
        }
        [Route("Update")]
        [HttpPost]
        public IActionResult Update([FromBody] UserDTO dto)
        {
            var result = _userManager.Update(dto);
            if (result.Errors == null)
            {
                Ok(result.Value);
            }
            return NotFound(result.Errors);
        }


    }
}
