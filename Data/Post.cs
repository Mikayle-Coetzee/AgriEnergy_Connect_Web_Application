#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST10023767_PROG.Data
{
    /// <summary>
    /// Specifies the table name for the database
    /// </summary>
    [Table("Post")]
    public partial class Post
    {
        /// <summary>
        /// Primary key for the Post entity
        /// </summary>
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Content of the post message
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string MessageContent { get; set; }

        /// <summary>
        /// Image attached to the post message
        /// </summary>
        [Column(TypeName = "varbinary(MAX)")]
        public byte[] MessageImage { get; set; }

        /// <summary>
        /// Category of the post message
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string MessageCategory { get; set; }

        /// <summary>
        /// Username of the user who wrote the post
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string WrittenByUsername { get; set; }

        /// <summary>
        /// Date and time when the post was published
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DatePublished { get; set; }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
