using ST10023767_PROG.Data;
using ST10023767_PROG.Models;
using ST10023767_PROG.Repositories;
using ST10023767_PROG.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(LocalDbContext context) : base(context) { }

    public User GetUserByUsername(string username)
    {
        return this._dbSet.FirstOrDefault(u => u.Username == username);
    }

    public bool UserExists(string username)
    {
        return this._dbSet.Any(u => u.Username == username);
    }

    public void Add(User user)
    {
        this._dbSet.Add(user);
        _context.SaveChanges();
    }

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

    public void UpdateFarmer(RegisterViewModel user)
    {
        //this._dbSet.Update(user);
        //_context.SaveChanges();
    }


    public void DeleteFarmer(RegisterViewModel user)
    {
        var existingUser = _context.Users.FirstOrDefault(p => p.Id == user.Id);
        if (existingUser == null)
            return;

        _context.Users.Remove(existingUser);
        _context.SaveChanges();
    }

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
}
