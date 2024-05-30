#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2023
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

        public WorkerClass(IUserRepository userRepository, 
            IResourceRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

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

        public static string GetCurrentUser()
        {
            return ServiceLocator.MainViewModel.CurrentUser.Username;
        }

        public static int GetCurrentUserType()
        {
            return ServiceLocator.MainViewModel.CurrentUser.UserTypeID;
        }

        public User GetUserByUsername(string username)
        {
            return userRepository.GetUserByUsername(username);
        }

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

        public bool IsUsernameExists(string username)
        {
            return userRepository.UserExists(username);
        }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
