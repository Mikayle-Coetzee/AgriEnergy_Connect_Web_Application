#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using ST10023767_PROG.Models;
using System.Collections.Generic;

namespace ST10023767_PROG.Repositories.Interfaces
{
    /// <summary>
    /// Interface for interacting with post data.
    /// </summary>
    public interface IPostRepository
    {
        /// <summary>
        /// Adds a new post.
        /// </summary>
        /// <param name="post">The post to add.</param>
        void AddPost(PostViewModel post);

        /// <summary>
        /// Retrieves all posts.
        /// </summary>
        /// <returns>A list of all posts.</returns>
        List<PostViewModel> GetAllPosts();
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
