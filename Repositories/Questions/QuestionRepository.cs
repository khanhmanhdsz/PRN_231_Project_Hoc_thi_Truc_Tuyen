using DataAccess.FcmsContext;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Questions
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly OnlineExamDbContext _context;
        public QuestionRepository(OnlineExamDbContext context)
        {
            _context = context;
        }
        public Task<bool> AddQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveQuestion(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateQuestion(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
