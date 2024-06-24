using FinanceManagement.DATA.Models;
using Microsoft.AspNetCore.Http;
namespace FinanceManagement.DATA.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(Guid id);
        Task<List<Client>> GetAllClientsAsync();
        Task<Client> AddClientAsync( Client client);
        Task<Project> AddNewProjectAsync(Project project);
        Task AddProjectAsync(Project project);
        Task UpdateProjectAsync(Project project );
        Task DeleteProjectAsync(int id);
    }
}
