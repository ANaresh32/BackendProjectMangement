using FinanceManagement.API.Models.Request;
using FinanceManagement.DATA.Models;
using FinanceManagement.DATA.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace FinanceManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;                
        }
        [HttpGet("GetAllProjects")]
        public async Task<List<Project>> Get()
        {
            return await _projectRepository.GetAllProjectsAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> Get(Guid id)
        {
            var project = await _projectRepository.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return project;
        }
        //added by nagaraju
        [HttpGet("getall")]
        public async Task<List<Client>> GetClients()
        {
            List<Client> response = new List<Client>();
            try
            {
                response = await _projectRepository.GetAllClientsAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return response;
        }
        [HttpPost("AddNewClient")]

        public async Task<Client> AddClientAsync (Client client)
        {
            Client response=new Client();
            try
            {
               response = await _projectRepository.AddClientAsync(client);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }
        [HttpPost("AddNewProject")]

        public async Task<Project> AddNewProject(Project project)
        {
            Project response = new Project();
            try
            {
                response = await _projectRepository.AddNewProjectAsync(project);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<Project>> Post([FromBody] Project project)
        {
            await _projectRepository.AddProjectAsync(project);
            return CreatedAtAction(nameof(Get), new { id = project.ProjectID }, project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Project project)
        {
            if (id != project.ProjectID)
            {
                return BadRequest();
            }

            await _projectRepository.UpdateProjectAsync(project);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            /*await _projectRepository.DeleteProjectAsync(id);
            return NoContent();*/
            if (!int.TryParse(id, out int projectId))
            {
                return BadRequest("Invalid project ID format. Project ID must be an integer.");
            }

            try
            {
                await _projectRepository.DeleteProjectAsync(projectId);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            
        }

    }
}
