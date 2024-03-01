using Microsoft.AspNetCore.Mvc;
using WebClient.Services;
using Core.Helpers;
using ViewModels.Paging;
using ViewModels.Accounts;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Core.Constants;
using DataAccess.Models;
using Core.Helpers;
using WebClient.Filters;
using WebClient.Helpers;
using ViewModels.Accounts;
using WebClient;
using ViewModels;
using FCMS.Client.Constants;

namespace WebClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {

        private readonly ClientService _clientService;

        public UserController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> Index( AccountPagingRequest request)
        {
            try
            {
      
                request.SearchTerm = StringHelper.RefinedSearchTerm(request.SearchTerm);
                request.RoleName = RoleName.Student;

                AccountPagingRequest response = await _clientService.Post<AccountPagingRequest>(ApiPaths.Admin + "/Account/GetAll", request);
                if (response == null)
                {
                    ToastHelper.ShowError(TempData, "Không nhận được dữ liệu trả về");
                    throw new Exception();
                }

                return View(response);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return View(request);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(AccountPagingRequest request)
        {
            return RedirectToAction(nameof(Index), request);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
              

            }
            catch (Exception ex)
            {
                ToastHelper.ShowError(TempData, ex.Message);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccountVM request, bool isSubmit)
        {
            try
            {
              

                if (ModelState.IsValid && isSubmit)
                {
                    request.Roles = new List<string> { RoleName.Mentor };

                    ResponseVM? response = await _clientService.Post<ResponseVM>(ApiPaths.Admin + "/Account/CreateAccountManual", request);
                    if (response != null)
                    {

                        if (response.Status)
                        {
                            ToastHelper.ShowSuccess(TempData, response.Message);
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ToastHelper.ShowWarning(TempData, response.Message);
                            return View(request);
                        }
                    }
                    else
                    {
                        ToastHelper.ShowError(TempData, "Lỗi API");
                        return RedirectToAction("Error500", "Error", new { area = "" });
                    }
                }
                else
                {
                    return View(request);
                }
            }
            catch (Exception)
            {

                return View(request);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AccountVM request)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    request.Roles = new List<string> { RoleName.Student };

                    ResponseVM response = await _clientService.Post<ResponseVM>(ApiPaths.Admin + "/Account/UpdateAccountManual", request);
                    if (response == null)
                    {
                        throw new Exception("Không nhận được dữ liệu trả về khi chỉnh sửa mentor");
                    }

                    if (!response.Status)
                    {

                        throw new Exception(response.Message);
                    }

                    ToastHelper.ShowSuccess(TempData, response.Message);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(request);
                }
            }
            catch (Exception ex)
            {
                ToastHelper.ShowError(TempData, ex.Message);
                return View(request);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update([FromQuery] string email)
        {
            try
            {
                if (String.IsNullOrEmpty(email))
                {
                    throw new Exception("Hãy chọn 1 mentor để xem thông tin.");
                }


                AccountVM? account = await _clientService.Get<AccountVM>($"{ApiPaths.Admin}/Account/GetAccountByEmail?email={email}");

                if (account == null)
                {
                    throw new Exception($"Người dùng có email '{email}' không tồn tại.");
                }

                AccountVM updateAccountVM = new AccountVM()
                {
                    Email = email,
                    Fullname = account.Fullname,
                    IsAccountActive = account.IsAccountActive,
                    RoleName = account.RoleName,
                };
                return View(updateAccountVM);
            }
            catch (Exception ex)
            {
                ToastHelper.ShowInfo(TempData, ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromQuery] string email)
        {
            try
            {
                if (String.IsNullOrEmpty(email))
                {
                    throw new Exception("Hãy chọn 1 mentor để chỉnh sửa thông tin.");
                }


                AccountVM? account = await _clientService.Get<AccountVM>($"{ApiPaths.Admin}/Account/GetAccountByEmail?email={email}");

                if (account == null)
                {
                    throw new Exception($"Người dùng có email '{email}' không tồn tại.");
                }

                AccountVM updateAccountVM = new AccountVM()
                {
                    Email = email,
                    Fullname = account.Fullname,
                    IsAccountActive = account.IsAccountActive,
                    RoleName = account.RoleName,
                };

                return View(updateAccountVM);
            }
            catch (Exception ex)
            {
                ToastHelper.ShowInfo(TempData, ex.Message);
                return RedirectToAction("Index");
            }
        }
    }
}
