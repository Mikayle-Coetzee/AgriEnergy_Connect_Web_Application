#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using Microsoft.AspNetCore.Mvc;
using ST10023767_PROG.Classes;
using ST10023767_PROG.Models;
using ST10023767_PROG.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;

namespace ST10023767_PROG.Controllers
{
    /// <summary>
    /// Controller responsible for handling home-related actions.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Validation class instance for string and password validation.
        /// </summary>
        private readonly ValidationClass validate = new();

        /// <summary>
        /// Worker class instance for handling business logic.
        /// </summary>
        private readonly WorkerClass workerClass;

        /// <summary>
        /// Constructor for HomeController.
        /// </summary>
        /// <param name="logger">Logger instance for logging.</param>
        /// <param name="userRepository">User repository instance.</param>
        /// <param name="roleRepository">Role repository instance.</param>
        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository, IResourceRepository roleRepository)
        {
            _logger = logger;
            workerClass = new WorkerClass(userRepository, roleRepository);
        }

        /// <summary>
        /// Action method for displaying the home page.
        /// </summary>
        /// <returns>Returns the index view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Action method for displaying the login page.
        /// </summary>
        /// <returns>Returns the login view.</returns>
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Action method for handling login post request.
        /// </summary>
        /// <param name="model">Login view model containing user credentials.</param>
        /// <returns>Returns redirection to the index action or login view with error message.</returns>
        [HttpPost]
        public IActionResult Login(RegisterViewModel model)
        {
            // Validate user credentials
            if (validate.Validate_String(model.Username) && validate.Validate_Password(model.Password))
            {
                var loginResult = workerClass.Login(model.Username, model.Password);

                if (loginResult == 0)
                {
                    // Retrieve user details
                    var currentUser = workerClass.GetUserByUsername(model.Username);

                    // Set current user in service locator
                    ServiceLocator.MainViewModel.CurrentUser = new RegisterViewModel(currentUser);

                    // Redirect based on user approval and type
                    if (ServiceLocator.MainViewModel.CurrentUser.RequestApproved == "true" ||
                        ServiceLocator.MainViewModel.CurrentUser.UserTypeID == 2)
                    {
                        TempData["SuccessMessage"] = "Welcome!";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = $"No user found with the username '{model.Username}'. Wait for an employee to approve your sign up request.";
                    }
                }
                else if (loginResult == 1)
                {
                    TempData["ErrorMessage"] = $"No user found with the username '{model.Username}'.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Incorrect password.";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid username or password.";
            }

            return RedirectToAction("Login", "Home");
        }


        /// <summary>
        /// Action method for displaying the register page.
        /// </summary>
        /// <returns>Returns the register view.</returns>
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            // Validate user input
            if (validate.Validate_String(model.Name) &&
                validate.Validate_String(model.Surname) &&
                validate.Validate_String(model.Username) &&
                validate.Validate_String(model.IDNumber) &&
                validate.Validate_Email(model.Email) &&
                validate.Validate_Email(model.ConfirmEmail) &&
                (model.Email == model.ConfirmEmail) &&
                validate.Validate_Password(model.Password) &&
                (model.Password == model.ConfirmPassword))
            {
                if (model.UserTypeID == 1)
                {
                    model.RequestApproved = "false";
                }
                else if (model.UserTypeID == 2)
                {
                    model.RequestApproved = "true";
                }

                if (workerClass.GetUserByUsername(model.Username) == null)
                {
                    // Add the user using WorkerClass
                    workerClass.AddUser(model.Name, model.Surname, model.Email, model.IDNumber,
                                        model.UserTypeID, model.Username, model.EmployeeID,
                                        model.JobTitle, model.FarmLocation, model.FarmType,
                                        model.Password, model.RequestApproved);
                    TempData["SuccessMessage"] = "Registration successful. Please log in.";
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    TempData["ErrorMessage"] = "Username is already in use.";
                }
            }
            else
            {

                TempData["ErrorMessage"] = "Invalid input. Please correct the errors and try again.";
            }

            // If validation fails, return the Register view with validation errors
            return View(model);
        }

        /// <summary>
        /// Action method for displaying the privacy page.
        /// </summary>
        /// <returns>Returns the privacy view.</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Action method for displaying the about us page.
        /// </summary>
        /// <returns>Returns the about us view.</returns>
        public IActionResult AboutUs()
        {
            return View();
        }

        /// <summary>
        /// Action method for displaying the farming hub page.
        /// </summary>
        /// <returns>Returns the farming hub view.</returns>
        public IActionResult FarmingHub()
        {
            return View();
        }

        /// <summary>
        /// Action method for displaying the educational resource page.
        /// </summary>
        /// <returns>Returns the educational resource view.</returns>
        public IActionResult EducationalResource()
        {
            return View();
        }

        /// <summary>
        /// Action method for displaying the error page.
        /// </summary>
        /// <returns>Returns the error view.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
