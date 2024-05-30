#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2023
// Part: 2
#endregion

using ST10023767_PROG.Data;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST10023767_PROG.Models
{
    public class RegisterViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Confirm email is required")]
        [Compare("Email", ErrorMessage = "Email and confirmation email do not match.")]
        public string? ConfirmEmail { get; set; }

        [Required(ErrorMessage = "ID required")]
        public string? IDNumber { get; set; }

        [Required(ErrorMessage = "Farm location is required")]
        public string? FarmLocation { get; set; }

        [Required(ErrorMessage = "Farm type is required")]
        public string? FarmType { get; set; }

        [Required(ErrorMessage = "User type is required")]
        [Range(1, 2, ErrorMessage = "Invalid user type")]
        public int UserTypeID { get; set; }


        [Required(ErrorMessage = "Job title is required")]
        public string? JobTitle { get; set; }

        [Required(ErrorMessage = "Employee ID is required")]
        public string? EmployeeID { get; set; }

        public string RequestApproved { get; set; }

        public RegisterViewModel() { }

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Constructor that initializes a StudentClass from a data model 
        /// </summary>
        /// <param name="student"></param>
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
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//

