#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2023
// Part: 2
#endregion

using System;

namespace ST10023767_PROG.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string ProjectContent { get; set; }
        public byte[] ProjectImage { get; set; }
        public string ProjectCategory { get; set; }
        public string WrittenByUsername { get; set; }
        public DateTime DatePublished { get; set; }
        public List<CommentViewModel> Comments { get; set; } // Add this property
    }

}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
