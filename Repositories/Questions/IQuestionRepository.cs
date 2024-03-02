using DataAccess.Models;

namespace Repositories.Questions
{
    public interface IQuestionRepository
    {
        Task<Question> GetQuestionById(int id);
        Task<bool> AddQuestion(Question question);
        Task<bool> AddQuestions(List<Question> questions);
        Task<bool> UpdateQuestion(Question question);
        Task<bool> RemoveQuestion(int id);
    }
}
