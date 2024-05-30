#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using System;

namespace ST10023767_PROG.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string MessageContent { get; set; }
        public byte[]? MessageImage { get; set; }
        public string MessageCategory { get; set; }
        public string WrittenByUsername { get; set; }
        public DateTime DatePublished { get; set; }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
