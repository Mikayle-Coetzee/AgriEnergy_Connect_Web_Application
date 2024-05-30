#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2023
// Part: 2
#endregion

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace ST10023767_PROG.Data
{
    [Table("Resources")]
    public partial class Resource
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [Column("Description")]
        public string Description { get; set; }

        [Required]
        [Column("Image")]
        public byte[] Image { get; set; }

        [Column("Video")]
        public byte[] Video { get; set; }

        [Required]
        [Column("Type")]
        public string Type { get; set; }

        [Required]
        [Column("Category")]
        public string Category { get; set; }

        [Required]
        [Column("Duration")]
        public TimeSpan Duration { get; set; }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//

