#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using System.Collections.Generic;

namespace ST10023767_PROG.Models
{
    /// <summary>
    /// View model for representing comments.
    /// </summary>
    public class CommentViewModel
    {
        /// <summary>
        /// Gets or sets the ID of the project associated with the comment.
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the username of the author of the comment.
        /// </summary>
        public string AuthorUsername { get; set; }

        /// <summary>
        /// Gets or sets the content of the comment.
        /// </summary>
        public string Content { get; set; }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
