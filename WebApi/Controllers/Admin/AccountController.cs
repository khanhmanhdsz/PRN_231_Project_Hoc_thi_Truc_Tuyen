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
        private readonly IMapper _mapper;

        public AccountController(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
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
            AccountVM account = await _accountRepository.GetAccountByEmail(email);
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccountManual([FromBody] AccountVM request)
        {
            try
            {
                var account = _mapper.Map<Account>(request);
                var roles = new List<string>() { RoleConstants.Student };
                var response = await _accountRepository.CreateAccountManualAsync(account, roles);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(new ResponseVM { Status = false, Message = ex.Message });
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAccountManual([FromBody] AccountVM request)
        {
            try
            {
                var account = _mapper.Map<Account>(request);
                var roles = new List<string>() { RoleConstants.Student };
                var response = await _accountRepository.UpdateAccountManualAsync(account);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(new ResponseVM { Status = false, Message = ex.Message });
            }

        }

    }
}
