using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Questions
{
    public interface IQuestionRepository
    {
        Task<bool> AddQuestion(Question question);
        Task<bool> UpdateQuestion(Question question);
        Task<bool> RemoveQuestion(int id);
    }
}
