using DataAccess.FcmsContext;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Answers
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly OnlineExamDbContext _context;
        public AnswerRepository(OnlineExamDbContext context)
        {
            _context = context;
        }
        public Task<bool> AddAnswer(Answer answer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAnswer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAnswer(Answer answer)
        {
            throw new NotImplementedException();
        }
    }
}
