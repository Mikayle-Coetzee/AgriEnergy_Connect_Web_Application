#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using Microsoft.AspNetCore.Mvc;
using ST10023767_PROG.Classes;
using ST10023767_PROG.Models;
using ST10023767_PROG.Repositories.Interfaces;
using System.Linq;
using Microsoft.Extensions.Logging;
using ST10023767_PROG.Repositories;

namespace ST10023767_PROG.Controllers
{
    /// <summary>
    /// Controller for managing farmer-related actions.
    /// </summary>
    public class FarmerController : Controller
    {
        private readonly ILogger<FarmerController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly ValidationClass _validate = new();
        private readonly WorkerClass _workerClass;
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FarmerController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="roleRepository">The role repository.</param>
        public FarmerController(ILogger<FarmerController> logger, IUserRepository userRepository, IResourceRepository roleRepository, IProductRepository productRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _workerClass = new WorkerClass(userRepository, roleRepository);
            _productRepository = productRepository;
        }

        /// <summary>
        /// Displays the page for adding a new farmer.
        /// </summary>
        /// <returns>The view for adding a new farmer.</returns>
        public IActionResult AddFarmer()
        {
            // Retrieve pending farmers and all farmers from repository
            var pendingFarmers = _userRepository.GetPendingFarmers();
            var model = new FarmerViewModel
            {
                PendingFarmers = pendingFarmers.Select(user => new Farmer
                {
                    FarmerID = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    IDNumber = user.IDNumber,
                    Email = user.Email,
                    FarmLocation = user.FarmLocation,
                    FarmType = user.FarmType,
                    Username = user.Username,
                    Password = "",
                    ConfirmPassword = ""
                }).ToList(),
                AllFarmers = _userRepository.GetAllFarmers().Select(user => new Farmer
                {
                    FarmerID = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    IDNumber = user.IDNumber,
                    Email = user.Email,
                    FarmLocation = user.FarmLocation,
                    FarmType = user.FarmType,
                    Username = user.Username
                }).ToList()
            };

            TempData["SuccessMessage"] = "Farmer added successfully.";

            return View(model);
        }

        /// <summary>
        /// Adds or edits a farmer.
        /// </summary>
        /// <param name="model">The farmer model.</param>
        /// <returns>The action result.</returns>
        [HttpPost]
        public IActionResult AddOrEditFarmer(Farmer model)
        {
            // If model is valid
            if (ModelState.IsValid)
            {
                var existingFarmer = _userRepository.GetFarmerById(model.FarmerID);
                if (existingFarmer != null)
                {
                    // Update existing farmer
                    existingFarmer.Name = model.Name;
                    existingFarmer.Surname = model.Surname;
                    existingFarmer.IDNumber = model.IDNumber;
                    existingFarmer.Email = model.Email;
                    existingFarmer.FarmLocation = model.FarmLocation;
                    existingFarmer.FarmType = model.FarmType;
                    existingFarmer.Username = model.Username;
                    _userRepository.UpdateFarmer(existingFarmer);
                }
                else
                {
                    // If new farmer, validate and add
                    if (_validate.Validate_String(model.Name) &&
                        _validate.Validate_String(model.Surname) &&
                        _validate.Validate_String(model.Username) &&
                        _validate.Validate_String(model.IDNumber) &&
                        _validate.Validate_Email(model.Email))
                    {
                        _workerClass.AddFarmer(model.Name, model.Surname, model.Email, model.IDNumber,
                                            1, model.Username, model.FarmLocation, model.FarmType,
                                            model.Password);

                        TempData["SuccessMessage"] = "Farmer added successfully.";

                        return RedirectToAction("AddFarmer", "Farmer");
                    }
                }
            }

            // If model is not valid, return to add farmer page
            return View("AddFarmer", new FarmerViewModel
            {
                PendingFarmers = _userRepository.GetPendingFarmers().Select(user => new Farmer
                {
                    FarmerID = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    IDNumber = user.IDNumber,
                    Email = user.Email,
                    FarmLocation = user.FarmLocation,
                    FarmType = user.FarmType,
                    Username = user.Username
                }).ToList(),
                AllFarmers = _userRepository.GetAllFarmers().Select(user => new Farmer
                {
                    FarmerID = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    IDNumber = user.IDNumber,
                    Email = user.Email,
                    FarmLocation = user.FarmLocation,
                    FarmType = user.FarmType,
                    Username = user.Username
                }).ToList()
            });
        }

        /// <summary>
        /// Approves a farmer request.
        /// </summary>
        /// <param name="id">The ID of the farmer.</param>
        /// <returns>The action result.</returns>
        [HttpPost]
        public IActionResult ApproveFarmer(int id)
        {
            var farmer = _userRepository.GetFarmerById(id);
            if (farmer != null)
            {
                farmer.RequestApproved = "true";
                _userRepository.UpdateFarmer(farmer);
                return Ok();
            }
            return NotFound();
        }

        /// <summary>
        /// Retrieves a farmer by ID.
        /// </summary>
        /// <param name="id">The ID of the farmer.</param>
        /// <returns>A JSON result containing the farmer.</returns>
        [HttpGet]
        public JsonResult GetFarmer(int id)
        {
            var farmer = _userRepository.GetFarmerById(id);
            if (farmer != null)
            {
                return Json(farmer);
            }
            return Json(null);
        }

        /// <summary>
        /// Deletes a farmer.
        /// </summary>
        /// <param name="id">The ID of the farmer.</param>
        /// <returns>The action result.</returns>
        [HttpPost]
        public IActionResult DeleteFarmer(int id)
        {
            var farmer = _userRepository.GetFarmerById(id);
            if (farmer == null)
            {
                TempData["ErrorMessage"] = "Farmer cannot be deleted.";
                return NotFound();
            }

            // Delete associated products

            var products = _productRepository.GetProductsByUsername(farmer.Username);
            foreach (var product in products)
            {
                _productRepository.DeleteProduct(product);
            }


            _userRepository.DeleteFarmer(farmer);
            TempData["SuccessMessage"] = "Farmer and associated data deleted successfully.";
            return Ok();
        }

    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
