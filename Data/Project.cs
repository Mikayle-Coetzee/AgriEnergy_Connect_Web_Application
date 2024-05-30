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
    [Table("Project")]
    public partial class Project
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string ProjectContent { get; set; }

        [Column(TypeName = "varbinary(MAX)")]
        public byte[] ProjectImage { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string ProjectCategory { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string WrittenByUsername { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DatePublished { get; set; }
        public List<Comment> Comments { get; set; }
    }

    public class Comment
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string AuthorUsername { get; set; }
        public string Content { get; set; }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//

