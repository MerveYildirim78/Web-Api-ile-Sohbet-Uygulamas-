using ChatApp.Business.Concrete;
using ChatApp.Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ChattApplication.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ComplainController : ControllerBase
    {
        ComplainManager _complainManager;

        public ComplainController(ComplainManager complainManager)
        {
            _complainManager = complainManager;
        }
        [Route("Add")]
        [HttpPost]
        public IActionResult Add([FromBody] ComplainDTO dto)
        {
            var result = _complainManager.Add(dto);
            if (result.Errors == null)
            {
                return Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
        [Route("Delete")]
        [HttpDelete]
        public IActionResult Delete([FromBody] ComplainDTO dto)
        {
            var result = _complainManager.Delete(dto);
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
            var result = _complainManager.GetByID(id);
            if (result.Errors == null)
            {
                return Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
        [Route("GetComplainByUserID")]
        [HttpGet]
        public IActionResult GetComplainByUserID(int userId)
        {
            var result = _complainManager.GetComplainByUserID(userId);
            if (result.Errors == null)
            {
                return Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
        [Route("GetListAll")]
        [HttpGet]
        public IActionResult GetListAll()
        {
            var result = _complainManager.GetListAll();
            if (result.Errors == null)
            {
                return Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
        [Route("Update")]
        [HttpPost]
        public IActionResult Update([FromBody] ComplainDTO dto)
        {
            var result = _complainManager.Update(dto);
            if (result.Errors == null)
            {
                Ok(result.Value);
            }
            return NotFound(result.Errors);
        }
    }
}
