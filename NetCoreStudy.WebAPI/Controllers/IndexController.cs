using Microsoft.AspNetCore.Mvc;
using NetCoreStudy.WebAPI.Extensions;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NetCoreStudy.Domain;
using NetCoreStudy.WebAPI.Commands;
using NetCoreStudy.WebAPI.Dtos;
using System;

namespace NetCoreStudy.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class IndexController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public IndexController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// 简单GET
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var result = new { Success = true, Status = 200, Msg = "访问成功" };
            return Ok(result);
        }

        /// <summary>
        /// 简单POST
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] string UserName, string Password)
        {
            var result = new { Success = true, Status = 200, Msg = $"成功接收到POST请求，参数是：UserName[{UserName}], Password[{Password}]" };
            return Ok(result);
        }

        /// <summary>
        /// 简单POST
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostString(string param)
        {
            var request = HttpContext.Request;
            var result = new { Success = true, Status = 200, Msg = $"成功接收到POST请求，参数是：{param}" };
            return Ok(result);
        }

        /// <summary>
        /// 创建Subject
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateSubject([FromBody] CreateSubjectDto dto)
        {
            var subject = _mapper.Map<Subject>(dto);
            subject.CreateObject(dto.Name, dto.Description, dto.GradeLevel);

            CreateSubjectCommand cmd = new CreateSubjectCommand(subject);
            var result = await _mediator.Send(cmd, HttpContext.RequestAborted);
            return Json(new { Success = true, Status = 200, Msg = "创建成功", Data = result });
        }

        /// <summary>
        /// 批量创建Examination
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateExaminations([FromBody] CreateExaminationCommand cmd)
        {
            var result = await _mediator.Send(cmd, HttpContext.RequestAborted);
            return Json(new { Success = true, Status = 200, Msg = "创建成功", Data = result });
        }

        /// <summary>
        /// 根据课程名称查询所有考试
        /// </summary>
        /// <param name="subjectName"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSubjectExaminations(string subjectName)
        {
            var result = await _mediator.Send(new GetSubjectExaminationsCommand(subjectName), HttpContext.RequestAborted);
            return Json(new { Success = true, Status = 200, Msg = "查询成功", Data = result });
        }

        /// <summary>
        /// 添加返回json格式自定义的filter
        /// </summary>
        /// <returns></returns>
        [CustomActionJsonFormat(typeof(DefaultContractResolver))]
        [HttpGet]
        public IActionResult GetCustom()
        {
            var result = new { Success = true, Status = 200, Msg = "访问成功" };
            return Json(result);
        }

        /// <summary>
        /// 测试FromHeader标签
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetHeader([FromHeader] HeadParam header)
        {
            return Ok(header);
        }
    }

    public class HeadParam
    {
        [FromHeader(Name = "Token")]
        public string Token { get; set; }
    }
}
