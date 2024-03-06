using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Quizzes;
using ViewModels.Subjects;

namespace ViewModels.Paging
{
    public class QuizPagingRequest : PagingRequestBase<Quiz>
    {
        public List<QuizVM>? ItemVMs { get; set; }
        public int? SubjectId { get; set; }
        public int? TotalQuestion { get; set; }
    }
}
