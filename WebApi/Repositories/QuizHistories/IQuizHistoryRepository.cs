using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Paging;

namespace Repositories.QuizHistories
{
    public interface IQuizHistoryRepository
    {
        Task<QuizHistoryPagingRequest> GetQuizHistories(QuizHistoryPagingRequest request);


        Task<QuizHistory> GetQuizHistoryById(int id);
        Task<bool> AddQuizHistory(QuizHistory quizHistory);
    }
}
