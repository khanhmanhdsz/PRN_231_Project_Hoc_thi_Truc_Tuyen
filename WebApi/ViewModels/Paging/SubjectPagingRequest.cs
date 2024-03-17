using DataAccess.Models;
using ViewModels.Subjects;

namespace ViewModels.Paging
{
    public class SubjectPagingRequest : PagingRequestBase<Subject>
    {
        public List<SubjectVM>? ItemVMs { get; set; }


    }
}
