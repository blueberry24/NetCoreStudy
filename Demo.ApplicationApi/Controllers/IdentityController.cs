using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Demo.ApplicationApi
{
    [Route("api/[Controller]")]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        [HttpGet("getUserClaims")]
        [Authorize]
        public IActionResult GetUserClaims()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}
