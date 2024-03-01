using DataAccess.Models;
using ViewModels.Paging;

namespace Repositories.Subjects
{
    public interface ISubjectRepository
    {
        Task<SubjectPagingRequest> GetSubjects(SubjectPagingRequest request);
        Task<bool> AddSubject(Subject subject);
        Task<bool> UpdateSubject(Subject subject);
    }
}
