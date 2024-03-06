using DataAccess.FcmsContext;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using ViewModels.Paging;

namespace Repositories.Subjects
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly OnlineExamDbContext _context;
        public SubjectRepository(OnlineExamDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddSubject(Subject subject)
        {
            try
            {
                await _context.Subjects.AddAsync(subject);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            return false;
        }

        public async Task<Subject> GetSubjectById(int id)
        {
            Subject? subject = new();
            try
            {
                subject = await _context.Subjects
                    .Include(s => s.Quizzes)
                    .ThenInclude(s => s.Questions)
                    .SingleOrDefaultAsync(s => s.SubjectId == id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            return subject;
        }

        public async Task<SubjectPagingRequest> GetSubjects(SubjectPagingRequest request)
        {
            try
            {
                var query = await _context.Subjects.Include(x => x.Quizzes).ToListAsync();
                if (!String.IsNullOrEmpty(request.SearchTerm))
                {
                    query = query.Where(c => c.SubjectName.ToLower().Contains(request.SearchTerm)
                    || c.Description.ToLower().Contains(request.SearchTerm)).ToList();
                }

                //Set totoal pages for paging
                request.TotalRecord = query.Count();
                request.TotalPages = (int)Math.Ceiling(request.TotalRecord / (double)request.PageSize);
                query = query.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize).ToList();

                request.Items = query;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            return request;
        }

        public async Task<List<Subject>> GetSubjects()
        {
            try
            {
                return await _context.Subjects.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            return new List<Subject>();
        }

        public async Task<bool> IsExistedSubject(int subjectId, string subjectName)
        {
            try
            {
                Subject? subject = await _context.Subjects.SingleOrDefaultAsync(s => s.SubjectName.ToLower().Equals(subjectName.ToLower()));
                if (subject != null && subject.SubjectId != subjectId) return true; 
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
                return true;
            }
        }

        public async Task<bool> UpdateSubject(Subject subject)
        {
            try
            {
                var existingSubject = await _context.Subjects.SingleOrDefaultAsync(c => c.SubjectId == subject.SubjectId);

                if (existingSubject != null)
                {
                    existingSubject.SubjectName = subject.SubjectName;
                    existingSubject.Description = subject.Description;

                    _context.Update(existingSubject);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            return false;
        }
    }
}
