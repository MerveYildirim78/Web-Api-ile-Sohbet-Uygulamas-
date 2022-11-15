using ChatApp.Business.Concrete;
using ChatApp.Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ChattApplication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupMemberController : ControllerBase
    {

        GroupMemberManager _groupMember;

        public GroupMemberController(GroupMemberManager groupMember)
        {
            _groupMember = groupMember;
        }
        [Route ("Add")]
        [HttpPost]
        public IActionResult Add([FromBody]GroupMemberDTO dto)
        {
            var result = _groupMember.Add (dto);
            if (result.Errors == null)
            {
                return Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
        [Route("Delete")]
        [HttpDelete]
        public IActionResult Delete([FromBody] GroupMemberDTO dto)
        {
            var result = _groupMember.Delete(dto);
            if (result.Errors == null)
            {
                return Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetList(int groupId)
        {
            var result = _groupMember.GetAll(groupId);
            if (result.Errors == null)
            {
                return Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
        [Route("Update")]
        [HttpPost]
        public IActionResult Update([FromBody] GroupMemberDTO dto)
        {
            var result = _groupMember.Update(dto);
            if (result.Errors == null)
            {
                Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
    }
}
