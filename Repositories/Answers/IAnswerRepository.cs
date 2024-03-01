using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Answers
{
    public interface IAnswerRepository
    {
        Task<bool> AddAnswer(Answer answer);
        Task<bool> UpdateAnswer(Answer answer);
        Task<bool> RemoveAnswer(int id);
    }
}
