#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using ST10023767_PROG.Data;
using ST10023767_PROG.Models;
using System.Collections.Generic;

namespace ST10023767_PROG.Repositories.Interfaces
{
    /// <summary>
    /// Interface for interacting with user data.
    /// Extends IRepository for the User entity.
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Retrieves a user by username.
        /// </summary>
        /// <param name="username">The username of the user to retrieve.</param>
        /// <returns>The user with the specified username.</returns>
        User GetUserByUsername(string username);

        /// <summary>
        /// Checks if a user exists with the given username.
        /// </summary>
        /// <param name="username">The username to check.</param>
        /// <returns>True if the user exists, otherwise false.</returns>
        bool UserExists(string username);

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="user">The user to add.</param>
        void Add(User user);

        /// <summary>
        /// Retrieves pending farmers.
        /// </summary>
        /// <returns>A list of pending farmers.</returns>
        List<RegisterViewModel> GetPendingFarmers();

        /// <summary>
        /// Retrieves a farmer by ID.
        /// </summary>
        /// <param name="id">The ID of the farmer to retrieve.</param>
        /// <returns>The farmer with the specified ID.</returns>
        RegisterViewModel GetFarmerById(int id);

        /// <summary>
        /// Updates a farmer.
        /// </summary>
        /// <param name="user">The updated farmer information.</param>
        void UpdateFarmer(RegisterViewModel user);

        /// <summary>
        /// Deletes a farmer.
        /// </summary>
        /// <param name="user">The farmer to delete.</param>
        void DeleteFarmer(RegisterViewModel user);

        /// <summary>
        /// Retrieves all farmers.
        /// </summary>
        /// <returns>A list of all farmers.</returns>
        List<RegisterViewModel> GetAllFarmers();
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
