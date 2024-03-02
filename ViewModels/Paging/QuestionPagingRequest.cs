using DataAccess.Models;
using ViewModels.Questions;
using ViewModels.Quizzes;

namespace ViewModels.Paging
{
    public class QuestionPagingRequest : PagingRequestBase<Question>
    {
        public List<QuestionVM>? ItemVMs { get; set; }
        public int? QuizId { get; set; }
        public Quiz? Quiz { get; set; }
        public QuizVM? QuizVM { get; set; }
    }
}
