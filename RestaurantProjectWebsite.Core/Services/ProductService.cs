using Microsoft.AspNetCore.Mvc;
using RestauranProjectWebsite.Infrastructure.Repositories;
using RestaurantProjectWebsite.Core.Contracts;
using RestaurantProjectWebsite.Core.ViewModels.ProductVMs;
using RestaurantProjectWebsite.Core.ViewModels.RestaurantsVMs;
using RestaurantProjectWebsite.Infrastructure.Data.Enums;
using RestaurantProjectWebsite.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectWebsite.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IApplicationDbRepository repo;

        public ProductService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }
        public async Task<bool> AddProduct(ProductVM productVM, string restaurnatId)
        {
            Product product = new Product();
            if (productVM == null)
            {
                return false;
            }
            product.Name = productVM.Name;
            product.ProductType = (ProductType)Enum.Parse(typeof(ProductType), productVM.ProductType);
            product.SubProductType = (SubProductType)Enum.Parse(typeof(SubProductType), productVM.SubProductType);
            product.Price = productVM.Price;
            product.RestaurantId = product.RestaurantId;

            foreach (var allergy in productVM.Allergies)
            {
                product.Allergies.Add((Allergies)Enum.Parse(typeof(Allergies), allergy));
            }

            await repo.AddAsync<Product>(product);
            await repo.SaveChangesAsync();
            return true;

        }

        public List<ProductVMShort> GetAll(string restaurantId)
        {
            var products = repo.All<Product>().Where(r => r.RestaurantId == Guid.Parse(restaurantId));
            List<ProductVMShort> productVMs = new List<ProductVMShort>();

            foreach (var product in products)
            {
                ProductVMShort productVM = new ProductVMShort()
                {
                    Id = product.Id.ToString(),
                    Name = product.Name,
                    ProductType = product.ProductType.ToString(),
                    SubProductType = product.SubProductType.ToString(),
                    Price = product.Price,
                    RestaurantId = product.RestaurantId.ToString()
                };

                productVMs.Add(productVM);
            }

            return productVMs;
        }

        public List<ProductVMShort> GetAllByCategory(string restaurantId, string category, string? subCategory)
        {
            var products = repo.All<Product>().Where(r => r.RestaurantId == Guid.Parse(restaurantId)
            && r.ProductType == (ProductType)Enum.Parse(typeof(ProductType), category));
            if (subCategory != null)
            {
                products = products.Where(p => p.SubProductType == (SubProductType)Enum.Parse(typeof(SubProductType), subCategory));
            }

            List<ProductVMShort> productVMs = new List<ProductVMShort>();

            foreach (var product in products)
            {
                ProductVMShort productVM = new ProductVMShort()
                {
                    Id = product.Id.ToString(),
                    Name = product.Name,
                    ProductType = product.ProductType.ToString(),
                    SubProductType = product.SubProductType.ToString(),
                    Price = product.Price,
                    RestaurantId = product.RestaurantId.ToString()
                };

                productVMs.Add(productVM);
            }
            return productVMs;           
        }

        public async Task<ProductVM> GetProductById(string id)
        {
            var product = await repo.GetByIdAsync<Product>(id);
          
            ProductVM productVM = new ProductVM()
            {
                Id = product.Id.ToString(),
                Name = product.Name,
                ProductType = product.ProductType.ToString(),
                SubProductType = product.SubProductType.ToString(),
                Price = product.Price,
                RestaurantId = product.RestaurantId.ToString()
            };

            foreach (var allergy in product.Allergies)
            {
                productVM.Allergies.Add(allergy.ToString());
            }

            return productVM;
        }

        public async Task<bool> RemoveProduct(string id)
        {
            var product = await repo.GetByIdAsync<Product>(id);
            if (product == null)
            {
                return false;
            }

            await repo.DeleteAsync<Product>(id);
            await repo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateProduct(ProductVM productVM)
        {
            var product = await repo.GetByIdAsync<Product>(productVM.Id);

            if (productVM == null)
            {
                return false;
            }

            product.Name = productVM.Name;
            product.ProductType = (ProductType)Enum.Parse(typeof(ProductType), productVM.ProductType);
            product.SubProductType = (SubProductType)Enum.Parse(typeof(SubProductType), productVM.SubProductType);
            product.Price = productVM.Price;
            product.RestaurantId = product.RestaurantId;

            foreach (var allergy in productVM.Allergies)
            {
                product.Allergies.Add((Allergies)Enum.Parse(typeof(Allergies), allergy));
            }

            await repo.SaveChangesAsync();
            return true;
        }
    }
}
