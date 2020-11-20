using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BokningsSystem_SlutUppgift.Models
{
    public class Giraffe
    {
        public Guid Id { get; set; }
        public string PicId { get; set; }
        [Required]
        [StringLength(35)]
        public string Name { get; set; }
        [Required]
        [Range(400, 600)]
        public int Height { get; set; }
        [Required]
        [Range(0, 40)]
        public int Age { get; set; }
        [Required]
        [StringLength(20)]
        public string Origin { get; set; }
        [Required]
        [Range(0, 1000)]
        public int Price { get; set; }

        public bool IsAvailable { get; set; }
    }
}
