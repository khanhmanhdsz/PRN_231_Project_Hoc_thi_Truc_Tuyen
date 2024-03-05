using AutoMapper;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.QuizHistories;
using ViewModels.Paging;
using ViewModels.QuizHistories;

namespace WebApi.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [Route("api/Admin/[controller]/[action]")]
    [ApiController]
    public class QuizHistoryController : ControllerBase
    {
        private IQuizHistoryRepository _repository;
        private readonly IMapper _mapper;
        public QuizHistoryController(IQuizHistoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> GetQuizHistories([FromBody] QuizHistoryPagingRequest request)
        {
            try
            {
                Console.WriteLine("Go to api");
                var response = await _repository.GetQuizHistories(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetQuizHistoryById([FromQuery] int id)
        {
            try
            {
                QuizHistory quizHistory = await _repository.GetQuizHistoryById(id);
                if (quizHistory == null)
                {
                    throw new Exception("Quiz history is null");
                }

                QuizHistoryVM quiz = _mapper.Map<QuizHistoryVM>(quizHistory);
                return Ok(quizHistory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
