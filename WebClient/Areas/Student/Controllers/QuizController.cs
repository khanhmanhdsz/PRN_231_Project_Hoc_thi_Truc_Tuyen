using Core.Constants;
using Core.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ViewModels;
using ViewModels.Paging;
using ViewModels.QuestionHistories;
using ViewModels.QuizHistories;
using ViewModels.Quizzes;
using WebClient.Helpers;
using WebClient.Models;
using WebClient.Services;

namespace WebClient.Areas.Student.Controllers
{
    [Area("Student")]
    [Route("Student/[Controller]/[Action]")]
    [Authorize(Roles = "Student")]
    public class QuizController : Controller
    {
        private readonly ClientService _clientService;

        public QuizController(ClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(QuizPagingRequest request)
        {

            try
            {
                request.SearchTerm = StringHelper.RefinedSearchTerm(request.SearchTerm);

                var response = await _clientService.Post<QuizPagingRequest>(ApiPaths.Student + "/Quiz/GetQuizzes", request);
                if (response == null)
                {
                    throw new Exception("Server error");
                }

                return View(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                ToastHelper.ShowError(TempData, ex.Message);
                return View(request);
            }
        }



        [HttpGet]
        public async Task<IActionResult> Details(QuestionPagingRequest request)
        {
            try
            {
                request.PageSize = int.MaxValue;
                if (request.QuizId == 0)
                {
                    ToastHelper.ShowInfo(TempData, "Please choose a quiz to view");
                    return RedirectToAction("Index");
                }

                var response = await _clientService.Post<QuestionPagingRequest>($"{ApiPaths.Student}/Quiz/GetQuizById", request);
                if (response == null)
                {
                    ToastHelper.ShowWarning(TempData, $"Quiz doesn't exist");
                    return RedirectToAction("Index");
                }

                return View(response);
            }
            catch (Exception)
            {
                ToastHelper.ShowWarning(TempData, $"Error when updating subject");
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        [Route("/Student/SubmitQuiz")]
        public async Task<int> SubmitQuiz(string json, int quizId)
        {
            try
            {
                Console.WriteLine(json);
                QuizHistoryVM quizHistory = new();
                List<QuestionHistoryVM> questionHistories = JsonSerializer.Deserialize<List<QuestionHistoryVM>>(json);
                quizHistory.QuestionHistories = questionHistories;
                quizHistory.QuizId = quizId;
                quizHistory.Id = SessionHelper.GetObject<UserInfo>(HttpContext.Session, "UserInfo").UserId;

                var response = await _clientService.Post<ResponseVM>($"{ApiPaths.Student}/Quiz/SubmitQuiz", quizHistory);

                if(response == null)
                {
                    throw new Exception("cannot submit quiz");
                }
                Console.WriteLine("------" + response.Message);
                int quizHistoryId = 0;
                int.TryParse(response.Message, out quizHistoryId);

                return quizHistoryId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }

    }
}
