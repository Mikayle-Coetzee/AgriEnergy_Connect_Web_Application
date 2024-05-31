#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using ST10023767_PROG.Data;
using ST10023767_PROG.Models;
using ST10023767_PROG.Repositories.Interfaces;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;

namespace ST10023767_PROG.Classes
{
    public class WorkerClass
    {
        public readonly IUserRepository userRepository;
        public readonly IResourceRepository roleRepository;

        /// <summary>
        /// Constructor for WorkerClass.
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="roleRepository"></param>
        public WorkerClass(IUserRepository userRepository, 
            IResourceRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        /// <summary>
        /// Method to add a user
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Surname"></param>
        /// <param name="Email"></param>
        /// <param name="IDNumber"></param>
        /// <param name="UserTypeID"></param>
        /// <param name="Username"></param>
        /// <param name="EmployeeID"></param>
        /// <param name="JobTitle"></param>
        /// <param name="FarmLocation"></param>
        /// <param name="FarmType"></param>
        /// <param name="password"></param>
        /// <param name="RequestApproved"></param>
        public void AddUser(
            string Name, string Surname, string Email, string IDNumber,
            int UserTypeID, string Username, string EmployeeID,
            string JobTitle, string FarmLocation, string FarmType, string password,
            string RequestApproved
            )
        {
            // Hash the password
            (byte[] salt, byte[] hash) = PasswordHasher.HashPassword(password);

            // Create a new User object
            var user = new User()
            {
                Name = Name,
                Surname = Surname,
                Email = Email,
                IDNumber = IDNumber,
                UserTypeID = UserTypeID,
                Username = Username,
                EmployeeID = EmployeeID,
                JobTitle = JobTitle,
                FarmLocation = FarmLocation,
                RequestApproved = RequestApproved,
                FarmType = FarmType,
                PasswordHash = hash,
                PasswordSalt = salt  
            };

            // Add the user to the repository
            userRepository.Add(user);
        }

        /// <summary>
        /// Method to add a farmer
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Surname"></param>
        /// <param name="Email"></param>
        /// <param name="IDNumber"></param>
        /// <param name="UserTypeID"></param>
        /// <param name="Username"></param>
        /// <param name="FarmLocation"></param>
        /// <param name="FarmType"></param>
        /// <param name="password"></param>
        public void AddFarmer(
           string Name, string Surname, string Email, string IDNumber,
           int UserTypeID, string Username, 
            string FarmLocation, string FarmType, string password)
        {
            // Hash the password
            (byte[] salt, byte[] hash) = PasswordHasher.HashPassword(password);

            // Create a new User object
            var user = new User()
            {
                Name = Name,
                Surname = Surname,
                Email = Email,
                IDNumber = IDNumber,
                UserTypeID = UserTypeID,
                Username = Username,
                RequestApprovedBy = ServiceLocator.MainViewModel.CurrentUser.Username,
                RequestApproved = "true",
                FarmLocation = FarmLocation,
                FarmType = FarmType,
                PasswordHash = hash, 
                PasswordSalt = salt  
            };

            // Add the user to the repository
            userRepository.Add(user);
        }

        /// <summary>
        /// Method to get the current user
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentUser()
        {
            return ServiceLocator.MainViewModel.CurrentUser.Username;
        }

        /// <summary>
        /// Method to get the current user type
        /// </summary>
        /// <returns></returns>
        public static int GetCurrentUserType()
        {
            return ServiceLocator.MainViewModel.CurrentUser.UserTypeID;
        }

        /// <summary>
        /// Method to get a user by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User GetUserByUsername(string username)
        {
            if (userRepository.GetUserByUsername(username) == null)
            {
                return null;
            }
            else
            {
                return userRepository.GetUserByUsername(username);

            }
        }

        /// <summary>
        /// Method to handle user login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Login(string username, string password)
        {
            var user = userRepository.GetUserByUsername(username);
            if (user is null)
            {
                return 1;// User not found.
            }

            // Verify the provided password against the stored hash and salt.
            if (!PasswordHasher.VerifyPassword(password, user.PasswordSalt, user.PasswordHash))
            {
                return 2;// Incorrect password.
            }



            return 0;// Successful login.
        }

        /// <summary>
        /// Method to check if a username exists
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsUsernameExists(string username)
        {
            return userRepository.UserExists(username);
        }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
