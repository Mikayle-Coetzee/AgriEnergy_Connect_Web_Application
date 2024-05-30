#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2023
// Part: 2
#endregion

using System.ComponentModel.DataAnnotations;
using System;

namespace ST10023767_PROG.Models
{
    public class ProductsViewModel
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public int QuantityAvaliable { get; set; } // Corrected property name

        [Required]
        public string Avaliability { get; set; } // Corrected property name

        public byte[] Image { get; set; }

        [Required]
        public DateTime ProducationDate { get; set; } // Corrected property name

        public DateTime UploadedDate { get; set; }
    }

}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
