using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BokningsSystem_SlutUppgift.Helpers;
using BokningsSystem_SlutUppgift.Models;
using BokningsSystem_SlutUppgift.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BokningsSystem_SlutUppgift.Controllers
{
    public class BookingsController : Controller
    {
        private bool ValidateBooking(Booking booking)
        {
            bool isValid = true;

            //Check if From date is after To date
            if (booking.From > booking.To)
            {
                ModelState.AddModelError("Booking.From", "Start date cannot be after end date");
                 var CreateBookingViewModel = new CreateBookingViewModel() { Giraffes = DbContext.Giraffes, Booking = booking };
                isValid = false;
            }
            //1. Fetch all bookings with the same GiraffeID as the new one

            List<Booking> oldBookings = DbContext.Bookings.Where(b => b.GiraffeId == booking.GiraffeId).ToList();

            //2. Check if any of the dates in the bookings overlap
            foreach (var oldBooking in oldBookings)
            {
                if (DateHelpers.HasSharedDateInterval(booking.From, booking.To, oldBooking.From, oldBooking.To))
                {
                    ModelState.AddModelError("Booking.From", "Date already occupied.");
                    var createBookingViewModel = new CreateBookingViewModel() { Giraffes = DbContext.Giraffes, Booking = booking };
                    isValid = false;
                }
            }
            return isValid;
        }

        public void TotalCostCounter(Booking booking, Giraffe giraffe)
        {

            var timeBooked = booking.To.Subtract(booking.From).TotalHours;

            var costBooked = (timeBooked * giraffe.Price);

            var costBookedInt = Convert.ToInt32(costBooked);

            booking.TotalCost = costBookedInt;
        }
       
        public IActionResult Index()
        {
            var bookings = DbContext.Bookings;

            return View(bookings);
        }

        public IActionResult Create()
        {
            var CreateBookingViewModel = new CreateBookingViewModel() { Giraffes = DbContext.Giraffes };
            return View(CreateBookingViewModel);
        }

        [HttpPost]

        public IActionResult Create(Booking booking)
        {
            //if (!ValidateBooking(booking))
            //{
            //    var CreateBookingViewModel = new CreateBookingViewModel() { Giraffes = DbContext.Giraffes, Booking = booking };
            //    return View(CreateBookingViewModel);
            //}

            //hämta valda giraffens properties
            var giraffe = DbContext.Giraffes.FirstOrDefault(g => g.Id == booking.GiraffeId);

            if (giraffe == null)
            {
                return RedirectToAction(nameof(Create));
            }

            //räkna ut total kostnad för bokning

            TotalCostCounter(booking, giraffe);

            booking.Id = Guid.NewGuid();
            booking.GiraffeName = giraffe.Name;
            booking.BookerEmail = booking.BookerEmail;

            DbContext.Bookings.Add(booking);

            return Redirect("https://localhost:44338/Bookings");
        }

        public IActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = DbContext.Bookings.SingleOrDefault(b => b.Id == id);


            if (booking == null)
            {
                return NotFound();
            }

            var editBookingViewModel = new EditBookingViewModel() { Booking = booking,  Giraffes = DbContext.Giraffes };
           
            return View(editBookingViewModel);
        }

        [HttpPost]
        public IActionResult Edit(Booking booking)
        {

            if (ModelState.IsValid)
            {
                booking.GiraffeName = DbContext.Giraffes.SingleOrDefault(g => g.Id == booking.GiraffeId).Name;

                var giraffe = DbContext.Giraffes.FirstOrDefault(g => g.Id == booking.GiraffeId);

                TotalCostCounter(booking, giraffe);

                var bookingIndex = DbContext.Bookings.FindIndex(b => b.Id == booking.Id);

                if (bookingIndex == -1)
                {
                    return NotFound();
                }

                DbContext.Bookings[bookingIndex] = booking;
                
                return RedirectToAction(nameof(Index));
            }

            return View(booking);
        }


        public IActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giraffe = DbContext.Bookings.FirstOrDefault(b => b.Id == id);

            if (giraffe == null)
            {
                return NotFound();
            }

            return View(giraffe);

        }

        [HttpPost]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var giraffe = DbContext.Bookings.FirstOrDefault(b => b.Id == id);

            if(giraffe == null)
            {
                return NotFound();
            }

            DbContext.Bookings.Remove(giraffe);

            return RedirectToAction("Index");
        }

    }
}
