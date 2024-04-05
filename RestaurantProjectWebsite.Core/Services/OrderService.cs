using Microsoft.AspNetCore.Components;
using RestauranProjectWebsite.Infrastructure.Repositories;
using RestaurantProjectWebsite.Core.Contracts;
using RestaurantProjectWebsite.Core.ViewModels.OrderVMs;
using RestaurantProjectWebsite.Core.ViewModels.ProductVMs;
using RestaurantProjectWebsite.Core.ViewModels.ReservationVMs;
using RestaurantProjectWebsite.Infrastructure.Data.Enums;
using RestaurantProjectWebsite.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectWebsite.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IApplicationDbRepository repo;

        public OrderService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<bool> AddOrder(OrderVM orderVM)
        {
            Order order = new Order();

            if (orderVM == null)
            {
                return false;
            }

            order.CreatedDate = DateTime.Now;
            order.PaymentType = (PaymentType)Enum.Parse(typeof(PaymentType), orderVM.PaymentType);
            order.RestaurantId = Guid.Parse(orderVM.RestaurantId);
            order.UserId = orderVM.UserId;

            foreach (var product in orderVM.Products)
            {
                var productM = await repo.GetByIdAsync<Product>(product.Product.Id);

                if (productM == null)
                {
                    throw new Exception("We couldn't find a product to be added to the order");
                }

                ProductsPerOrder productOrder = new ProductsPerOrder();
                productOrder.Product = productM;
                productOrder.ProductId = productM.Id;
                productOrder.OrderId = order.Id;
                productOrder.Order = order;

                if (int.Parse(product.Quantity) > 10)
                {
                    throw new Exception("You can't order the same product more than 10 times");
                }

                productOrder.Quantity = int.Parse(product.Quantity);
             
                order.Products.Add(productOrder);

            }



            await repo.AddAsync<Order>(order);
            await repo.SaveChangesAsync();
            return true;
        }

        public async Task<OrderVM> GetOrder(string id)
        {
            var order = await repo.GetByIdAsync<Order>(id);

            if (order == null)
            {
                throw new Exception("No order with this Id");
            }

            OrderVM orderVM = new OrderVM()
            {
                Id = id,
                CreatedDate = order.CreatedDate,
                PaymentType = order.PaymentType.ToString(),
                TotalPrice = order.TotalPrice.ToString(),
                RestaurantId = order.RestaurantId.ToString(),
                UserId = order.UserId
            };

            foreach (var product in order.Products)
            {
                ProductVMShort productVM = new ProductVMShort()
                {
                    Id = product.Product.Id.ToString(),
                    Name = product.Product.Name,
                    Price = product.Product.Price,
                    ProductType = product.Product.ProductType.ToString(),
                    SubProductType = product.Product.SubProductType.ToString(),
                };

                ProductPerOrderVM productOrderVM = new ProductPerOrderVM()
                {
                    Product = productVM,
                    Quantity = product.Quantity.ToString(),
                };

                orderVM.Products.Add(productOrderVM);
                
            }

            return orderVM;
        }

        public List<OrderVMShort> GetOrdersByRestaurantId(string id)
        {
            var orders = repo.All<Order>().Where(r => r.RestaurantId == Guid.Parse(id));
            List<OrderVMShort> orderVMs = new List<OrderVMShort>();

            foreach (var order in orders)
            {
                OrderVMShort orderVM = new OrderVMShort()
                {
                    Id = order.Id.ToString(),
                    UserId = order.UserId,
                    CreatedDate = order.CreatedDate,
                    RestaurantId = order.RestaurantId.ToString(),
                    TotalPrice = order.TotalPrice.ToString(),
                };

                orderVMs.Add(orderVM);
            }

            return orderVMs;
        }

        public List<OrderVMShort> GetOrdersByUserId(string id)
        {
            var orders = repo.All<Order>().Where(r => r.UserId == id);
            List<OrderVMShort> orderVMs = new List<OrderVMShort>();

            foreach (var order in orders)
            {
                OrderVMShort orderVM = new OrderVMShort()
                {
                    Id = order.Id.ToString(),
                    UserId = order.UserId,
                    CreatedDate = order.CreatedDate,
                    RestaurantId = order.RestaurantId.ToString(),
                    TotalPrice = order.TotalPrice.ToString(),
                };

                orderVMs.Add(orderVM);
            }

            return orderVMs;
        }

        public async Task<bool> RemoveOrder(string id)
        {
            var reservation = await repo.GetByIdAsync<Order>(id);
            if (reservation == null)
            {
                return false;
            }

            await repo.DeleteAsync<Order>(id);
            await repo.SaveChangesAsync();

            return true;
        }

    }
}
