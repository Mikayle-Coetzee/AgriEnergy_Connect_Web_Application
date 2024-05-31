#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using ST10023767_PROG.Data;
using ST10023767_PROG.Models;
using ST10023767_PROG.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ST10023767_PROG.Repositories
{
    /// <summary>
    /// Repository for managing products.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly LocalDbContext _context;

        /// <summary>
        /// Constructor to initialize the database context.
        /// </summary>
        /// <param name="context">Database context.</param>
        public ProductRepository(LocalDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add a new product to the database.
        /// </summary>
        /// <param name="product">Product to add.</param>
        public void AddProduct(ProductsViewModel product)
        {
            // Convert ProductsViewModel to Product entity
            var newProduct = new Product
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Category = product.Category,
                Username = product.Username,
                Price = product.Price,
                QuantityAvaliable = product.QuantityAvaliable,
                Avaliability = product.Avaliability,
                Image = product.Image,
                ProducationDate = product.ProducationDate,
                UploadedDate = product.UploadedDate
            };

            _context.Products.Add(newProduct);
            _context.SaveChanges();
        }

        /// <summary>
        /// Get products by username.
        /// </summary>
        /// <param name="username">Username of the user.</param>
        /// <returns>List of products.</returns>
        public List<ProductsViewModel> GetProductsByUsername(string username)
        {
            // Convert Product entities to ProductsViewModel
            return _context.Products
                .Where(p => p.Username == username)
                .Select(p => new ProductsViewModel
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    ProductDescription = p.ProductDescription,
                    Category = p.Category,
                    Username = p.Username,
                    Price = p.Price,
                    QuantityAvaliable = p.QuantityAvaliable,
                    Avaliability = p.Avaliability,
                    Image = p.Image,
                    ProducationDate = p.ProducationDate,
                    UploadedDate = p.UploadedDate
                })
                .ToList();
        }

        /// <summary>
        /// Get all products from the database.
        /// </summary>
        /// <returns>List of products.</returns>
        public List<ProductsViewModel> GetAllProducts()
        {
            // Convert Product entities to ProductsViewModel
            return _context.Products
                .Select(p => new ProductsViewModel
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    ProductDescription = p.ProductDescription,
                    Category = p.Category,
                    Username = p.Username,
                    Price = p.Price,
                    QuantityAvaliable = p.QuantityAvaliable,
                    Avaliability = p.Avaliability,
                    Image = p.Image,
                    ProducationDate = p.ProducationDate,
                    UploadedDate = p.UploadedDate
                })
                .ToList();
        }

        /// <summary>
        /// Get a product by its ID.
        /// </summary>
        /// <param name="productId">ID of the product.</param>
        /// <returns>Product.</returns>
        public ProductsViewModel GetProductById(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                return null;

            return new ProductsViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Category = product.Category,
                Username = product.Username,
                Price = product.Price,
                QuantityAvaliable = product.QuantityAvaliable,
                Avaliability = product.Avaliability,
                Image = product.Image,
                ProducationDate = product.ProducationDate,
                UploadedDate = product.UploadedDate
            };
        }

        /// <summary>
        /// Update an existing product in the database.
        /// </summary>
        /// <param name="product">Product to update.</param>
        public void UpdateProduct(ProductsViewModel product)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
                return;

            // Update properties
            existingProduct.ProductName = product.ProductName;
            existingProduct.ProductDescription = product.ProductDescription;
            existingProduct.Category = product.Category;
            existingProduct.Price = product.Price;
            existingProduct.QuantityAvaliable = product.QuantityAvaliable;
            existingProduct.Avaliability = product.Avaliability;
            existingProduct.Image = product.Image;
            existingProduct.ProducationDate = product.ProducationDate;
            existingProduct.UploadedDate = product.UploadedDate;

            _context.SaveChanges();
        }

        /// <summary>
        /// Delete a product from the database.
        /// </summary>
        /// <param name="product">Product to delete.</param>
        public void DeleteProduct(ProductsViewModel product)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
                return;

            _context.Products.Remove(existingProduct);
            _context.SaveChanges();
        }
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
