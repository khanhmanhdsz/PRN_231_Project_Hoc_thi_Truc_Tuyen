using DataAccess.FcmsContext;
using DataAccess.Models;
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

        public Task<QuizHistoryPagingRequest> GetQuizHistories(QuizHistoryPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<QuizHistory> GetQuizHistoryById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateQuizHistory(QuizHistory quizHistory)
        {
            throw new NotImplementedException();
        }
    }
}
