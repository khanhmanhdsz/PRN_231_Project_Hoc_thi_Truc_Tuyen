using Core.Constants;
using Core.Helpers;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ViewModels;
using ViewModels.Paging;
using ViewModels.Questions;
using ViewModels.Quizzes;
using ViewModels.Subjects;
using WebClient.Helpers;
using WebClient.Services;

namespace WebClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    [Authorize(Roles = "Admin")]
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

                var response = await _clientService.Post<QuizPagingRequest>(ApiPaths.Admin + "/Quiz/GetQuizzes", request);
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
        public async Task<IActionResult> Create()
        {
            var subjects = await _clientService.Get<List<SubjectVM>>($"{ApiPaths.Subject}/GetSubjects");

            ViewData["Subjects"] = subjects;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int quizId)
        {
            try
            {
                if (quizId == 0)
                {
                    ToastHelper.ShowInfo(TempData, "Please choose a quiz to edit");
                    return RedirectToAction("Index");
                }

                var quizVM = await _clientService.Get<QuizVM>($"{ApiPaths.Admin}/Quiz/GetQuizById?quizId={quizId}");
                if (quizVM == null)
                {
                    ToastHelper.ShowWarning(TempData, $"Quiz doesn't exist");
                    return RedirectToAction("Index");
                }

                return View(quizVM);
            }
            catch (Exception)
            {
                ToastHelper.ShowWarning(TempData, $"Error when updating quiz");
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<string> RemoveQuestion(int questionId)
        {
            try
            {
                var response = await _clientService.Get<ResponseVM>($"{ApiPaths.Admin}/Quiz/RemoveQuestion?questionId={questionId}");

                Console.WriteLine(response.Status);
                return JsonSerializer.Serialize(response);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(QuestionPagingRequest request)
        {
            try
            {
                request.PageSize = 5;
                if (request.QuizId <= 0)
                {
                    ToastHelper.ShowInfo(TempData, "Please choose a quiz to view");
                    return RedirectToAction("Index");
                }

                var response = await _clientService.Post<QuestionPagingRequest>($"{ApiPaths.Admin}/Quiz/GetQuizById", request);
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
        public async Task<IActionResult> Create(QuizVM quizVM)
        {
            try
            {
                quizVM.CreatedDate = DateTime.Now;
                var subjects = await _clientService.Get<List<SubjectVM>>($"{ApiPaths.Subject}/GetSubjects");
                ViewData["Subjects"] = subjects;
                //PropertyLogger.LogAllProperties(quizVM);
                if (ModelState.IsValid)
                {
                    quizVM = StringHelper.TrimStringProperties<QuizVM>(quizVM);

                    var response = await _clientService.Post<ResponseVM>($"{ApiPaths.Admin}/Quiz/AddQuiz", quizVM);
                    if (response == null)
                    {
                        throw new Exception("Server error");
                    }
                    if (!response.Status)
                    {
                        throw new Exception(response.Message);
                    }

                    ToastHelper.ShowSuccess(TempData, response.Message);
                    return RedirectToAction(nameof(Index));

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
                ToastHelper.ShowError(TempData, ex.Message);
            }
            return View(quizVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(QuizVM quizVM)
        {
            try
            {
                var subjects = await _clientService.Get<List<SubjectVM>>($"{ApiPaths.Subject}/GetSubjects");
                ViewData["Subjects"] = subjects;
                if (ModelState.IsValid)
                {
                    quizVM = StringHelper.TrimStringProperties<QuizVM>(quizVM);
                    var response = await _clientService.Put<ResponseVM>($"{ApiPaths.Admin}/Quiz/UpdateQuiz", quizVM);
                    if (response == null)
                    {
                        throw new Exception("Update failed");
                    }

                    if (!response.Status)
                    {
                        throw new Exception(response.Message);
                    }
                    ToastHelper.ShowSuccess(TempData, response.Message);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ToastHelper.ShowError(TempData, ex.Message);
            }
            return View(quizVM);
        }
    }
}
