using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Quizzes;
using ViewModels.Paging;

namespace WebApi.Controllers
{
    [Route("api/Quiz/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class QuizController : ControllerBase
    {
        private IQuizRepository _repository;
        private readonly IMapper _mapper;

        public QuizController(IQuizRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }




    }
}
