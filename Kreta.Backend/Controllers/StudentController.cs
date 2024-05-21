using Kreta.Backend.Repos;
using Kreta.Shared.Assamblers;
using Kreta.Shared.Dtos;
using Kreta.Shared.Extensions;
using Kreta.Shared.Models.SchoolCitizens;
using Kreta.Shared.Parameters;
using Kreta.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : BaseController<Student, StudentDto>
    {
        private readonly IStudentRepo? _studentRepo;
        public StudentController(StudentAssambler? assambler, IStudentRepo? repo) : base(assambler, repo)
        {
            _studentRepo = repo;
        }

        [HttpGet("included")]
        public async Task<IActionResult> SelectAllIncludedAsync()
        {
            List<Student>? students = new();
            if (_studentRepo != null && _assambler is not null)
            {
                try
                {
                    students = await _studentRepo.SelectAllIncluded().ToListAsync();
                    return Ok(students.Select(entity => _assambler.ToDto(entity)));
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);
                }
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }


        [HttpGet("byeducationid/{educationId}")]
        public async Task<IActionResult> SelectStudentsByEducationId(Guid educationId)
        {
            List<Student>? students = new();
            if (_studentRepo != null && _assambler is not null)
            {
                try
                {
                    students = await _studentRepo.SelectStudentsByEducationId(educationId).ToListAsync();
                    return Ok(students.Select(entity => _assambler.ToDto(entity)));
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);
                }
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpGet("withouteducationlevel")]
        public async Task<IActionResult> SelectStudentsWithoutEducationLevel()
        {
            List<Student>? students = new();
            if (_studentRepo != null && _assambler is not null)
            {
                try
                {
                    students = await _studentRepo.SelectStudentsWithoutEducationLevel().ToListAsync();
                    return Ok(students.Select(entity => _assambler.ToDto(entity)));
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);
                }
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpGet("NumberOfGender/{isWoman}")]
        public IActionResult GetNumberOfHeadTeacher(bool isWoman)
        {
            if (_studentRepo is not null)
                return Ok(_studentRepo.GetNumberOfGener(isWoman));
            else
                return BadRequest();
        }

        [HttpPost("queryparameters")]
        public async Task<IActionResult> GetStudents(StudentQueryParametersDto dto)
        {
            StudentQueryParameters parameters = dto.ToModel();
            if (!parameters.ValidYearRange)
            {
                ControllerResponse response = new ControllerResponse();
                response.AppendNewError("A születési év maximuma nagyobb kell legyen a születési év minimumánál!");
                return BadRequest(response);
            }
            else
            {
                if (_studentRepo is null)
                {
                    ControllerResponse response = new ControllerResponse();
                    response.AppendNewError("A diákok szűrése születési év alapján nem lehetséges");
                    return BadRequest(response);
                }
                else
                {
                    List<Student> result = await _studentRepo.GetStudents(parameters).ToListAsync();
                    return Ok(result);
                }
            }
        }

    }
}
