using Core.Helpers;
using DataAccess.Models;
using Repositories.Authen;
using ViewModels.Authens;
using ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/Authen/[action]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly IAuthenRepository _authenRepository;

        public AuthenController(IAuthenRepository authenRepository)
        {
            _authenRepository = authenRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AccessByEmail([FromBody] SignInVM request)
        {
            try
            {
                Console.WriteLine(request.Email);
                return Ok(await _authenRepository.AccessByEmail(request));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Ok(new ResponseVM() { Status = false, Message = ex.Message });
            }
        }
    }
}
