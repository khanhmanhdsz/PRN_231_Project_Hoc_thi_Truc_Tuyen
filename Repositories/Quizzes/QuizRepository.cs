using DataAccess.FcmsContext;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Paging;

namespace Repositories.Quizzes
{
    public class QuizRepository : IQuizRepository
    {
        private readonly OnlineExamDbContext _context;
        public QuizRepository(OnlineExamDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddQuiz(Quiz quiz)
        {
            try
            {
                await _context.Quizzes.AddAsync(quiz);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return false;
        }

        public async Task<QuestionPagingRequest> GetQuizById(QuestionPagingRequest request)
        {
            try
            {
                var quiz = await _context.Quizzes.SingleOrDefaultAsync(q => q.QuizId == request.QuizId);
                var query = await _context.Questions.Where(q => q.QuizId == request.QuizId).ToListAsync();

                request.Quiz = quiz;
                request.TotalRecord = query.Count();
                request.TotalPages = (int)Math.Ceiling(request.TotalRecord / (double)request.PageSize);
                query = query.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize).ToList();

                request.Items = query.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            return request;
        }

        public async Task<Quiz> GetQuizById(int id)
        {
            try
            {
                var quiz = await _context.Quizzes.Include(q => q.Questions).SingleOrDefaultAsync(q => q.QuizId == id);
                return quiz;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return null;
            }
        }

        public async Task<QuizPagingRequest> GetQuizzes(QuizPagingRequest request)
        {
            try
            {
                var query = await _context.Quizzes.Include(q => q.Subject).ToListAsync();
                if (!String.IsNullOrEmpty(request.SearchTerm))
                {
                    query = query.Where(c => c.Title.ToLower().Contains(request.SearchTerm)
                    || c.Description.ToLower().Contains(request.SearchTerm)).ToList();
                }

                //if (request.SubjectId != 0)
                //{
                //    query = query.Where(q => q.Subject?.SubjectId == request.SubjectId).ToList();
                //}

                //Set totoal pages for paging
                request.TotalRecord = query.Count();
                request.TotalPages = (int)Math.Ceiling(request.TotalRecord / (double)request.PageSize);
                query = query.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize).ToList();

                request.Items = query.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            return request;
        }

        public async Task<int> SubmitQuiz(QuizHistory history)
        {
            try
            {
                _context.Add(history);

                if(await _context.SaveChangesAsync() > 0)
                {
                    return history.QuizHistoryId;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            return 0;
        }

        public async Task<bool> UpdateQuiz(Quiz quiz)
        {
            try
            {
                var existingQuiz = await _context.Quizzes.SingleOrDefaultAsync(c => c.QuizId == quiz.QuizId);

                if (existingQuiz != null)
                {
                    existingQuiz.Title = quiz.Title;
                    existingQuiz.Description = quiz.Description;

                    _context.Update(existingQuiz);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            return false;
        }
    }
}
