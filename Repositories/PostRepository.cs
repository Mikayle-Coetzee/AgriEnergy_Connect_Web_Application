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

        public PostRepository(LocalDbContext context)
        {
            _context = context;
        }

        public void AddPost(PostViewModel post)
        {
            var newPost = new Post
            {
                MessageContent = post.MessageContent,
                MessageImage = post.MessageImage,
                MessageCategory = post.MessageCategory,
                WrittenByUsername = post.WrittenByUsername,
                DatePublished = post.DatePublished
            };

            _context.Posts.Add(newPost);
            _context.SaveChanges();
        }

        public List<PostViewModel> GetAllPosts()
        {
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
}
