using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NetCoreStudy.WebAPI.Controllers
{
    /// <summary>
    /// RESTful API 示例
    /// </summary>
    [Route("api/something/")]
    [ApiController]
    public class DoSomethingController : ControllerBase
    {
        private readonly ILogger<DoSomethingController> _logger;

        public DoSomethingController(ILogger<DoSomethingController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string), 200)]
        [HttpGet]
        public ActionResult GetThings(int userId)
        {
            if (userId < 0)
            {
                return NotFound();
            }
            else
            {
                return new JsonResult(new { Success = true, Data = "find something" });
            }
        }
        /// <summary>
        /// 查询单个数据
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="thingId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string), 200)]
        [HttpGet("{thingId}")]
        public IActionResult GetThing(int userId, int thingId)
        {
            if (thingId == 1)
            {
                return Ok("one thing be found");
            }
            else
            {
                return NotFound();
            }
        }
        /// <summary>
        /// 单个提交，成功后定位到单个查询页
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="thingName"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string), 200)]
        [HttpPost]
        public IActionResult AddThing(int userId, [FromBody] string thingName)
        {
            if (userId != 1)
            {
                return NotFound();
            }
            else
            {
                return CreatedAtAction("GetThing", new { userId = 1, thingId = 1 }, "Created Successfull");
            }
        }
        /// <summary>
        /// 批量提交，成功后定位到查询列表页
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="thingNames"></param>
        /// <param name="thingCount"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string), 200)]
        [HttpPost("batch")]
        public IActionResult AddThing(int userId, [FromBody] string thingNames, int thingCount)
        {
            if (userId != 1)
            {
                return NotFound();
            }
            else
            {
                return CreatedAtAction("GetThings", new { userId = userId, things = thingNames, count = thingCount });
            }
        }
    }
}
