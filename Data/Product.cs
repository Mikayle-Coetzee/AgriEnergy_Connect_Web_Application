#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2023
// Part: 2
#endregion

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST10023767_PROG.Data
{
    public partial class Product
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string ProductName { get; set; }

        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string ProductDescription { get; set; }

        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string Category { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Username { get; set; }

        [Required]
        [Column(TypeName = "decimal (18, 2)")]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int QuantityAvaliable { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Avaliability { get; set; }

        [Required]
        [Column(TypeName = "varbinary(MAX)")]
        public byte[] Image { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime ProducationDate { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime UploadedDate { get; set; }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//

