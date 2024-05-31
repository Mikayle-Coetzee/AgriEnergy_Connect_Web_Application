#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using ST10023767_PROG.Data;
using ST10023767_PROG.Models;
using ST10023767_PROG.Repositories;
using ST10023767_PROG.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    /// <summary>
    /// Constructor for UserRepository.
    /// </summary>
    /// <param name="context">The database context.</param>
    public UserRepository(LocalDbContext context) : base(context) { }

    /// <summary>
    /// Retrieves a user by username.
    /// </summary>
    /// <param name="username">The username to search for.</param>
    /// <returns>The user with the specified username.</returns>
    public User GetUserByUsername(string username)
    {
        return this._dbSet.FirstOrDefault(u => u.Username == username);
    }

    /// <summary>
    /// Checks if a user exists by username.
    /// </summary>
    /// <param name="username">The username to check.</param>
    /// <returns>True if the user exists, otherwise false.</returns>
    public bool UserExists(string username)
    {
        return this._dbSet.Any(u => u.Username == username);
    }

    /// <summary>
    /// Adds a new user.
    /// </summary>
    /// <param name="user">The user to add.</param>
    public void Add(User user)
    {
        this._dbSet.Add(user);
        _context.SaveChanges();
    }

    /// <summary>
    /// Retrieves pending farmers.
    /// </summary>
    /// <returns>A list of pending farmers.</returns>
    public List<RegisterViewModel> GetPendingFarmers()
    {
        return this._dbSet.Where(f => f.UserTypeID == 1 && f.RequestApproved == "false")
            .Select(u => new RegisterViewModel
            {
                Id = u.Id,
                Name = u.Name,
                Surname = u.Surname,
                Email = u.Email,
                UserTypeID = u.UserTypeID,
                IDNumber = u.IDNumber,
                Username = u.Username,
                EmployeeID = u.EmployeeID,
                JobTitle = u.JobTitle,
                FarmLocation = u.FarmLocation,
                FarmType = u.FarmType
            })
            .ToList();
    }

    /// <summary>
    /// Retrieves a farmer by ID.
    /// </summary>
    /// <param name="id">The ID of the farmer.</param>
    /// <returns>The farmer with the specified ID.</returns>
    public RegisterViewModel GetFarmerById(int id)
    {
        var user = this._dbSet.FirstOrDefault(u => u.Id == id && u.UserTypeID == 1);
        if (user == null) return null;

        return new RegisterViewModel
        {
            Id = user.Id,
            Name = user.Name,
            Surname = user.Surname,
            Email = user.Email,
            UserTypeID = user.UserTypeID,
            IDNumber = user.IDNumber,
            Username = user.Username,
            EmployeeID = user.EmployeeID,
            JobTitle = user.JobTitle,
            FarmLocation = user.FarmLocation,
            FarmType = user.FarmType
        };
    }

    /// <summary>
    /// Updates a farmer.
    /// </summary>
    /// <param name="user">The farmer to update.</param>
    public void UpdateFarmer(RegisterViewModel user)
    {
        //this._dbSet.Update(user);
        //_context.SaveChanges();
    }


    /// <summary>
    /// Deletes a farmer.
    /// </summary>
    /// <param name="user">The farmer to delete.</param>
    public void DeleteFarmer(RegisterViewModel user)
    {
        var existingUser = _context.Users.FirstOrDefault(p => p.Id == user.Id);
        if (existingUser == null)
            return;

        _context.Users.Remove(existingUser);
        _context.SaveChanges();
    }

    /// <summary>
    /// Retrieves all farmers.
    /// </summary>
    /// <returns>A list of all farmers.</returns>
    public List<RegisterViewModel> GetAllFarmers()
    {
        return _context.Users
            .Where(u => u.UserTypeID == 1)
            .Select(u => new RegisterViewModel
            {
                Id = u.Id,
                Name = u.Name,
                Surname = u.Surname,
                Email = u.Email,
                UserTypeID = u.UserTypeID,
                IDNumber = u.IDNumber,
                Username = u.Username,
                EmployeeID = u.EmployeeID,
                JobTitle = u.JobTitle,
                FarmLocation = u.FarmLocation,
                FarmType = u.FarmType
            })
            .ToList();
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
