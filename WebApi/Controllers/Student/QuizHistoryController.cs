using AutoMapper;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using Repositories.QuizHistories;
using Repositories.Quizzes;
using ViewModels.Paging;
using ViewModels.QuizHistories;
using ViewModels.Quizzes;

namespace WebApi.Controllers.Student
{
    [Authorize(Roles = "Student")]
    [Route("api/Student/[controller]/[action]")]
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

                if (response != null)
                {
                    response.ItemVMs = _mapper.Map<List<QuizHistoryVM>>(response.Items);
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
