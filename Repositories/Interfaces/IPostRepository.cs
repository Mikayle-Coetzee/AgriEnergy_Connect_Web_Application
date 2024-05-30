using ST10023767_PROG.Models;
using System.Collections.Generic;

namespace ST10023767_PROG.Repositories.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPostRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        void AddPost(PostViewModel post);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<PostViewModel> GetAllPosts();
    }
}
