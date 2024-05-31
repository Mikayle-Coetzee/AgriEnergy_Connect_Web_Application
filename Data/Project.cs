#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic; // Added for List<Comment>

namespace ST10023767_PROG.Data
{
    /// <summary>
    /// Represents a project entity stored in the database
    /// </summary>
    [Table("Project")]
    public partial class Project
    {
        /// <summary>
        /// Unique identifier for the project
        /// </summary>
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Content of the project
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string ProjectContent { get; set; }

        /// <summary>
        /// Image associated with the project
        /// </summary>
        [Column(TypeName = "varbinary(MAX)")]
        public byte[] ProjectImage { get; set; }

        /// <summary>
        /// Category of the project
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string ProjectCategory { get; set; }

        /// <summary>
        /// Username of the author of the project
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string WrittenByUsername { get; set; }

        /// <summary>
        /// Date when the project was published
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DatePublished { get; set; }

        /// <summary>
        /// List of comments associated with the project
        /// </summary>
        public List<Comment> Comments { get; set; }
    }

    /// <summary>
    /// Represents a comment entity associated with a project
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Unique identifier for the comment
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id of the project the comment belongs to
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Username of the author of the comment
        /// </summary>
        public string AuthorUsername { get; set; }

        /// <summary>
        /// Content of the comment
        /// </summary>
        public string Content { get; set; }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
