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

    public List<User> GetPendingFarmers()
    {
        return this._dbSet.Where(f => f.UserTypeID == 1 && f.RequestApproved == "false").ToList();
    }

    public User GetFarmerById(int id)
    {
        return this._dbSet.FirstOrDefault(u => u.Id == id && u.UserTypeID == 1);
    }

    public void UpdateFarmer(User user)
    {
        this._dbSet.Update(user);
        _context.SaveChanges();
    }


    public void DeleteFarmer(User user)
    {
        var existingFarmer = GetFarmerById(user.Id);
        if (existingFarmer == null)
            return;

        this._dbSet.Remove(existingFarmer);
        _context.SaveChanges();
    }
    public List<User> GetAllFarmers() 
    {
        return this._dbSet.Where(f => f.UserTypeID == 1).ToList();
    }
}
