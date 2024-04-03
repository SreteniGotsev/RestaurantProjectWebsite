using RestaurantProjectWebsite.Core.ViewModels.ProductVMs;
using RestaurantProjectWebsite.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectWebsite.Core.Contracts
{
    public interface IProductService
    {
        Task<ProductVM> GetProductById(string Id);
        List<ProductVMShort> GetAll(string restaurantId);
        List<ProductVMShort> GetAllByCategory(string restaurantId, string category,string? subcategory);
        Task<bool> AddProduct(ProductVM product, string restaurantId);
        Task<bool> UpdateProduct(ProductVM product);
        Task<bool> RemoveProduct(string Id);
    }
}

//-getProduct(id)                                 U
//- getAllProducts(RestaurantId)                   U
//- gettAllProductsByCategory(RestaurantId,
//                           CategoryId)          E
//- gettAllProductsByCategory(RestaurantId,
//                           CategoryId,
//                           SubcategoryId)       E
//- editProduct                                    M
//- addProduct                                     M
//- deleteProduct                                  M
