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
using ViewModels.Questions;
using ViewModels.Quizzes;
using DataAccess.Models;
using System.Diagnostics;

namespace WebClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    [Authorize(Roles = "Admin")]
    public class QuestionController : Controller
    {

        private readonly ClientService _clientService;
        private readonly ExcelService _excelService;

        public QuestionController(ClientService clientService, ExcelService excelService)
        {
            _clientService = clientService;
            _excelService = excelService;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int quizId)
        {
            var quizVM = await _clientService.Get<QuizVM>($"{ApiPaths.Admin}/Quiz/GetQuiz?quizId={quizId}");

            if (quizVM == null)
            {
                ToastHelper.ShowInfo(TempData, "Please choose a quiz to add new question");
                return RedirectToAction("Index", "Quiz");
            }

            ViewData["Quiz"] = quizVM;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int questionId, int quizId)
        {
            try
            {
                var quizVM = await _clientService.Get<QuizVM>($"{ApiPaths.Admin}/Quiz/GetQuiz?quizId={quizId}");

                if (quizVM == null)
                {
                    throw new Exception("Please choose a quiz to edit question");
                }

                ViewData["Quiz"] = quizVM;

                if (questionId == 0)
                {
                    throw new Exception("Please choose a question to edit");
                }

                QuestionVM? questionVM = await _clientService.Get<QuestionVM>($"{ApiPaths.Admin}/Question/GetQuestionById?questionId={questionId}");
                if (questionVM == null)
                {
                    throw new Exception("Question doesn't exist");
                }

                return View(questionVM);
            }
            catch (Exception ex)
            {
                ToastHelper.ShowWarning(TempData, ex.Message);
                return RedirectToAction("Details", "Quiz", new { quizId = quizId });
            }
        }



      

        [HttpPost]
        public async Task<IActionResult> Create(QuestionVM questionVM)
        {
            try
            {
                var quizVM = await _clientService.Get<QuizVM>($"{ApiPaths.Admin}/Quiz/GetQuiz?quizId={questionVM.QuizId}");
                ViewData["Quiz"] = quizVM;

                if (ModelState.IsValid)
                {
                    questionVM = StringHelper.TrimStringProperties<QuestionVM>(questionVM);

                    var response = await _clientService.Post<ResponseVM>($"{ApiPaths.Admin}/Question/AddQuestion", questionVM);
                    if (response == null)
                    {
                        throw new Exception("Server error");

                    }
                    if (!response.Status)
                    {
                        ToastHelper.ShowWarning(TempData, response.Message);
                        return View(questionVM);
                    }

                    ToastHelper.ShowSuccess(TempData, response.Message);
                    return RedirectToAction("Details", "Quiz", new { quizId = questionVM.QuizId });
                }
            }
            catch (Exception ex)
            {
                ToastHelper.ShowError(TempData, ex.Message);

            }
            return View(questionVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(QuestionVM questionVM)
        {
            try
            {
                var quizVM = await _clientService.Get<QuizVM>($"{ApiPaths.Admin}/Quiz/GetQuiz?quizId={questionVM.QuizId}");
                ViewData["Quiz"] = quizVM;

                if (ModelState.IsValid)
                {
                    questionVM = StringHelper.TrimStringProperties<QuestionVM>(questionVM);
                    var response = await _clientService.Put<ResponseVM>($"{ApiPaths.Admin}/Question/UpdateQuestion", questionVM);
                    if (response == null)
                    {
                        throw new Exception("Update failed!!!");
                    }

                    if (!response.Status)
                    {
                        throw new Exception(response.Message);
                    }
                    ToastHelper.ShowSuccess(TempData, response.Message);
                    return RedirectToAction("Details", "Quiz", new { quizId = questionVM.QuizId });
                }
            }
            catch (Exception ex)
            {
                ToastHelper.ShowError(TempData, ex.Message);
            }
            return View(questionVM);
        }

        [HttpPost]
        public async Task<IActionResult> ImportFromFile(IFormFile file, int quizId)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    throw new Exception("Please choose a file");
                }

                var stopwatch = new Stopwatch();

                // Start the stopwatch
                stopwatch.Start();

                List<ImportQuestionVM> records = await _excelService.ReadExcel<ImportQuestionVM>(file);

                foreach (var record in records)
                {
                    record.QuizId = quizId;
                    //PropertyLogger.LogAllProperties(record);
                }

                string apiPath = $"{ApiPaths.Admin}/Question/ImportFromFile";
                var results = await _clientService.Post<List<ImportQuestionVM>>(apiPath, records);

                stopwatch.Stop();

                // Get the elapsed time
                TimeSpan elapsedTime = stopwatch.Elapsed;

                if (results == null)
                {
                    throw new Exception("Error while processing file");
                }

                string importTime = $"Processing Time: {elapsedTime.Hours}h, {elapsedTime.Minutes}m, {elapsedTime.Seconds}s, {elapsedTime.Milliseconds}ms";

                int importSuccess = results.Count(r => string.IsNullOrEmpty(r.ImportMessage));
                int importFailed = results.Count - importSuccess;

                string importResult = $"{importSuccess} records successful, {importFailed} records failed";

                results = results.Where(r => !String.IsNullOrEmpty(r.ImportMessage)).ToList();

                List<ImportQuestionVM> exports = results;

                SessionHelper.SetObject<List<ImportQuestionVM>>(HttpContext.Session, "FailedRecords", exports);

                return RedirectToAction("ImportResult", new { importTime = importTime, importResult = importResult, quizId = quizId });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                ToastHelper.ShowError(TempData, ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult ImportResult()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> ExportFailedRecordsToFile()
        {
            try
            {
                // Step 1: declare file name
                string fileName = "Import Failed Questions";

                // Step 2: Create titles
                Dictionary<int, string> titles = new Dictionary<int, string>() {
                        {1, "STT" },
                        {2, "Title" },
                        {3, "Description" },
                        {4, "AnswerA" },
                        {5, "AnswerB" },
                        {6, "AnswerC" },
                        {7, "AnswerD" },
                        {8, "Import failed reason" },
                    };

                var failedRecords = SessionHelper.GetObject<List<ImportQuestionVM>>(HttpContext.Session, "FailedRecords");

                if (failedRecords == null)
                {
                    throw new Exception();
                }

                // Step 3: Convert to IEnumerable
                IEnumerable<ImportQuestionVM> enumerableItems = failedRecords;

                // Step 4: Get File stream
                Stream fileStream = await _excelService.ExportExcel(fileName, titles, enumerableItems);

                // Step 5: Return file for downloading
                return File(fileStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{fileName}.csv");
            }
            catch (Exception)
            {
                ToastHelper.ShowError(TempData, "Error while exporting questions");
                return RedirectToAction("ImportResult");
            }
        }



    }
}
