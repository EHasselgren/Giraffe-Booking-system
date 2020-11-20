using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace BokningsSystem_SlutUppgift.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Booker { get; set; }
        [Required(ErrorMessage ="Please enter a valid email address")]
        [EmailAddress]
        public string BookerEmail { get; set; }
       [Required]
        public Guid GiraffeId { get; set; }
        public string GiraffeName { get; set; }
        [Required]
        public DateTime From { get; set; }
        [Required]
        public DateTime To { get; set; }
        public int TotalCost { get; set; }

        
    }

    
}
