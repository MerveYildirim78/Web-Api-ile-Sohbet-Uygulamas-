using ChatApp.Business.Concrete;
using ChatApp.Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ChattApplication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FriendController : ControllerBase
    {

        FriendManager _friendManager;

        public FriendController(FriendManager friendManager)
        {
            _friendManager = friendManager;
        }
        [Route("Add")]
        [HttpPost]
        public IActionResult Add([FromBody] FriendDTO dto)
        {
            var result = _friendManager.Add(dto);
            if (result.Errors == null)
            {
                Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
        [Route("Delete")]
        [HttpDelete]
        public IActionResult Delete([FromBody] FriendDTO dto)
        {
            var result = _friendManager.Delete(dto);
            if (result.Errors == null)
            {
                return Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
        [Route("GetList")]
        [HttpGet]
        public IActionResult GetList(int requestedid)
        {
            var result = _friendManager.GetList(requestedid);
            if (result.Errors == null)
            {
                return Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
        [Route("GetFriends")]
        [HttpGet]
        public IActionResult GetFriends()
        {
            var result = _friendManager.GetFriends();
            if (result.Errors == null)
            {
                return Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
    }
}
