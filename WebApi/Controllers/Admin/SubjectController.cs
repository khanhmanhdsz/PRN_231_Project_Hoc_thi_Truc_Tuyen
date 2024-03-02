using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels;
using Repositories.Subjects;
using ViewModels.Paging;
using DataAccess.Models;
using ViewModels.Subjects;

namespace WebApi.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [Route("api/Admin/[controller]/[action]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private ISubjectRepository _repository;
        private readonly IMapper _mapper;

        public SubjectController(ISubjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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


        [HttpGet]
        public async Task<IActionResult> GetSubjectById([FromQuery] int subjectId)
        {
            try
            {
                Subject subject = await _repository.GetSubjectById(subjectId);

                if (subject == null)
                {
                    return NotFound();
                }

                SubjectVM subjectVM = _mapper.Map<SubjectVM>(subject);
                return Ok(subjectVM);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubject([FromBody] SubjectVM subjectVM)
        {
            try
            {
                if (subjectVM == null)
                {
                    throw new Exception("Didn't recieved subject information");
                }

                bool isExisted = await _repository.IsExistedSubject(subjectVM.SubjectId ?? 0, subjectVM.SubjectName);
                if (isExisted)
                {
                    throw new Exception($"Subject with the name '{subjectVM.SubjectName}' existed!");
                }

                var subject = _mapper.Map<Subject>(subjectVM);

                bool status = await _repository.UpdateSubject(subject);
                if (!status)
                {
                    throw new Exception("Update subject failed!");
                }

                return Ok(new ResponseVM() { Status = true, Message = "Update subject successful!" });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseVM() { Status = false, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSubject([FromBody] SubjectVM subjectVM)
        {
            try
            {
                if (subjectVM == null)
                {
                    throw new Exception("Didn't recieved subject information");
                }
                // check exist campus
                var subject = _mapper.Map<Subject>(subjectVM);
                bool isExisted = await _repository.IsExistedSubject(subjectVM.SubjectId ?? 0, subjectVM.SubjectName);
                if (isExisted)
                {
                    throw new Exception($"Subject with the name '{subjectVM.SubjectName}' existed!");
                }

                //add new campus
                bool status = await _repository.AddSubject(subject);
                if (!status)
                {
                    throw new Exception("Add subject failed!");
                }

                return Ok(new ResponseVM() { Status = true, Message = "Add subject successful!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
                return Ok(new ResponseVM() { Status = false, Message = ex.Message });
            }
        }
    }
}

