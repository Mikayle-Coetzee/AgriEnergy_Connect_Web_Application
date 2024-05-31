#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ST10023767_PROG.Data;
using ST10023767_PROG.Models;
using ST10023767_PROG.Repositories.Interfaces;
using System;
using System.IO;
using System.Linq;
using MediaToolkit;
using MediaToolkit.Model;

namespace ST10023767_PROG.Controllers
{
    /// <summary>
    /// Controller for managing resources.
    /// </summary>
    public class ResourceController : Controller
    {
        private readonly IResourceRepository _resourceRepository;

        /// <summary>
        /// Constructor to initialize the resource repository.
        /// </summary>
        /// <param name="resourceRepository">The resource repository.</param>
        public ResourceController(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        /// <summary>
        /// Action method for displaying educational resources.
        /// </summary>
        /// <returns>The view containing the educational resources.</returns>
        public IActionResult EducationalResource()
        {
            var resources = _resourceRepository.GetAll();
            var resourceViewModels = resources.Select(resource => new ResourceViewModel(resource)).ToList();
            return View(resourceViewModels);
        }

        /// <summary>
        /// Action method for uploading a resource.
        /// </summary>
        /// <param name="resourceViewModel">The view model containing resource information.</param>
        /// <param name="image">The image file associated with the resource.</param>
        /// <param name="video">The video file associated with the resource.</param>
        /// <returns>Redirects to the educational resources page.</returns>
        [HttpPost]
        public IActionResult UploadResource(ResourceViewModel resourceViewModel, IFormFile image, IFormFile video)
        {
            // Initialize video duration
            TimeSpan videoDuration = TimeSpan.Zero;

            // Calculate video duration if a video file is provided
            if (video != null)
            {
                var filePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    video.CopyTo(stream);
                }

                var inputFile = new MediaFile { Filename = filePath };
                using (var engine = new Engine())
                {
                    engine.GetMetadata(inputFile);
                    videoDuration = inputFile.Metadata.Duration;
                }

                // Delete temporary video file
                System.IO.File.Delete(filePath);
            }

            // Create a new resource object
            var resource = new Resource
            {
                Name = resourceViewModel.Name,
                Description = resourceViewModel.Description,
                Type = resourceViewModel.Type,
                Category = resourceViewModel.Category,
                Duration = videoDuration,
            };

            // Save image data if provided
            if (image != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    image.CopyTo(memoryStream);
                    resource.Image = memoryStream.ToArray();
                }
            }

            // Save video data if provided
            if (video != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    video.CopyTo(memoryStream);
                    resource.Video = memoryStream.ToArray();
                }
            }

            // Add the resource to the repository and save changes
            _resourceRepository.Create(resource);
            _resourceRepository.SaveChanges();

            // Set success message and redirect to educational resources page
            TempData["SuccessMessage"] = "Resource added successfully.";
            return RedirectToAction("EducationalResource");
        }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
