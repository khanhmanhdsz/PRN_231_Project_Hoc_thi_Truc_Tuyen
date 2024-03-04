using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Quizzes;
using ViewModels.Paging;
using ViewModels.Questions;
using ViewModels.Quizzes;

namespace WebApi.Controllers.Student
{
    [Authorize(Roles = "Student")]
    [Route("api/Student/[controller]/[action]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private IQuizRepository _repository;
        private readonly IMapper _mapper;

        public QuizController(IQuizRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> GetQuizzes([FromBody]QuizPagingRequest request)
        {
            try
            {
                Console.WriteLine("Go to api");
                var response = await _repository.GetQuizzes(request);

                if(response != null)
                {
                    response.ItemVMs = _mapper.Map<List<QuizVM>>(response.Items);
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
        [HttpPost]
        public async Task<IActionResult> GetQuizById([FromBody] QuestionPagingRequest request)
        {
            try
            {
                QuestionPagingRequest response = await _repository.GetQuizById(request);

                if (response.Quiz == null)
                {
                    return NotFound();
                }

                response.ItemVMs = _mapper.Map<List<QuestionVM>>(response.Items);
                response.Items = null;
                response.QuizVM = _mapper.Map<QuizVM>(response.Quiz);
                response.Quiz = null;
                return Ok(response);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

    }
}
