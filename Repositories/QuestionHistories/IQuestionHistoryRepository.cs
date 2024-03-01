using DataAccess.Models;

namespace Repositories.QuestionHistories
{
    public interface IQuestionHistoryRepository
    {
        Task<bool> AddQuestionHistory(QuestionHistory questionHistory);
    }
}
