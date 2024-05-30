using ST10023767_PROG.Data;
using ST10023767_PROG.Models;

namespace ST10023767_PROG.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUsername(string username);
        bool UserExists(string username);
        void Add(User user);
        List<User> GetPendingFarmers();
        User GetFarmerById(int id);
        void UpdateFarmer(User user);
        void DeleteFarmer(User user);
        List<User> GetAllFarmers();
    }
}
