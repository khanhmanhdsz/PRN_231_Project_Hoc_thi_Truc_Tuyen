using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Repositories.Accounts;
using Core.Helpers;
using ViewModels.Paging;
using ViewModels.Accounts;
using ViewModels;
using DataAccess.Models;
using Core.Constants;

namespace WebApi.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [Route("api/Admin/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;


        public AccountController(IAccountRepository accountRepository,
            IConfiguration configuration,IMapper mapper)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> GetAll([FromBody] AccountPagingRequest request)
        {
            AccountPagingRequest response = await _accountRepository.GetAll(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAccountByEmail([FromQuery] string email)
        {
            //Get public service paging request
            AccountVM account = await _accountRepository.GetAccountByEmail(email);
            return Ok(account);
        }

        /// <summary>
        /// Create account manual by SuperAdmin
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAccountManual([FromBody] Account request)
        {
            try
            {
                ResponseVM response = await _accountRepository.CreateAccountManualAsync(request, new List<string>() { RoleConstants.Student });

                if (response == null)
                {
                    throw new Exception("Không nhận được dữ liệu trả về khi tạo mới tài khoản");
                }

                // check if have unknow error when create account
                if (!response.Status)
                {
                    return Ok(response);
                }

                return Ok(response);

            }
            catch (Exception ex)
            {
                return Ok(new ResponseVM { Status = false, Message = ex.Message });
            }

        }

    }
}
