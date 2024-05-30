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

        [HttpPost]
        public IActionResult AddPost(PostViewModel model, IFormFile messageImage)
        {
            if (messageImage != null)
            {
                using (var ms = new System.IO.MemoryStream())
                {
                    messageImage.CopyTo(ms);
                    model.MessageImage = ms.ToArray();
                }
            }

            model.DatePublished = DateTime.Now;
            model.WrittenByUsername = ServiceLocator.MainViewModel.CurrentUser.Username; 

            _postRepository.AddPost(model);
            TempData["SuccessMessage"] = "Post added successfully.";


            return RedirectToAction("FarmingHub"); 
        }

        [HttpGet]
        public IActionResult FarmingHub()
        {
            var posts = _postRepository.GetAllPosts();
            return View(posts);
        }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
