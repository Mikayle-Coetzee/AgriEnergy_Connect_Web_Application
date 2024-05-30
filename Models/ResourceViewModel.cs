#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using ST10023767_PROG.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace ST10023767_PROG.Models
{
    public class ResourceViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]

        public string Description { get; set; }

        [Required(ErrorMessage = "Image is required")]
        public byte[] Image { get; set; }

        public byte[] Video { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }
      
        [Required(ErrorMessage = "Duration is required")]
        public TimeSpan Duration { get; set; }

        public ResourceViewModel() { }

        public ResourceViewModel(Resource resource)
        {
            Id = resource.Id;
            Name = resource.Name;
            Description = resource.Description;
            Image = resource.Image;
            Video = resource.Video;
            Type = resource.Type;
            Category = resource.Category;
            Duration = resource.Duration;
        }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//

