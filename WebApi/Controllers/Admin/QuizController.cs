using AutoMapper;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Subjects;
using ViewModels.Paging;
using ViewModels.Subjects;
using ViewModels;
using Repositories.Quizzes;
using ViewModels.Quizzes;
using ViewModels.Questions;

namespace WebApi.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [Route("api/Admin/[controller]/[action]")]
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
        public async Task<IActionResult> GetQuizzes(QuizPagingRequest request)
        {
            try
            {
                QuizPagingRequest response = await _repository.GetQuizzes(request);

                if (response != null)
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

        [HttpPut]
        public async Task<IActionResult> UpdateQuiz([FromBody] QuizVM quizVM)
        {
            try
            {
                if (quizVM == null)
                {
                    throw new Exception("Didn't recieved quiz information");
                }

                //bool isExisted = await _repository.IsExistedSubject(subjectVM.SubjectId ?? 0, subjectVM.SubjectName);
                //if (isExisted)
                //{
                //    throw new Exception($"Subject with the name '{subjectVM.SubjectName}' existed!");
                //}

                var quiz = _mapper.Map<Quiz>(quizVM);

                bool status = await _repository.UpdateQuiz(quiz);
                if (!status)
                {
                    throw new Exception("Update quiz failed!");
                }

                return Ok(new ResponseVM() { Status = true, Message = "Update quiz successful!" });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseVM() { Status = false, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddQuiz([FromBody] QuizVM quizVM)
        {
            try
            {
                if (quizVM == null)
                {
                    throw new Exception("Didn't recieved quiz information");
                }
                // check exist campus
                //bool isExisted = await _repository.IsExistedSubject(subjectVM.SubjectId ?? 0, subjectVM.SubjectName);
                //if (isExisted)
                //{
                //    throw new Exception($"Subject with the name '{subjectVM.SubjectName}' existed!");
                //}
                var quiz = _mapper.Map<Quiz>(quizVM);

                //add new campus
                bool status = await _repository.AddQuiz(quiz);
                if (!status)
                {
                    throw new Exception("Update quiz failed!");
                }

                return Ok(new ResponseVM() { Status = true, Message = "Create quiz successful!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
                return Ok(new ResponseVM() { Status = false, Message = ex.Message });
            }
        }
    }
}
