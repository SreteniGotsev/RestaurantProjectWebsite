using RestauranProjectWebsite.Infrastructure.Repositories;
using RestaurantProjectWebsite.Core.Contracts;
using RestaurantProjectWebsite.Core.ViewModels.ProductVMs;
using RestaurantProjectWebsite.Core.ViewModels.ReservationVMs;
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
    public class ReservationService : IReservationService
    {
        private readonly IApplicationDbRepository repo;

        public ReservationService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }
        public async Task<bool> AddReservation(ReservationVM reservationVM, string restaurnatId)
        {
            Reservation reservation = new Reservation();
            if (reservationVM == null)
            {
                return false;
            }

            reservation.Name = reservationVM.Name;
            reservation.NumberOfPeople = reservationVM.NumberOfPeople;
            reservation.Phone = reservationVM.Phone;
            reservation.Date = reservationVM.Date;
            reservation.SpecalRequirements = reservationVM.SpecalRequirements;
            
            
            foreach (var occasion in reservationVM.Ocasions)
            {
                reservation.Ocasions.Add((Ocasions)Enum.Parse(typeof(Ocasions), occasion));
            }

            await repo.AddAsync<Reservation>(reservation);
            await repo.SaveChangesAsync();
            return true;
        }

        public List<ReservationVMShort> GetAllByRestaurantId(string Id)
        {
            var reservations = repo.All<Reservation>().Where(r => r.RestaurantID == Guid.Parse(Id));
            List<ReservationVMShort> reservationVMs = new List<ReservationVMShort>();

            foreach (var reservation in reservations)
            {
                ReservationVMShort reservationVM = new ReservationVMShort()
                {
                    Id= reservation.Id.ToString(),
                    Date = reservation.Date,
                    Name = reservation.Name,
                    NumberOfPeople = reservation.NumberOfPeople,
                    Phone = reservation.Phone
                };

                reservationVMs.Add(reservationVM);
            }

            return reservationVMs;
        }

        public List<ReservationVMShort> GetAllByUserId(string Id)
        {
            var reservations = repo.All<Reservation>().Where(r => r.UserId == Id);
            List<ReservationVMShort> reservationVMs = new List<ReservationVMShort>();

            foreach (var reservation in reservations)
            {
                ReservationVMShort reservationVM = new ReservationVMShort()
                {
                    Id = reservation.Id.ToString(),
                    Date = reservation.Date,
                    Name = reservation.Name,
                    NumberOfPeople = reservation.NumberOfPeople,
                    Phone = reservation.Phone

                };

                reservationVMs.Add(reservationVM);
            }

            return reservationVMs;
        }

        public async Task<ReservationVM> GetReservationById(string Id)
        {
            var reservation = await repo.GetByIdAsync<Reservation>(Id);

            if(reservation == null)
            {
                throw new Exception("No reservation with this Id");
            }

            ReservationVM reservationVM = new ReservationVM()
            {
                Id = reservation.Id.ToString(),
                Date = reservation.Date,
                Name = reservation.Name,
                NumberOfPeople = reservation.NumberOfPeople,
                Phone = reservation.Phone,
                SpecalRequirements = reservation.SpecalRequirements
            };

            foreach (var occasion in reservation.Ocasions)
            {
                reservationVM.Ocasions.Add(occasion.ToString());
            }

            return reservationVM;
        }

        public async Task<bool> RemoveReservation(string Id)
        {
            var reservation = await repo.GetByIdAsync<Reservation>(Id);
            if (reservation == null)
            {
                return false;
            }

            await repo.DeleteAsync<Reservation>(Id);
            await repo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateReservation(ReservationVM reservationVM)
        {
            var reservation = await repo.GetByIdAsync<Reservation>(reservationVM.Id);

            if (reservationVM == null)
            {
                return false;
            }

            reservation.Name = reservationVM.Name;
            reservation.NumberOfPeople = reservationVM.NumberOfPeople;
            reservation.Phone = reservationVM.Phone;
            reservation.Date = reservationVM.Date;
            reservation.SpecalRequirements = reservationVM.SpecalRequirements;

            foreach (var occasion in reservationVM.Ocasions)
            {
                reservation.Ocasions.Add((Ocasions)Enum.Parse(typeof(Ocasions), occasion));
            }

           
            await repo.SaveChangesAsync();
            return true;
        }
    }
}
