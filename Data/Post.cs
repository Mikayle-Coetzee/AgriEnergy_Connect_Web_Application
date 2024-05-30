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
    [Table("Post")]
    public partial class Post
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string MessageContent { get; set; }

        [Column(TypeName = "varbinary(MAX)")]
        public byte[] MessageImage { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string MessageCategory { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string WrittenByUsername { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DatePublished { get; set; }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//

