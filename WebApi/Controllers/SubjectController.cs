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

        [HttpGet]
        public async Task<IActionResult> GetSubjectById(int subjectId)
        {
            try
            {
                var subject = await _repository.GetSubjectById(subjectId);
                if (subject != null)
                {
                    SubjectVM subjectVM = _mapper.Map<SubjectVM>(subject);
                    return Ok(subjectVM);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> GetSubjects(SubjectPagingRequest request)
        {
            try
            {

                SubjectPagingRequest response = await _repository.GetSubjects(request);

                if (response != null)
                {
                    response.ItemVMs = _mapper.Map<List<SubjectVM>>(response.Items);
                    response.Items = null;
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return NotFound();
            }
        }
    }
}
