using ChatApp.Business.Concrete;
using ChatApp.Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ChattApplication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        GroupManager _groupManager;

        public GroupController(GroupManager groupManager)
        {
            _groupManager = groupManager;
        }
        [Route("GetGroup")]
        [HttpGet]
        public IActionResult GetGroup(int groupID)
        {
            var result = _groupManager.GetList(groupID);
            if (result.Errors == null)
            {
                return Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
        [Route("Add")]
        [HttpPost]
        public IActionResult Add([FromBody] GroupDTO dto)
        {
            var result = _groupManager.Add(dto);
            if (result.Errors == null)
            {
                return Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
        [Route("Delete")]
        [HttpDelete]
        public IActionResult Delete([FromBody] GroupDTO dto)
        {
            var result = _groupManager.Delete(dto);
            if (result.Errors == null)
            {
                return Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
        [Route("Update")]
        [HttpPost]
        public IActionResult Update([FromBody] GroupDTO dto)
        {
            var result = _groupManager.Update(dto);
            if (result.Errors == null)
            {
                Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
    }
}
