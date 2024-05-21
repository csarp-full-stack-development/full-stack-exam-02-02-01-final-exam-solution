using Kreta.Backend.Repos;
using Kreta.Shared.Assamblers;
using Kreta.Shared.Dtos;
using Kreta.Shared.Models.SchoolCitizens;
using Microsoft.AspNetCore.Mvc;

namespace Kreta.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeadTeacherController : BaseController<HeadTeacher, HeadTeacherDto>
    {
        private readonly IHeadTeacherRepo? _headTeacherRepo;

        public HeadTeacherController(HeadTeacherAssambler? assambler, IHeadTeacherRepo? repo) : base(assambler, repo)
        {
            _headTeacherRepo = repo;
        }

        [HttpGet("NumberOfHeadTeacher/{isHeadTeacher}")]
        public IActionResult GetNumberOfHeadTeacher(bool isHeadTeacher)
        {
            if (_headTeacherRepo is not null)
                return Ok(_headTeacherRepo.GetNumberOfHeadTeacher(isHeadTeacher));
            else
                return BadRequest();
        }
    }
}
