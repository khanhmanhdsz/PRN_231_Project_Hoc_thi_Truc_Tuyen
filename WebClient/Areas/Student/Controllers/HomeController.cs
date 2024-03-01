
using WebClient.Models;
using WebClient.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebClient.Helpers;
using DataAccess.Models;
using ViewModels.Paging;
using Microsoft.AspNetCore.Authorization;

namespace WebClient.Areas.Student.Controllers
{
    [Area("Student")]
    [Route("Student/[Controller]/[Action]")]
    [Authorize(Roles = "Student")]
    //[ValidateAntiForgeryToken]
    public class HomeController : Controller
    {
        // Dependency injection of services
        private readonly ILogger<HomeController> _logger;
        private readonly ClientService _clientService; // Service for making API requests


        public HomeController(ClientService clientService, ILogger<HomeController> logger)
        {
            _clientService = clientService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("Errors/Error404");
            }
            return View();
        }
    }
}