#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ST10023767_PROG.Data;

    public partial class User
    {
        /// <summary>
        /// The primary key for the User entity.
        /// </summary>
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        /// <summary>
        /// The name of the user.
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string Name { get; set; }

        /// <summary>
        /// The surname of the user.
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string Surname { get; set; }

        /// <summary>
        /// The email address of the user.
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string Email { get; set; }

        /// <summary>
        /// The salt value used for password hashing.
        /// </summary>
        [Required]
        [Column(TypeName = "varbinary(16)")]
        public byte[] PasswordSalt { get; set; }

        /// <summary>
        /// The hashed password of the user.
        /// </summary>
        [Required]
        [Column(TypeName = "varbinary(64)")]
        public byte[] PasswordHash { get; set; }

        /// <summary>
        /// The ID of the user type.
        /// </summary>
        [Required]
        [Column("UserTypeID")]
        public int UserTypeID { get; set; }

        /// <summary>
        /// The ID number of the user.
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(13)")]
        public string IDNumber { get; set; }

        /// <summary>
        /// The username of the user.
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Username { get; set; }

        /// <summary>
        /// The employee ID of the user.
        /// </summary>
        [Column(TypeName = "varchar(50)")]
        public string EmployeeID { get; set; }

        /// <summary>
        /// The job title of the user.
        /// </summary>
        [Column(TypeName = "varchar(50)")]
        public string JobTitle { get; set; }

        /// <summary>
        /// The farm location of the user.
        /// </summary>
        [Column(TypeName = "varchar(MAX)")]
        public string FarmLocation { get; set; }

        /// <summary>
        /// The type of farm the user owns.
        /// </summary>
        [Column(TypeName = "varchar(50)")]
        public string FarmType { get; set; }

        /// <summary>
        /// The username who approved the user's request.
        /// </summary>
        [Column(TypeName = "varchar(MAX)")]
        public string RequestApprovedBy { get; set; }

        /// <summary>
        /// Indicates whether the user's request is approved.
        /// </summary>
        [Column(TypeName = "varchar(10)")]
        public string RequestApproved { get; set; }
    }//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//

