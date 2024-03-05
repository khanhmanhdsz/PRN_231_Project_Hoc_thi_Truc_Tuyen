using AutoMapper;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Quizzes;
using ViewModels.Paging;
using ViewModels.QuestionHistories;
using ViewModels.Questions;
using ViewModels.QuizHistories;
using ViewModels.Quizzes;
using ViewModels;

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
        public async Task<IActionResult> GetQuizzes([FromBody] QuizPagingRequest request)
        {
            try
            {
                Console.WriteLine("Go to api");
                var response = await _repository.GetQuizzes(request);

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

        [HttpPost]
        [Route("/api/Student/Quiz/SubmitQuiz")]
        public async Task<IActionResult> SubmitQuiz(QuizHistoryVM request)
        {
            try
            {
                Console.WriteLine("go to api SubmitQuiz");
                request.DateTaken = DateTime.Now;
                Quiz quiz = await _repository.GetQuizById(request.QuizId.Value);

                List<Question> questions = quiz.Questions.ToList();
                List<QuestionHistoryVM> questionHistories = request.QuestionHistories;

                int correct = 0;
                for (int i = 0; i < questions.Count; i++)
                {
                    Question question = questions[i];
                    QuestionHistoryVM questionHistory = questionHistories[i];
                    bool isCorrect = question.CorrectAnswer.Equals(questionHistory.SelectedOption);

                    if (isCorrect) correct++;
                    questionHistories[i].IsCorrect = isCorrect;
                }

                request.Score = correct;

                request.QuestionHistories = questionHistories;

                QuizHistory quizHistory = _mapper.Map<QuizHistory>(request);


                int quizHistoryId = await _repository.SubmitQuiz(quizHistory);

                return Ok(new ResponseVM() { Status = true, Message = quizHistoryId.ToString() });
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

    }
}
