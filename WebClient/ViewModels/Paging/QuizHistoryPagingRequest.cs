using DataAccess.Models;
using ViewModels.QuizHistories;

namespace ViewModels.Paging
{
    public class QuizHistoryPagingRequest : PagingRequestBase<QuizHistory>
    {
        public List<QuizHistoryVM>? ItemVMs { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
