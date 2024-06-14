using FinanceManagement.DATA.Models;
using FinanceManagement.DATA.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        public async Task<IEnumerable<Project>> Get()
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
