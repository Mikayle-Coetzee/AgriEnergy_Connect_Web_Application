#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using Microsoft.AspNetCore.Mvc;
using ST10023767_PROG.Models;
using ST10023767_PROG.Repositories.Interfaces;
using System;
using Microsoft.AspNetCore.Http;
using ST10023767_PROG.Classes;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ST10023767_PROG.Controllers
{
    /// <summary>
    /// Controller for managing products.
    /// </summary>
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Constructor to initialize repositories.
        /// </summary>
        /// <param name="productRepository">Product repository.</param>
        /// <param name="userRepository">User repository.</param>
        public ProductController(IProductRepository productRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Action method for adding a product.
        /// </summary>
        /// <returns></returns>
        public IActionResult AddProduct()
        {
            return View();
        }

        /// <summary>
        /// Post action method for adding a product.
        /// </summary>
        /// <param name="model">Product view model.</param>
        /// <param name="image">Product image.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddProduct(ProductsViewModel model, IFormFile image)
        {
            if (image != null)
            {
                using (var ms = new System.IO.MemoryStream())
                {
                    image.CopyTo(ms);
                    model.Image = ms.ToArray();
                }
            }

            model.UploadedDate = DateTime.Now;
            model.Username = ServiceLocator.MainViewModel.CurrentUser.Username;

            // Add product
            _productRepository.AddProduct(model);
            TempData["SuccessMessage"] = "Product added successfully.";

            return RedirectToAction("ViewMyProducts");
        }

        /// <summary>
        /// Action method for viewing products.
        /// </summary>
        /// <param name="filtered">Filtered products.</param>
        /// <returns></returns>
        public IActionResult ViewMyProducts(List<ProductsViewModel> filtered)
        {
            // Check if user is authenticated
            if (ServiceLocator.MainViewModel.CurrentUser != null)
            {
                var username = ServiceLocator.MainViewModel.CurrentUser.Username;

                // Check user type
                if (ServiceLocator.MainViewModel.CurrentUser.UserTypeID == 1)
                {
                    var products = _productRepository.GetProductsByUsername(username);
                    return View(products);
                }
                else
                {
                    var products = _productRepository.GetAllProducts();
                    if (filtered != null && filtered.Count > 0)
                    {
                        return View(filtered);
                    }
                    else
                    {
                        return View(products);
                    }
                }
            }

            return View();
        }

        /// <summary>
        /// Action method for applying filters to products.
        /// </summary>
        /// <param name="username">Username filter.</param>
        /// <param name="startDate">Start date filter.</param>
        /// <param name="endDate">End date filter.</param>
        /// <param name="category">Category filter.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ApplyFilters(string username, DateTime? startDate, DateTime? endDate, string category)
        {
            var products = _productRepository.GetAllProducts();

            if (!string.IsNullOrEmpty(username))
            {
                products = products.Where(p => p.Username == username).ToList();
            }

            if (startDate.HasValue)
            {
                products = products.Where(p => p.ProducationDate >= startDate.Value).ToList();
            }

            if (endDate.HasValue)
            {
                products = products.Where(p => p.ProducationDate <= endDate.Value).ToList();
            }

            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category == category).ToList();
            }

            return PartialView("_ProductListPartial", products);
        }

        /// <summary>
        /// Action method for deleting a product.
        /// </summary>
        /// <param name="id">ID of the product to delete.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                TempData["ErrorMessage"] = "Product can not be deleted";
                return NotFound();
            }

            _productRepository.DeleteProduct(product);
            TempData["SuccessMessage"] = "Product deleted successfully.";

            return Ok();
        }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
