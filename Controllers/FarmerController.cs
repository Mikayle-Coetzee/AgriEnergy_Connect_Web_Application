#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2023
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
    /// 
    /// </summary>
    public class FarmerController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<FarmerController> _logger;

        /// <summary>
        /// 
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// 
        /// </summary>
        private readonly ValidationClass _validate = new();

        /// <summary>
        /// 
        /// </summary>
        private readonly WorkerClass _workerClass;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="userRepository"></param>
        /// <param name="roleRepository"></param>
        public FarmerController(ILogger<FarmerController> logger, IUserRepository userRepository, IResourceRepository roleRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _workerClass = new WorkerClass(userRepository, roleRepository);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult AddFarmer()
        {
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

            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddOrEditFarmer(Farmer model)
        {
            if (ModelState.IsValid)
            {
                var existingFarmer = _userRepository.GetFarmerById(model.FarmerID);
                if (existingFarmer != null)
                {
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
                    if (_validate.Validate_String(model.Name) &&
                        _validate.Validate_String(model.Surname) &&
                        _validate.Validate_String(model.Username) &&
                        _validate.Validate_String(model.IDNumber) &&
                        _validate.Validate_Email(model.Email))
                    {
                        _workerClass.AddFarmer(model.Name, model.Surname, model.Email, model.IDNumber,
                                            1, model.Username, model.FarmLocation, model.FarmType,
                                            model.Password);

                        return RedirectToAction("AddFarmer", "Farmer");
                    }
                }
            }

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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult DeleteFarmer(int id)
        {
            var farmer = _userRepository.GetFarmerById(id);
            if (farmer == null)
            {
                return NotFound(); 
            }

            _userRepository.DeleteFarmer(farmer);
            return Ok();
        }

    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
