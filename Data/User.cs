#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2023
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
    [Key]
    [Column("Id")]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(MAX)")]
    public string Name { get; set; }

    [Required]
    [Column(TypeName = "varchar(MAX)")]
    public string Surname { get; set; }

    [Required]
    [Column(TypeName = "varchar(MAX)")]
    public string Email { get; set; }

    [Required]
    [Column(TypeName = "varbinary(16)")]
    public byte[] PasswordSalt { get; set; }

    [Required]
    [Column(TypeName = "varbinary(64)")]
    public byte[] PasswordHash { get; set; }

    [Required]
    [Column("UserTypeID")]
    public int UserTypeID { get; set; }

    [Required]
    [Column(TypeName = "varchar(13)")]
    public string IDNumber { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Username { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string EmployeeID { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string JobTitle { get; set; }

    [Column(TypeName = "varchar(MAX)")]
    public string FarmLocation { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string FarmType { get; set; }

    [Column(TypeName = "varchar(MAX)")]
    public string RequestApprovedBy { get; set; }

    [Column(TypeName = "varchar(10)")]
    public string RequestApproved { get; set; }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//

