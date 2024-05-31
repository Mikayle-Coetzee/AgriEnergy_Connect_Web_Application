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
    /// <summary>
    /// Represents the Role entity stored in the "Roles" table.
    /// </summary>
    [Table("Roles")]
    public partial class Role
    {
        /// <summary>
        /// The primary key for the Role entity.
        /// </summary>
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        /// <summary>
        /// The name of the role.
        /// </summary>
        [Column("Role", TypeName = "varchar(50)")]
        public string RoleName { get; set; }
    }//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//

