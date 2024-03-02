using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels;
using ViewModels.Questions;
using Repositories.Subjects;
using ViewModels.Paging;
using DataAccess.Models;
using ViewModels.Subjects;
using Repositories.Questions;
using Core.Constants;
using System.Globalization;
using System.Security.Claims;
using Core.Helpers;

namespace WebApi.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [Route("api/Admin/[controller]/[action]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IQuestionRepository _repository;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> ImportFromFile([FromBody] List<ImportQuestionVM> records)
        {
            try
            {
                var validRecords = new List<ImportQuestionVM>();
                foreach (var item in records)
                {
                    if (string.IsNullOrEmpty(item.Title))
                    {
                        item.ImportMessage = "Tile must not be empty";
                        continue;
                    }

                    if (string.IsNullOrEmpty(item.AnswerA)
                        || string.IsNullOrEmpty(item.AnswerB)
                        || string.IsNullOrEmpty(item.AnswerC)
                        || string.IsNullOrEmpty(item.AnswerD)
                        )
                    {
                        item.ImportMessage = "Answer A, B, C, D must be entered";
                        continue;
                    }

                    if (string.IsNullOrEmpty(item.CorrectAnswer))
                    {
                        item.ImportMessage = "Correct answer must not be empty";
                        continue;
                    }

                    validRecords.Add(item);
                }

                foreach(var item in validRecords)
                {
                    PropertyLogger.LogAllProperties(item);
                }

                var questions = _mapper.Map<List<Question>>(validRecords);

                await _repository.AddQuestions(questions);

                return Ok(records);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetQuestionById([FromQuery] int questionId)
        {
            try
            {
                Question question = await _repository.GetQuestionById(questionId);

                if (question == null)
                {
                    return NotFound();
                }

                QuestionVM questionVM = _mapper.Map<QuestionVM>(question);
                return Ok(questionVM);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuestion([FromBody] QuestionVM questionVM)
        {
            try
            {
                if (questionVM == null)
                {
                    throw new Exception("Didn't recieved question information");
                }


                var question = _mapper.Map<Question>(questionVM);

                bool status = await _repository.UpdateQuestion(question);
                if (!status)
                {
                    throw new Exception("Update question failed!");
                }

                return Ok(new ResponseVM() { Status = true, Message = "Update question successful!" });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseVM() { Status = false, Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion([FromBody] QuestionVM questionVM)
        {
            try
            {
                if (questionVM == null)
                {
                    throw new Exception("Didn't recieved question information");
                }
                // check exist campus
                var question = _mapper.Map<Question>(questionVM);

                //add new campus
                bool status = await _repository.AddQuestion(question);
                if (!status)
                {
                    throw new Exception("Add question failed!");
                }

                return Ok(new ResponseVM() { Status = true, Message = "Add question successful!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
                return Ok(new ResponseVM() { Status = false, Message = ex.Message });
            }
        }
    }
}

