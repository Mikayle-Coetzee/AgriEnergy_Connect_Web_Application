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
    /// 
    /// </summary>
    public interface IProjectRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        void AddProject(ProjectViewModel post);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<ProjectViewModel> GetAllProjects();

        void AddComment(Comment comment);

    }
}
