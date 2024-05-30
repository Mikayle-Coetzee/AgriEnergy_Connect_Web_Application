#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2023
// Part: 2
#endregion

using ST10023767_PROG.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ST10023767_PROG.Classes
{
    /// <summary>
    /// This class represents the MainViewModel for the application and manages a collection of users.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets an ObservableCollection to hold the Users
        /// </summary>
        public ObservableCollection<RegisterViewModel> Users { get; set; }

        /// <summary>
        /// Represents the current selected user.
        /// </summary>
        private RegisterViewModel _currentUser;

        /// <summary>
        /// Gets or sets the current selected user.
        /// </summary>
        public RegisterViewModel CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        /// <summary>
        /// Event raised when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Default constructor of the MainViewModel.
        /// </summary>
        public MainViewModel()
        {
            Users = new ObservableCollection<RegisterViewModel>();
            Users.Clear();
        }

        /// <summary>
        /// This method will add a user to the Users collection.
        /// </summary>
        /// <param name="user">The user to add</param>
        public void Add(RegisterViewModel user)
        {
            // Add the user to the Users collection
            Users.Add(user);

            // Notify subscribers that the Users property has changed
            OnPropertyChanged(nameof(Users));
        }

        /// <summary>
        /// This method will raise the PropertyChanged event for a specified property
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
