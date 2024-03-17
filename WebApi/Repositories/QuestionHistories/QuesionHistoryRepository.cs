using DataAccess.FcmsContext;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.QuestionHistories
{
    public class QuesionHistoryRepository : IQuestionHistoryRepository
    {
        private readonly OnlineExamDbContext _context;
        public QuesionHistoryRepository(OnlineExamDbContext context)
        {
            _context = context;
        }
        public Task<bool> AddQuestionHistory(QuestionHistory questionHistory)
        {
            throw new NotImplementedException();
        }
    }
}
