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

        public async Task<SubjectPagingRequest> GetSubjects(SubjectPagingRequest request)
        {
            try
            {
                var query = await _context.Subjects.ToListAsync();
                if (!String.IsNullOrEmpty(request.SearchTerm))
                {
                    query = query.Where(c => c.SubjectName.ToLower().Contains(request.SearchTerm)
                    || c.Description.ToLower().Contains(request.SearchTerm)).ToList();
                }

                //Set totoal pages for paging
                request.TotalRecord = query.Count();
                request.TotalPages = (int)Math.Ceiling(request.TotalRecord / (double)request.PageSize);
                query = query.Skip((request.CurrentPage - 1) * request.PageSize).Take(request.PageSize).ToList();

                request.Items = query.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            return request;
        }

        public async Task<bool> UpdateSubject(Subject subject)
        {
            try
            {
                var existingSubject = await _context.Subjects.SingleOrDefaultAsync(c => c.SubjectId == subject.SubjectId);

                if (existingSubject != null)
                {
                    // Entity exists, so update it
                    _context.Entry(existingSubject).CurrentValues.SetValues(subject);
                }
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
    }
}
