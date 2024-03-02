using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Subjects;
using ViewModels.Paging;
using ViewModels.Subjects;

namespace WebApi.Controllers
{
    [Route("api/Subject/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class SubjectController : ControllerBase
    {
        private ISubjectRepository _repository;
        private readonly IMapper _mapper;

        public SubjectController(ISubjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetSubjects()
        {
            try
            {
                var subjects = await _repository.GetSubjects();
                List<SubjectVM> subjectVMs = new();
                if (subjects != null)
                {
                    subjectVMs = _mapper.Map<List<SubjectVM>>(subjects);
                }
                return Ok(subjectVMs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return NotFound();
            }
        }
    }
}
