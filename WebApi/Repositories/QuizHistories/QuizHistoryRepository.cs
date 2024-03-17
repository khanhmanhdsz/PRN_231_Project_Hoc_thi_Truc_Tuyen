using DataAccess.FcmsContext;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Paging;

namespace Repositories.QuizHistories
{
    public class QuizHistoryRepository : IQuizHistoryRepository
    {
        private readonly OnlineExamDbContext _context;
        public QuizHistoryRepository(OnlineExamDbContext context)
        {
            _context = context;
        }
        public Task<bool> AddQuizHistory(QuizHistory quizHistory)
        {
            throw new NotImplementedException();
        }

        public async Task<QuizHistoryPagingRequest> GetQuizHistories(QuizHistoryPagingRequest request)
        {
            try
            {
                var query = await _context.QuizHistories
                    .Include(q => q.Account)
                    .Include(q => q.Quiz)
                    .ThenInclude(q => q.Subject)
                    .Include(q => q.QuestionHistories)
                    .ToListAsync();
                if (!String.IsNullOrEmpty(request.Email))
                {
                    query = query.Where(x => x.Account.Email.Equals(request.Email)).ToList();
                }

                if (!String.IsNullOrEmpty(request.SearchTerm))
                {
                    query = query.Where(x => x.Quiz.Title.Equals(request.SearchTerm)).ToList();
                }


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

        public async Task<QuizHistory> GetQuizHistoryById(int id)
        {
            try
            {
                QuizHistory? quiz = await _context.QuizHistories
                    .Include(x => x.Quiz)
                    .Include(x => x.Account)
                    .SingleOrDefaultAsync(x => x.QuizHistoryId == id);


                quiz.QuestionHistories = _context.QuestionHistories
                    .Include(x => x.Question)
                    .Where(x => x.QuizHistoryId == quiz.QuizHistoryId).ToList();

                Console.WriteLine(quiz.QuestionHistories.Count);

                return quiz;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public Task<bool> UpdateQuizHistory(QuizHistory quizHistory)
        {
            throw new NotImplementedException();
        }
    }
}
