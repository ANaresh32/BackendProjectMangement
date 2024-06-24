using FinanceManagement.DATA.Models;
using FinanceManagement.DATA.Repositories;
using FinanceManagement.DOMAIN.Data;
using Microsoft.AspNetCore.Http;
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
        //Added by Nagaraju
        public async Task<List<Project>> GetAllProjectsAsync()
        {
            var result = await _context.Projects.ToListAsync();
         
           /* foreach (var project in result)
            {
               // var clinetid =  Guid.Parse(project.ProjectID);
                var c =  _context.Clients.FirstOrDefault(x => x.Id==project.ClientId);
            }

          *//*  return (result,client );*/
            return result;
                
        }
        //added by nagaraju
      
        public async Task<Client> AddClientAsync( Client client)
        {
            var checkClientEmail = await _context.Clients.FirstOrDefaultAsync(x => x.ClientEmailId == client.ClientEmailId);
            if (checkClientEmail != null)
            {
                throw new Exception("email already exsit");
            }
            client.Id = new Guid();
            client.CreatedDate=DateTime.UtcNow;
           
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }
        public async Task<Project> AddNewProjectAsync(Project project)
        {
            var checkProjectName = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectName == project.ProjectName);
            if (checkProjectName != null)
            {
                throw new Exception("Project Name already exsits");
            }
            Guid id = new Guid();
            project.CreatedDate = DateTime.UtcNow;

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return project;
        }



        private async Task<string> ConvertFileToBase64(IFormFile file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                byte[] fileBytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(fileBytes);

                // Create the data URI with the appropriate MIME type
                string mimeType = GetMimeType(file.FileName);
                string dataUri = $"data:{mimeType};base64,{base64String}";

                return dataUri;
            }
        }
        private string GetMimeType(string fileName)
        {
            // Get the file extension and map it to the corresponding MIME type
            string extension = Path.GetExtension(fileName).ToLowerInvariant();
            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                // Add more cases as needed for other image formats
                default:
                    throw new NotSupportedException($"File extension '{extension}' is not supported");
            }
        }
        public async Task<Project> GetProjectByIdAsync(Guid id)
        {
            return await _context.Projects.Include(p => p.EmployeeId).FirstOrDefaultAsync(p => p.EmployeeId == id);
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
        public async Task<List<Client>> GetAllClientsAsync()
        {
            var result =  await _context.Clients.ToListAsync();
            return result;
        }
    }
}
