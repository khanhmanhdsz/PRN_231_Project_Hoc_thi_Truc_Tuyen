using Core.Constants;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebClient.Helpers;
using WebClient.Services;

namespace WebClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    [Authorize(Roles = "Admin")]
    public class QuizHistoryController : Controller
    {
        private readonly ClientService _clientService;

        public QuizHistoryController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int quizId)
        {
            try
            {
                var response = await _clientService.Get<QuizHistory>($"{ApiPaths.Admin}/QuizHistory/GetQuizHistoryById?id=" + quizId);
                if (response == null)
                {
                    ToastHelper.ShowWarning(TempData, $"Quiz doesn't exist");
                    return RedirectToAction("Error404", "Error");
                }

                return View(response);
            }
            catch (Exception)
            {
                ToastHelper.ShowWarning(TempData, $"Error when updating subject");
                return RedirectToAction("Error404", "Error");
            }
        }
    }
}
