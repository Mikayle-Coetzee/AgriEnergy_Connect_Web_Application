#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using System.Collections.Generic;

namespace ST10023767_PROG.Models
{
    /// <summary>
    /// View model for Farmer-related operations.
    /// </summary>
    public class FarmerViewModel
    {
        /// <summary>
        /// Gets or sets the farmer's ID.
        /// </summary>
        public int FarmerID { get; set; }

        /// <summary>
        /// Gets or sets the farmer's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the farmer's surname.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the farmer's ID number.
        /// </summary>
        public string IDNumber { get; set; }

        /// <summary>
        /// Gets or sets the farmer's email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the confirmation email.
        /// </summary>
        public string ConfirmEmail { get; set; }

        /// <summary>
        /// Gets or sets the farmer's farm location.
        /// </summary>
        public string FarmLocation { get; set; }

        /// <summary>
        /// Gets or sets the farmer's farm type.
        /// </summary>
        public string FarmType { get; set; }

        /// <summary>
        /// Gets or sets the farmer's username.
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets the farmer's password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the confirmation password.
        /// </summary>
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the list of pending farmers.
        /// </summary>
        public List<Farmer> PendingFarmers { get; set; } = new List<Farmer>();

        /// <summary>
        /// Gets or sets the list of all farmers.
        /// </summary>
        public List<Farmer> AllFarmers { get; set; } = new List<Farmer>();
    }

    /// <summary>
    /// Model class representing a Farmer.
    /// </summary>
    public class Farmer
    {
        /// <summary>
        /// Gets or sets the farmer's ID.
        /// </summary>
        public int FarmerID { get; set; }

        /// <summary>
        /// Gets or sets the farmer's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the farmer's surname.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the farmer's ID number.
        /// </summary>
        public string IDNumber { get; set; }

        /// <summary>
        /// Gets or sets the farmer's email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the farmer's farm location.
        /// </summary>
        public string FarmLocation { get; set; }

        /// <summary>
        /// Gets or sets the farmer's farm type.
        /// </summary>
        public string FarmType { get; set; }

        /// <summary>
        /// Gets or sets the farmer's username.
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets the farmer's password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the confirmation password.
        /// </summary>
        public string ConfirmPassword { get; set; }
    }

}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
