#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using System;

namespace ST10023767_PROG.Models
{
    /// <summary>
    /// Represents the view model for a post
    /// </summary>
    public class PostViewModel
    {
        /// <summary>
        /// The unique identifier of the post
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The content of the post
        /// </summary>
        public string MessageContent { get; set; }

        /// <summary>
        /// The image attached to the post (nullable byte array)
        /// </summary>
        public byte[]? MessageImage { get; set; }

        /// <summary>
        /// The category of the post
        /// </summary>
        public string MessageCategory { get; set; }

        /// <summary>
        /// The username of the user who wrote the post
        /// </summary>
        public string WrittenByUsername { get; set; }

        /// <summary>
        /// The date and time when the post was published
        /// </summary>
        public DateTime DatePublished { get; set; }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
