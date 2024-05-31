#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using ST10023767_PROG.Data;
using ST10023767_PROG.Models;
using System.Collections.Generic;

namespace ST10023767_PROG.Repositories.Interfaces
{
    /// <summary>
    /// Interface for interacting with product data.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Adds a new product.
        /// </summary>
        /// <param name="product">The product to add.</param>
        void AddProduct(ProductsViewModel product);

        /// <summary>
        /// Retrieves all products associated with a specific username.
        /// </summary>
        /// <param name="username">The username associated with the products.</param>
        /// <returns>A list of products associated with the specified username.</returns>
        List<ProductsViewModel> GetProductsByUsername(string username);

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>A list of all products.</returns>
        List<ProductsViewModel> GetAllProducts();

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="product">The product to update.</param>
        void UpdateProduct(ProductsViewModel product);

        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>The product with the specified ID.</returns>
        ProductsViewModel GetProductById(int id);

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <param name="product">The product to delete.</param>
        void DeleteProduct(ProductsViewModel product);
    }
}//★---♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫---★・。。END OF FILE 。。・★---♫ ♬:;;;:♬ ♫:;;;: ♫ ♬:;;;:♬ ♫:;;;: ♫---★//
