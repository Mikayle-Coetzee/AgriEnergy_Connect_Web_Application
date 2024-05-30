#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2023
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
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public ProductController(IProductRepository productRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public IActionResult AddProduct()
        {
            return View();
        }

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

            _productRepository.AddProduct(model);

            return RedirectToAction("ViewMyProducts");
        }

        public IActionResult ViewMyProducts(List<ProductsViewModel> filtered)
        {
            if (ServiceLocator.MainViewModel.CurrentUser != null)
            {
                var username = ServiceLocator.MainViewModel.CurrentUser.Username;

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

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            var model = new ProductsViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Category = product.Category,
                Price = product.Price,
                QuantityAvaliable = product.QuantityAvaliable,
                Avaliability = product.Avaliability,
                ProducationDate = product.ProducationDate
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = _productRepository.GetProductById(model.Id);
                if (product == null)
                {
                    return NotFound();
                }

                // Update the product properties
                product.ProductName = model.ProductName;
                product.ProductDescription = model.ProductDescription;
                product.Category = model.Category;
                product.Price = model.Price;
                product.QuantityAvaliable = model.QuantityAvaliable;
                product.Avaliability = model.Avaliability;
                product.ProducationDate = model.ProducationDate;

                _productRepository.UpdateProduct(product);
                return RedirectToAction("ViewMyProducts");
            }

            return View(model);
        }

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


        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound(); 
            }

            _productRepository.DeleteProduct(product);
            return Ok(); 
        }
    }
}
