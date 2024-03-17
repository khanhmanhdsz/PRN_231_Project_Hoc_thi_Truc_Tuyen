using DataAccess.Models;
using ViewModels.Paging;

namespace Repositories.Subjects
{
    public interface ISubjectRepository
    {
        Task<SubjectPagingRequest> GetSubjects(SubjectPagingRequest request);
        Task<List<Subject>> GetSubjects();
        Task<Subject> GetSubjectById(int id);
        Task<bool> AddSubject(Subject subject);
        Task<bool> UpdateSubject(Subject subject);
        Task<bool> IsExistedSubject(int subjectId, string subjectName);

    }
}
