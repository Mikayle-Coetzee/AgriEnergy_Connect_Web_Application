#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using System.ComponentModel.DataAnnotations;
using System;

namespace ST10023767_PROG.Models
{
    /// <summary>
    /// View model for products.
    /// </summary>
    public class ProductsViewModel
    {
        /// <summary>
        /// Unique identifier for the product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the product.
        /// </summary>
        [Required]
        public string ProductName { get; set; }

        /// <summary>
        /// Description of the product.
        /// </summary>
        [Required]
        public string ProductDescription { get; set; }

        /// <summary>
        /// Category of the product.
        /// </summary>
        [Required]
        public string Category { get; set; }

        /// <summary>
        /// Username of the user who added the product.
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Price of the product.
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        /// <summary>
        /// Quantity available of the product.
        /// </summary>
        [Required]
        public int QuantityAvaliable { get; set; }

        /// <summary>
        /// Availability status of the product.
        /// </summary>
        [Required]
        public string Avaliability { get; set; }

        /// <summary>
        /// Image of the product.
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Production date of the product.
        /// </summary>
        [Required]
        public DateTime ProducationDate { get; set; }

        /// <summary>
        /// Date when the product was uploaded.
        /// </summary>
        public DateTime UploadedDate { get; set; }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
