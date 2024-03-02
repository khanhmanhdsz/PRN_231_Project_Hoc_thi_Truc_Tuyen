using Core.Helpers;
using DataAccess.Models;
using Repositories.Authen;
using ViewModels.Authens;
using ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Accounts;
using Repositories.Accounts;
using Core.Constants;
using AutoMapper;

namespace WebApi.Controllers
{
    [Route("api/Authen/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenController : ControllerBase
    {
        private readonly IAuthenRepository _authenRepository;
        private readonly IAccountRepository _acccountRepository;
        private readonly IMapper _mapper;

        public AuthenController(IAuthenRepository authenRepository, IAccountRepository accountRepository, IMapper mapper)
        {
            _authenRepository = authenRepository;
            _acccountRepository = accountRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AccessByEmail([FromBody] SignInVM request)
        {
            try
            {
                return Ok(await _authenRepository.AccessByEmail(request));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Ok(new ResponseVM() { Status = false, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] AccountVM request)
        {
            try
            {
                var roles = new List<string>() { RoleConstants.Student };
                var account = _mapper.Map<Account>(request);
                return Ok(await _acccountRepository.CreateAccountManualAsync(account, roles));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Ok(new ResponseVM() { Status = false, Message = ex.Message });
            }
        }
    }
}
