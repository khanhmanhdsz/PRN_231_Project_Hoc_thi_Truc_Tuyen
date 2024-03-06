using Core.Constants;
using Core.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Paging;
using ViewModels.Subjects;
using WebClient.Helpers;
using WebClient.Services;

namespace WebClient.Areas.Student.Controllers
{
    [Area("Student")]
    [Route("Student/[Controller]/[Action]")]
    [Authorize(Roles = "Student")]
    public class SubjectController : Controller
    {
        private readonly ClientService _clientService;

        public SubjectController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(SubjectPagingRequest request)
        {

            try
            {
                request.SearchTerm = StringHelper.RefinedSearchTerm(request.SearchTerm);

                var response = await _clientService.Post<SubjectPagingRequest>(ApiPaths.Subject + "/GetSubjects", request);
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
        public async Task<IActionResult> Details(QuizPagingRequest request)
        {
            try
            {
                var apiPath = $"{ApiPaths.Subject}/GetSubjectById?subjectId={request.SubjectId}";
                var subject = await _clientService.Get<SubjectVM>(apiPath);

                ViewData["Subject"] = subject;
                PropertyLogger.LogAllProperties(subject);
             
                var response = await _clientService.Post<QuizPagingRequest>($"{ApiPaths.Student}/Quiz/GetQuizzes", request);

                if (response == null)
                {
                    throw new Exception("Server error");
                }

                response.ItemVMs = response.ItemVMs.Where(x => x.SubjectId == request.SubjectId).ToList();

                return View(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                ToastHelper.ShowError(TempData, ex.Message);
                return View(request);
            }
        }

    }
}
