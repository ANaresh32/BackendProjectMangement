using FinanceManagement.DATA.Models;
using FinanceManagement.DATA.Repositories;
using FinanceManagement.DOMAIN.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagement.DOMAIN.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly FinanceDbContext _context;

        public ProjectRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects.Include(p => p.Employee).ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(Guid id)
        {
            return await _context.Projects.Include(p => p.Employee).FirstOrDefaultAsync(p => p.EmployeeId == id);
        }

        public async Task AddProjectAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProjectAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }
    }
}
