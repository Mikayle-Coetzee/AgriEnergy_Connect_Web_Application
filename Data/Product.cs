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
    /// Represents a product entity
    /// </summary>
    public partial class Product
    {
        /// <summary>
        /// The unique identifier of the product
        /// </summary>
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        /// <summary>
        /// The name of the product
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string ProductName { get; set; }

        /// <summary>
        /// The description of the product
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string ProductDescription { get; set; }

        /// <summary>
        /// The category of the product
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string Category { get; set; }

        // The username of the user who uploaded the product
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Username { get; set; }

        /// <summary>
        /// The price of the product
        /// </summary>
        [Required]
        [Column(TypeName = "decimal (18, 2)")]
        public decimal Price { get; set; }

        /// <summary>
        /// The quantity available for the product
        /// </summary>
        [Required]
        [Column(TypeName = "int")]
        public int QuantityAvaliable { get; set; }

        /// <summary>
        /// The availability status of the product
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Avaliability { get; set; }

        /// <summary>
        /// The image of the product (stored as byte array)
        /// </summary>
        [Required]
        [Column(TypeName = "varbinary(MAX)")]
        public byte[] Image { get; set; }

        /// <summary>
        /// The production date of the product
        /// </summary>
        [Required]
        [Column(TypeName = "date")]
        public DateTime ProducationDate { get; set; }

        /// <summary>
        /// The date when the product was uploaded
        /// </summary>
        [Required]
        [Column(TypeName = "date")]
        public DateTime UploadedDate { get; set; }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
