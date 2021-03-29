using ConsulDemo.APIA.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ConsulDemo.APIA.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }

        [HttpPost]
        public IActionResult Add([FromBody]AddUserDto dto)
        {
            return Ok(dto);
        }

        [HttpDelete]
        public IActionResult Delete(string userId)
        {
            return Ok(userId);
        }
    }
}
