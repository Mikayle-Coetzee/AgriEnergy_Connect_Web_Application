#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using ST10023767_PROG.Data;
using ST10023767_PROG.Repositories.Interfaces;

namespace ST10023767_PROG.Repositories
{
    /// <summary>
    /// This class represents a repository for Role entities and extends the RepositoryBase<Role> class.
    /// </summary>
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        /// <summary>
        /// Constructor for creating a new RoleRepository instance
        /// </summary>
        public RoleRepository(LocalDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Retrieve a role by its role name
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public Role GetRoleByName(string roleName)
        {
            return this._dbSet.FirstOrDefault(r => r.RoleName == roleName);
        }

        /// <summary>
        /// Check if a role with the given name exists in the repository
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public bool RoleExists(string roleName)
        {
            return this._dbSet.Any(r => r.RoleName == roleName);
        }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
