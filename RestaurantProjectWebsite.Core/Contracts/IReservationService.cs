using RestaurantProjectWebsite.Core.ViewModels.ReservationVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectWebsite.Core.Contracts
{
    public interface IReservationService
    {
        Task<ReservationVM> GetReservationsById(string id);
        List<ReservationVMShort> GetAllByUserId(string Id);
        List<ReservationVMShort> GetAllByRestaurantId(string Id);
        Task<bool> AddReservation(ReservationVM reservation, string restaurnatId);
        Task<bool> UpdateReservation(ReservationVM reservation);
        Task<bool> RemoveReservation(string id);
    }
}
//-getReservationBy(id)                           U, M                           
//-getReservationsBy(UserId)                      U
//-getReservationsBy(RestaurantId)                M
//-addReservation(ReservationVM)                  U, M
//-editReservation(ReservationVM)                 U, M
//-deleteReservation(id)                          U, M
