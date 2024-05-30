#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using System.Collections.Generic;

namespace ST10023767_PROG.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class FarmerViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int FarmerID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string IDNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ConfirmEmail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FarmLocation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FarmType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Farmer> PendingFarmers { get; set; } = new List<Farmer>();

        /// <summary>
        /// 
        /// </summary>
        public List<Farmer> AllFarmers { get; set; } = new List<Farmer>();
    }

    /// <summary>
    /// 
    /// </summary>
    public class Farmer
    {
        /// <summary>
        /// 
        /// </summary>
        public int FarmerID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string IDNumber { get; set; } 

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FarmLocation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FarmType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ConfirmPassword { get; set; }
    }

}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
