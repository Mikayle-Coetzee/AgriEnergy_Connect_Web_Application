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
    /// <summary>
    /// View model for resources.
    /// </summary>
    public class ResourceViewModel
    {
        /// <summary>
        /// Resource ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Resource name.
        /// </summary>
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        /// <summary>
        /// Resource description.
        /// </summary>
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        /// <summary>
        /// Resource image.
        /// </summary>
        [Required(ErrorMessage = "Image is required")]
        public byte[] Image { get; set; }

        /// <summary>
        /// Resource video.
        /// </summary>
        public byte[] Video { get; set; }

        /// <summary>
        /// Resource type.
        /// </summary>
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }

        /// <summary>
        /// Resource category.
        /// </summary>
        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        /// <summary>
        /// Resource duration.
        /// </summary>
        [Required(ErrorMessage = "Duration is required")]
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ResourceViewModel() { }

        /// <summary>
        /// Constructor to initialize view model from resource entity.
        /// </summary>
        /// <param name="resource">Resource entity.</param>
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
