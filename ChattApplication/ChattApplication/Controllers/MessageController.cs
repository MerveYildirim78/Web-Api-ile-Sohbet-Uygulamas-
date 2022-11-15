using ChatApp.Business.Concrete;
using ChatApp.Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ChattApplication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        MessageManager _messageManager;

        public MessageController(MessageManager messageManager)
        {
            _messageManager = messageManager;
        }

        [Route("SendMessage")]
        [HttpPost]
        public IActionResult SendMessage([FromBody] MessageDTO dto)
        {
            var result = _messageManager.SendMessage(dto);
            if (result.Errors == null)
            {
                return Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
        [Route("Delete")]
        [HttpDelete]
        public IActionResult Delete([FromBody] MessageDTO dto)
        {
            var result = _messageManager.Delete(dto);
            if (result.Errors == null)
            {
                return Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
        [Route("GetPrivateMessage")]
        [HttpGet]
        public IActionResult GetPrivateMessage(int senderId,int receiverId)
        {
            var result = _messageManager.GetPrivateMessage(senderId, receiverId);
            if (result.Errors == null)
            {
                return Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
        [Route("GetGroupMessage")]
        [HttpGet]
        public IActionResult GetGroupMessage(int senderId, int groupId)
        {
            var result = _messageManager.GetPrivateMessage(senderId, groupId);
            if (result.Errors == null)
            {
                return Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
    }
}
