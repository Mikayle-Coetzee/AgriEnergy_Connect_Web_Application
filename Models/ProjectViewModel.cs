#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using System;
using System.Collections.Generic; 

namespace ST10023767_PROG.Models
{
    /// <summary>
    /// View model for a project.
    /// </summary>
    public class ProjectViewModel
    {
        /// <summary>
        /// Unique identifier for the project.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Content of the project.
        /// </summary>
        public string ProjectContent { get; set; }

        /// <summary>
        /// Image associated with the project.
        /// </summary>
        public byte[] ProjectImage { get; set; }

        /// <summary>
        /// Category of the project.
        /// </summary>
        public string ProjectCategory { get; set; }

        /// <summary>
        /// Username of the user who wrote the project.
        /// </summary>
        public string WrittenByUsername { get; set; }

        /// <summary>
        /// Date when the project was published.
        /// </summary>
        public DateTime DatePublished { get; set; }

        /// <summary>
        /// Comments associated with the project.
        /// </summary>
        public List<CommentViewModel> Comments { get; set; }
    }
}
//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
