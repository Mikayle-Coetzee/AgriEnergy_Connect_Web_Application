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
    /// Repository class for managing resources.
    /// </summary>
    public class ResourceRepository : RepositoryBase<Resource>, IResourceRepository
    {
        /// <summary>
        /// Constructor to initialize the resource repository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public ResourceRepository(LocalDbContext context) : base(context)
        {
        }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
