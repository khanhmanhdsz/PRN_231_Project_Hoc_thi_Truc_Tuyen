using DataAccess.FcmsContext;
using DataAccess.Models;
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
        public Task<bool> AddQuiz(Quiz quiz)
        {
            throw new NotImplementedException();
        }

        public Task<QuizPagingRequest> GetQuizzes(QuizPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateQuiz(Quiz quiz)
        {
            throw new NotImplementedException();
        }
    }
}
