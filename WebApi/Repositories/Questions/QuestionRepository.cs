using DataAccess.FcmsContext;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Questions;

namespace Repositories.Questions
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly OnlineExamDbContext _context;
        public QuestionRepository(OnlineExamDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddQuestion(Question question)
        {
            try
            {
                await _context.Questions.AddAsync(question);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.ToString()}");
            }
            return false;
        }

        public async Task<bool> AddQuestions(List<Question> questions)
        {
            try
            {
                await _context.AddRangeAsync(questions);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.ToString()}");
            }
            return false;
        }

        public async Task<Question> GetQuestionById(int id)
        {
            try
            {
                return await _context.Questions.SingleOrDefaultAsync(q => q.QuestionId == id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.ToString()}");
            }

            return null;
        }

        public async Task<bool> RemoveQuestion(int id)
        {
            try
            {
                var question = await _context.Questions.SingleOrDefaultAsync(q => q.QuestionId == id);
                var questionHistory = _context.QuestionHistories.Where(q => q.QuestionId == id).ToList();

                if (questionHistory != null)
                {
                    foreach (var item in questionHistory)
                    {
                        _context.QuestionHistories.Remove(item);
                    }
                }

                if (question != null)
                {
                    _context.Questions.Remove(question);
                }

                if (await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return false;
        }

        public async Task<bool> UpdateQuestion(Question question)
        {
            try
            {

                Question? newQuestion = await _context.Questions.SingleOrDefaultAsync(x => x.QuestionId == question.QuestionId);

                if (newQuestion != null)
                {

                    newQuestion.Title = question.Title;
                    newQuestion.AnswerA = question.AnswerA;
                    newQuestion.AnswerB = question.AnswerB;
                    newQuestion.AnswerC = question.AnswerC;
                    newQuestion.AnswerD = question.AnswerD;
                    newQuestion.CorrectAnswer = question.CorrectAnswer;

                    _context.Questions.Update(newQuestion);

                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return true;
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return false;
        }
    }
}
