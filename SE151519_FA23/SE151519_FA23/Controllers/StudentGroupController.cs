using BusinessLogic.Token.IService;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControllerAPI.Controllers
{
    [Route("api/groups")]
    [ApiController]
    public class StudentGroupController : ControllerBase
    {
        IStudentGroupService _group;

        public StudentGroupController(IStudentGroupService group)
        {
            _group = group;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _group.GetAll();
            if (result.Any()) return Ok(result);
            return NoContent();
        }
    }
}
