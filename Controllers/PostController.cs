#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using Microsoft.AspNetCore.Mvc;
using ST10023767_PROG.Models;
using ST10023767_PROG.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using ST10023767_PROG.Classes;

namespace ST10023767_PROG.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        /// <summary>
        /// Action method to handle adding a new post
        /// </summary>
        /// <param name="model"></param>
        /// <param name="messageImage"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddPost(PostViewModel model, IFormFile messageImage)
        {
            // Check if a message image is provided
            if (messageImage != null)
            {
                // Convert the image to a byte array and assign it to the model
                using (var ms = new System.IO.MemoryStream())
                {
                    messageImage.CopyTo(ms);
                    model.MessageImage = ms.ToArray();
                }
            }

            // Set the date published to the current date and time
            model.DatePublished = DateTime.Now;

            // Set the username of the current user who wrote the post
            model.WrittenByUsername = ServiceLocator.MainViewModel.CurrentUser.Username;

            // Add the post using the repository
            _postRepository.AddPost(model);

            // Set success message to be displayed on the view
            TempData["SuccessMessage"] = "Post added successfully.";

            // Redirect to the FarmingHub action
            return RedirectToAction("FarmingHub");
        }

        /// <summary>
        /// Action method to display the FarmingHub view with all posts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FarmingHub()
        {
            // Retrieve all posts from the repository
            var posts = _postRepository.GetAllPosts();

            // Pass the posts to the view for display
            return View(posts);
        }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
