#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using ST10023767_PROG.Data;
using ST10023767_PROG.Models;
using System.Collections.Generic;

namespace ST10023767_PROG.Repositories.Interfaces
{
    /// <summary>
    /// Interface for interacting with project data.
    /// </summary>
    public interface IProjectRepository
    {
        /// <summary>
        /// Adds a new project.
        /// </summary>
        /// <param name="project">The project to add.</param>
        void AddProject(ProjectViewModel project);

        /// <summary>
        /// Retrieves all projects.
        /// </summary>
        /// <returns>A list of all projects.</returns>
        List<ProjectViewModel> GetAllProjects();

        /// <summary>
        /// Adds a comment to a project.
        /// </summary>
        /// <param name="comment">The comment to add.</param>
        void AddComment(Comment comment);
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
