using Core.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels;
using ViewModels.Paging;
using ViewModels.Subjects;
using WebClient.Filters;
using WebClient.Helpers;
using WebClient.Services;
using Core.Constants;

namespace WebClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    [Authorize(Roles = "Admin")]
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

                var response = await _clientService.Post<SubjectPagingRequest>(ApiPaths.Admin + "/Subject/GetSubjects", request);
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int subjectId)
        {
            try
            {
                if (subjectId == 0)
                {
                    ToastHelper.ShowInfo(TempData, "Please choose a subject to edit");
                    return RedirectToAction("Index");
                }

                SubjectVM? subjectVM = await _clientService.Get<SubjectVM>($"{ApiPaths.Admin}/Subject/GetSubjectById?subjectId={subjectId}");
                if (subjectVM == null)
                {
                    ToastHelper.ShowWarning(TempData, $"Subject doesn't exist");
                    return RedirectToAction("Index");
                }

                return View(subjectVM);
            }
            catch (Exception)
            {
                ToastHelper.ShowWarning(TempData, $"Error when updating subject");
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int subjectId)
        {
            try
            {
                if (subjectId == 0)
                {
                    ToastHelper.ShowInfo(TempData, "Please choose a subject to view");
                    return RedirectToAction("Index");
                }

                SubjectVM? subjectVM = await _clientService.Get<SubjectVM>($"{ApiPaths.Admin}/Subject/GetSubjectById?subjectId={subjectId}");
                if (subjectVM == null)
                {
                    ToastHelper.ShowWarning(TempData, $"Subject doesn't exist");
                    return RedirectToAction("Index");
                }

                return View(subjectVM);
            }
            catch (Exception)
            {
                ToastHelper.ShowWarning(TempData, $"Error when updating subject");
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create(SubjectVM subjectVM)
        {
            try
            {
                subjectVM.CreatedDate = DateTime.Now;
                //PropertyLogger.LogAllProperties(subjectVM);
                if (ModelState.IsValid)
                {
                    subjectVM = StringHelper.TrimStringProperties<SubjectVM>(subjectVM);

                    var response = await _clientService.Post<ResponseVM>($"{ApiPaths.Admin}/Subject/AddSubject", subjectVM);
                    if (response != null)
                    {

                        if (response.Status)
                        {
                            ToastHelper.ShowSuccess(TempData, response.Message);
                            return RedirectToAction("Index");
                        }

                        ToastHelper.ShowWarning(TempData, response.Message);
                        return View(subjectVM);
                    }

                    ToastHelper.ShowError(TempData, "Server error");
                    return RedirectToAction("Error500", "Error", new { area = "" });
                }
            }
            catch (Exception)
            {
            }
            return View(subjectVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SubjectVM subjectVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    subjectVM = StringHelper.TrimStringProperties<SubjectVM>(subjectVM);
                    var response = await _clientService.Put<ResponseVM>($"{ApiPaths.Admin}/Subject/UpdateSubject", subjectVM);
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
            return View(subjectVM);
        }
    }
}
