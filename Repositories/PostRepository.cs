#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using ST10023767_PROG.Data;
using ST10023767_PROG.Models;
using ST10023767_PROG.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ST10023767_PROG.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly LocalDbContext _context;

        /// <summary>
        /// Constructor to inject the database context
        /// </summary>
        /// <param name="context"></param>
        public PostRepository(LocalDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method to add a new post
        /// </summary>
        /// <param name="post"></param>
        public void AddPost(PostViewModel post)
        {
            // Create a new Post entity from the ViewModel
            var newPost = new Post
            {
                MessageContent = post.MessageContent,
                MessageImage = post.MessageImage,
                MessageCategory = post.MessageCategory,
                WrittenByUsername = post.WrittenByUsername,
                DatePublished = post.DatePublished
            };

            // Add the new post to the database context and save changes
            _context.Posts.Add(newPost);
            _context.SaveChanges();
        }

        /// <summary>
        /// Method to get all posts
        /// </summary>
        /// <returns></returns>
        public List<PostViewModel> GetAllPosts()
        {
            // Select all posts from the database context and convert them to PostViewModel objects
            return _context.Posts
                .Select(p => new PostViewModel
                {
                    Id = p.Id,
                    MessageContent = p.MessageContent,
                    MessageImage = p.MessageImage,
                    MessageCategory = p.MessageCategory,
                    WrittenByUsername = p.WrittenByUsername,
                    DatePublished = p.DatePublished
                })
                .ToList();
        }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
