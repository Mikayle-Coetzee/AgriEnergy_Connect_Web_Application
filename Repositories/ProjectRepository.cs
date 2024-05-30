using ST10023767_PROG.Data;
using ST10023767_PROG.Models;
using ST10023767_PROG.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ST10023767_PROG.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly LocalDbContext _context;

        public ProjectRepository(LocalDbContext context)
        {
            _context = context;
        }

        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void AddProject(ProjectViewModel project)
        {
            var newProject = new Project
            {
                ProjectContent = project.ProjectContent,
                ProjectImage = project.ProjectImage,
                ProjectCategory = project.ProjectCategory,
                WrittenByUsername = project.WrittenByUsername,
                DatePublished = project.DatePublished
            };

            _context.Projects.Add(newProject);
            _context.SaveChanges();
        }

        public List<ProjectViewModel> GetAllProjects()
        {
            return _context.Projects
                .Select(p => new ProjectViewModel
                {
                    Id = p.Id,
                    ProjectContent = p.ProjectContent,
                    ProjectImage = p.ProjectImage,
                    ProjectCategory = p.ProjectCategory,
                    WrittenByUsername = p.WrittenByUsername,
                    DatePublished = p.DatePublished
                })
                .ToList();
        }
    }
}
