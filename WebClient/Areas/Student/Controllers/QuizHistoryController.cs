using Core.Constants;
using Core.Helpers;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Paging;
using ViewModels.QuizHistories;
using WebClient.Helpers;
using WebClient.Models;
using WebClient.Services;

namespace WebClient.Areas.Student.Controllers
{
    [Area("Student")]
    [Route("Student/[Controller]/[Action]")]
    [Authorize(Roles = "Student")]
    public class QuizHistoryController : Controller
    {
        private readonly ClientService _clientService;

        public QuizHistoryController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(QuizHistoryPagingRequest request)
        {

            try
            {
                request.SearchTerm = StringHelper.RefinedSearchTerm(request.SearchTerm);
                request.Email = SessionHelper.GetObject<UserInfo>(HttpContext.Session, "UserInfo").Email;

                var response = await _clientService.Post<QuizHistoryPagingRequest>(ApiPaths.Student + "/QuizHistory/GetQuizHistories", request);
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
        public async Task<IActionResult> Details(int quizId)
        {
            try
            {


                var response = await _clientService.Get<QuizHistory>($"{ApiPaths.Student}/QuizHistory/GetQuizHistoryById?id=" + quizId);
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
    }
}
