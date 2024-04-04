using RestaurantProjectWebsite.Core.ViewModels.OrderVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectWebsite.Core.Contracts
{
    public interface IOrderService
    {
        List<OrderVMShort> GetOrdersByUserId(string id);
        List<OrderVMShort> GetOrdersByRestaurantId(string id);
        Task<OrderVM> GetOrder(string id);
        Task<bool> AddOrder(OrderVM order);
        Task<bool> RemoveOrder(string id);

        
    }
}

//- getAllOrdersBy(RestaurantId)                   M
//- getAllOrdersBy(UserId)                         U
//- addOrder                                       U
//- deleteOrder 