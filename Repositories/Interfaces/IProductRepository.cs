﻿#region Documentation Header
// Author: Mikayle Coetzee (ST10023767)
// Course: PROG7311 POE 2024
// Part: 2
#endregion

using ST10023767_PROG.Data;
using ST10023767_PROG.Models;
using System.Collections.Generic;

namespace ST10023767_PROG.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(ProductsViewModel product);
        List<ProductsViewModel> GetProductsByUsername(string username);
        List<ProductsViewModel> GetAllProducts();
        void UpdateProduct(ProductsViewModel product);
        ProductsViewModel GetProductById(int id);
        void DeleteProduct(ProductsViewModel product);


    }
}
