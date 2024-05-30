using ST10023767_PROG.Data;
using ST10023767_PROG.Models;
using ST10023767_PROG.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ST10023767_PROG.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly LocalDbContext _context;

        public ProductRepository(LocalDbContext context)
        {
            _context = context;
        }

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

        public void UpdateProduct(ProductsViewModel product)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
                return;

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

        public void DeleteProduct(ProductsViewModel product)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
                return;

            _context.Products.Remove(existingProduct);
            _context.SaveChanges();
        }
    }
}
