using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Paging;

namespace Repositories.Quizzes
{
    public interface IQuizRepository
    {
        Task<QuizPagingRequest> GetQuizzes(QuizPagingRequest request);
        Task<QuestionPagingRequest> GetQuizById(QuestionPagingRequest request);
        Task<Quiz> GetQuizById(int id);

        Task<bool> AddQuiz(Quiz quiz);
        Task<bool> UpdateQuiz(Quiz quiz);

        Task<int> SubmitQuiz(QuizHistory history);
    }
}
