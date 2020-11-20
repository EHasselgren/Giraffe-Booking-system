using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BokningsSystem_SlutUppgift.Models.ViewModels
{
    public class CreateBookingViewModel
    {
        public Booking Booking { get; set; }
        public List<Giraffe> Giraffes { get; set; }
    }
}
