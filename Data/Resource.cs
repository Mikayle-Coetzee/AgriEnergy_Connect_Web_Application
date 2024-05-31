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
    /// Represents a resource entity stored in the database.
    /// </summary>
    [Table("Resources")]
    public partial class Resource
    {
        /// <summary>
        /// Gets or sets the unique identifier of the resource.
        /// </summary>
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource.
        /// </summary>
        [Required]
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the resource.
        /// </summary>
        [Required]
        [Column("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the binary data of the image representing the resource.
        /// </summary>
        [Required]
        [Column("Image")]
        public byte[] Image { get; set; }

        /// <summary>
        /// Gets or sets the binary data of the video representing the resource.
        /// </summary>
        [Column("Video")]
        public byte[] Video { get; set; }

        /// <summary>
        /// Gets or sets the type of the resource (e.g., document, video, etc.).
        /// </summary>
        [Required]
        [Column("Type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the category of the resource (e.g., educational, entertainment, etc.).
        /// </summary>
        [Required]
        [Column("Category")]
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the duration of the resource (applicable for videos).
        /// </summary>
        [Required]
        [Column("Duration")]
        public TimeSpan Duration { get; set; }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
