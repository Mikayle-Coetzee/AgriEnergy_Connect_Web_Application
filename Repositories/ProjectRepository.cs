#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

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

        /// <summary>
        /// Constructor injection to get an instance of the database context
        /// </summary>
        /// <param name="context"></param>
        public ProjectRepository(LocalDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method to add a new comment to the database
        /// </summary>
        /// <param name="comment"></param>
        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment); // Add the comment to the Comments DbSet
            _context.SaveChanges(); // Save changes to the database
        }

        /// <summary>
        /// Method to add a new project to the database
        /// </summary>
        /// <param name="project"></param>
        public void AddProject(ProjectViewModel project)
        {
            // Map the view model data to the domain model (Project)
            var newProject = new Project
            {
                ProjectContent = project.ProjectContent,
                ProjectImage = project.ProjectImage,
                ProjectCategory = project.ProjectCategory,
                WrittenByUsername = project.WrittenByUsername,
                DatePublished = project.DatePublished
            };

            _context.Projects.Add(newProject); // Add the project to the Projects DbSet
            _context.SaveChanges(); // Save changes to the database
        }

        /// <summary>
        /// Method to retrieve all projects from the database
        /// </summary>
        /// <returns></returns>
        public List<ProjectViewModel> GetAllProjects()
        {
            // Select projects from the Projects DbSet and map them to ProjectViewModel objects
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
                .ToList(); // Return the projects as a list
        }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
