using WebClient.Filters;
using WebClient.Helpers;
using WebClient.Models;
using WebClient.Services;
using Core.Enums;
using ViewModels.Accounts;
using ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.Constants;

namespace WebClient.Areas.Shared.Controllers
{
    [Area("Shared")]
    [Route("Shared/[Controller]/[Action]")]
    [Authorize(Roles = "Mentor, Student, ClubManager")]
    public class ProfileController : Controller
    {
        private readonly GoogleDriveService _googleDriveService;
        private readonly ClientService _clientService; // Service for making API requests


        public ProfileController(ClientService clientService, GoogleDriveService googleDriveService)
        {
            _clientService = clientService;
            _googleDriveService = googleDriveService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                UserInfo userInfo = SessionHelper.GetObject<UserInfo>(HttpContext.Session, "UserInfo");

                AccountVM? account = await _clientService.Get<AccountVM>($"{ApiPaths.Profile}/GetProfileInfo?email={userInfo.Email}");

                if (account == null)
                {
                    throw new Exception("Không tìm thấy thông tin tài khoản");
                }
                return View(account);
            }
            catch (Exception ex)
            {
                ToastHelper.ShowError(TempData, ex.Message);
                return View();
            }
        }


        [HttpGet]
        public async Task<IActionResult> Update()
        {
            try
            {
                UserInfo userInfo = SessionHelper.GetObject<UserInfo>(HttpContext.Session, "UserInfo");

                AccountVM? account = await _clientService.Get<AccountVM>($"{ApiPaths.Profile}/GetProfileInfo?email={userInfo.Email}");

                if (account == null)
                {
                    throw new Exception("Không tìm thấy thông tin tài khoản");
                }
                return View(account);
            }
            catch (Exception ex)
            {
                ToastHelper.ShowError(TempData, ex.Message);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AccountVM accountVM, IFormFile? avatarFile)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    UserInfo userInfo = SessionHelper.GetObject<UserInfo>(HttpContext.Session, "UserInfo");
                    string folderPath = $"Users/{accountVM.Email}";

                    if (avatarFile != null && avatarFile.Length > 0)
                    {

                        Tuple<bool, string> fileValidation = FileHelper.IsImageFile(avatarFile, FileSizeLimit.MB5);

                        if (fileValidation.Item1 == false)
                        {
                            throw new Exception(fileValidation.Item2);
                        }

                        accountVM.AvatarUrl = await _googleDriveService.UploadFile(avatarFile, $"avatar", folderPath);
                    }

                    ResponseVM? response = await _clientService.Put<ResponseVM>($"{ApiPaths.Profile}/UpdateProfileInfo", accountVM);

                    if (response == null)
                    {
                        throw new Exception("Cập nhật thông tin thất bại");
                    }

                    if (response.Status == false)
                    {
                        throw new Exception(response.Message);

                    }

                    userInfo.Fullname = accountVM.Fullname;
                    userInfo.AvatarUrl = accountVM.AvatarUrl;
                    SessionHelper.SetObject(HttpContext.Session, "UserInfo", userInfo);

                    ToastHelper.ShowSuccess(TempData, response.Message);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ToastHelper.ShowError(TempData, ex.Message);
            }
            return View(accountVM);
        }
    }
}
