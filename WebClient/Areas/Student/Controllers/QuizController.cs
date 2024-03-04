using Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Paging;
using WebClient.Helpers;
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
        [HttpPost]
        public async Task<IActionResult> SubmitQuiz()
        {
            return View();
        }

    }
}
