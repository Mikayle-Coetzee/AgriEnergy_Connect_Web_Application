#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2023
// Part: 2
#endregion

using Microsoft.AspNetCore.Mvc;
using ST10023767_PROG.Models;
using ST10023767_PROG.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using ST10023767_PROG.Classes;
using ST10023767_PROG.Data;

namespace ST10023767_PROG.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpPost]
        public IActionResult AddProject(ProjectViewModel model, IFormFile projectImage)
        {
            if (projectImage != null)
            {
                using (var ms = new System.IO.MemoryStream())
                {
                    projectImage.CopyTo(ms);
                    model.ProjectImage = ms.ToArray();
                }
            }

            model.DatePublished = DateTime.Now;
            model.WrittenByUsername = ServiceLocator.MainViewModel.CurrentUser.Username; 

            _projectRepository.AddProject(model);

            return RedirectToAction("ProjectCollaboration"); // Redirect back to the main page to see the new post
        }

        [HttpPost]
        public IActionResult AddComment(CommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map the view model data to your domain model
                var comment = new Comment
                {
                    ProjectId = model.ProjectId,
                    AuthorUsername = model.AuthorUsername,
                    Content = model.Content,
                };

                // Call the repository method to add the comment to the database
                _projectRepository.AddComment(comment);

                // Redirect back to the ProjectCollaboration action
                return RedirectToAction("ProjectCollaboration");
            }

            // If ModelState is not valid, return to the view with validation errors
            return View(model);
        }


        [HttpGet]
        public IActionResult ProjectCollaboration()
        {
            var projects = _projectRepository.GetAllProjects();
            return View(projects);
        }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
