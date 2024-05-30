#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2023
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

namespace ST10023767_PROG.Controllers
{
    public class ResourceController : Controller
    {
        private readonly IResourceRepository _resourceRepository;

        public ResourceController(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public IActionResult EducationalResource()
        {
            var resources = _resourceRepository.GetAll(); 
            var resourceViewModels = resources.Select(resource => new ResourceViewModel(resource)).ToList();

            return View(resourceViewModels);
        }

        [HttpPost]
        public IActionResult UploadResource(ResourceViewModel resourceViewModel, IFormFile image, IFormFile video)
        {

                var resource = new Resource
                {
                    Name = resourceViewModel.Name,
                    Description = resourceViewModel.Description,
                    Type = resourceViewModel.Type,
                    Category = resourceViewModel.Category,
                    Duration = resourceViewModel.Duration 
                };

                if (image != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        image.CopyTo(memoryStream);
                        resource.Image = memoryStream.ToArray();
                    }
                }

                if (video != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        video.CopyTo(memoryStream);
                        resource.Video = memoryStream.ToArray();
                    }
                }

                _resourceRepository.Create(resource);
                _resourceRepository.SaveChanges();

                return RedirectToAction("EducationalResource");
           
        }

    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
