using ST10023767_PROG.Data;
using ST10023767_PROG.Repositories.Interfaces;

namespace ST10023767_PROG.Repositories
{
    public class ResourceRepository : RepositoryBase<Resource>, IResourceRepository
    {
        public ResourceRepository(LocalDbContext context) : base(context)
        {
        }
    }
}
