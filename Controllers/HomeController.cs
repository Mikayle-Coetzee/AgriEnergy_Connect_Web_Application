#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2023
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
    /// 
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        /// <summary>
        /// Validation class instance for string and password validation.
        /// </summary>
        private readonly NewClassLibrary.Classes.ValidationClass validate = new();

        /// <summary>
        /// Worker class instance for handling business logic.
        /// </summary>
        private readonly WorkerClass workerClass;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="userRepository"></param>
        /// <param name="roleRepository"></param>
        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository, IResourceRepository roleRepository)
        {
            _logger = logger;
            workerClass = new WorkerClass(userRepository, roleRepository);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(RegisterViewModel model)
        {
            if (validate.Validate_String(model.Username) && validate.Validate_Password(model.Password))
            {
                var loginResult = workerClass.Login(model.Username, model.Password);

                if (loginResult == 0)
                {
                    var currentUser = workerClass.GetUserByUsername(model.Username);

                    ServiceLocator.MainViewModel.CurrentUser = new RegisterViewModel(currentUser);

                    if (ServiceLocator.MainViewModel.CurrentUser.RequestApproved == "true" ||
                        ServiceLocator.MainViewModel.CurrentUser.UserTypeID == 2)
                    {
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

            return RedirectToAction("Login", "Home");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
                    return RedirectToAction("Login", "Home");

                }
                else
                {
                    //popup the username is already in the database
                }

            }
            else
            {
                //popup the errors

            }


            // If validation fails, return the Register view with validation errors
            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Password()
        {
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult LayoutSidenavLight()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult FarmingHub()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult EducationalResource()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult ProjectCollaboration()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
