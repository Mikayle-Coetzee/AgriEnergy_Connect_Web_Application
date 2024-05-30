#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

namespace ST10023767_PROG.Classes
{
    /// <summary>
    /// This class provides a service locator pattern for accessing the MainViewModel instance.
    /// </summary>
    public class ServiceLocator
    {
        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Default Constructor of the ServiceLocator class. 
        /// </summary>
        public ServiceLocator() { }

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Private static field to hold the MainViewModel instance.
        /// </summary>
        private static MainViewModel? _mainViewModel;

        //・♫-------------------------------------------------------------------------------------------------♫・//
        /// <summary>
        /// Public static property to access the MainViewModel instance
        /// </summary>
        public static MainViewModel MainViewModel
        {
            get
            {
                //If _mainViewModel is null, create a new instance and assign it to _mainViewModel
                if (_mainViewModel == null)
                    _mainViewModel = new MainViewModel();
                // Return the MainViewModel instance
                return _mainViewModel;
            }
        }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
