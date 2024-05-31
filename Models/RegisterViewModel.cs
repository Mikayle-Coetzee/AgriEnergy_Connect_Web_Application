#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using ST10023767_PROG.Data;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST10023767_PROG.Models
{
    /// <summary>
    /// View model for user registration.
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// Unique identifier for the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the user.
        /// </summary>
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        /// <summary>
        /// Surname of the user.
        /// </summary>
        [Required(ErrorMessage = "Surname is required")]
        public string? Surname { get; set; }

        /// <summary>
        /// Username of the user.
        /// </summary>
        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }

        /// <summary>
        /// Password of the user.
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        /// <summary>
        /// Confirmation password of the user.
        /// </summary>
        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }

        /// <summary>
        /// Email of the user.
        /// </summary>
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        /// <summary>
        /// Confirmation email of the user.
        /// </summary>
        [Required(ErrorMessage = "Confirm email is required")]
        [Compare("Email", ErrorMessage = "Email and confirmation email do not match.")]
        public string? ConfirmEmail { get; set; }

        /// <summary>
        /// ID number of the user.
        /// </summary>
        [Required(ErrorMessage = "ID required")]
        public string? IDNumber { get; set; }

        /// <summary>
        /// Farm location of the user.
        /// </summary>
        [Required(ErrorMessage = "Farm location is required")]
        public string? FarmLocation { get; set; }

        /// <summary>
        /// Farm type of the user.
        /// </summary>
        [Required(ErrorMessage = "Farm type is required")]
        public string? FarmType { get; set; }

        /// <summary>
        /// Type of the user.
        /// </summary>
        [Required(ErrorMessage = "User type is required")]
        [Range(1, 2, ErrorMessage = "Invalid user type")]
        public int UserTypeID { get; set; }

        /// <summary>
        /// Job title of the user.
        /// </summary>
        [Required(ErrorMessage = "Job title is required")]
        public string? JobTitle { get; set; }

        /// <summary>
        /// Employee ID of the user.
        /// </summary>
        [Required(ErrorMessage = "Employee ID is required")]
        public string? EmployeeID { get; set; }

        /// <summary>
        /// Approval status of the user.
        /// </summary>
        public string RequestApproved { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RegisterViewModel() { }

        /// <summary>
        /// Constructor to initialize a RegisterViewModel from a User entity.
        /// </summary>
        /// <param name="user">The User entity</param>
        public RegisterViewModel(User user)
        {
            Name = user.Name;
            Surname = user.Surname;
            Email = user.Email;
            Username = user.Username;
            IDNumber = user.IDNumber;
            FarmLocation = user.FarmLocation;
            FarmType = user.FarmType;
            UserTypeID = user.UserTypeID;
            JobTitle = user.JobTitle;
            EmployeeID = user.EmployeeID;
            RequestApproved = user.RequestApproved;
        }
    }
}
//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
