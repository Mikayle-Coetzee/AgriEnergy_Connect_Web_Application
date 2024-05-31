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
using ST10023767_PROG.Data;

namespace ST10023767_PROG.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;

        /// <summary>
        /// Constructor injection to get an instance of IProjectRepository
        /// </summary>
        /// <param name="projectRepository"></param>
        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        /// <summary>
        /// Action method to handle adding a new project
        /// </summary>
        /// <param name="model"></param>
        /// <param name="projectImage"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddProject(ProjectViewModel model, IFormFile projectImage)
        {
            // Check if a project image is provided
            if (projectImage != null)
            {
                using (var ms = new System.IO.MemoryStream())
                {
                    projectImage.CopyTo(ms);
                    model.ProjectImage = ms.ToArray(); // Convert the image to byte array and assign to the model
                }
            }

            model.DatePublished = DateTime.Now; // Set the publication date to the current date
            model.WrittenByUsername = ServiceLocator.MainViewModel.CurrentUser.Username; // Set the username of the current user

            _projectRepository.AddProject(model); // Call the repository method to add the project
            TempData["SuccessMessage"] = "Project added successfully."; // Set success message in TempData

            return RedirectToAction("ProjectCollaboration"); // Redirect back to the main page to see the new project
        }

        /// <summary>
        /// Action method to handle adding a new comment to a project
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddComment(CommentViewModel model)
        {
            // Check if the model state is valid
            if (ModelState.IsValid)
            {
                // Map the view model data to the domain model (Comment)
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

        /// <summary>
        /// Action method to display the project collaboration page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ProjectCollaboration()
        {
            var projects = _projectRepository.GetAllProjects(); // Get all projects from the repository
            return View(projects); // Return the projects to the view
        }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
