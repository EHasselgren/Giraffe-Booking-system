using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BokningsSystem_SlutUppgift.Controllers;

namespace BokningsSystem_SlutUppgift.Models
{
    public class DbContext
    {

        public static List<Giraffe> Giraffes { get; set; }
        public static List<Booking> Bookings { get; }

        static DbContext()
        {
            Giraffes = new List<Giraffe>();
            Bookings = new List<Booking>();

            Seed();
        }

        private static void Seed()
        {
            var giraffe1 = new Giraffe() { Id = Guid.NewGuid(), PicId = "https://images.fineartamerica.com/images/artworkimages/mediumlarge/2/female-giraffe-thomas-retterath.jpg", Name = "Betty", Height = 480, Age = 20, Origin = "Congo", Price = 25 };
            var giraffe2 = new Giraffe() { Id = Guid.NewGuid(), PicId = "https://lh3.googleusercontent.com/proxy/GJk36wGUYieU8PR7k677sBnLHg_TRpeRgi0naqIdY2goNXKoRqszlzdIHkZ_sbxgYhWWOBvLmL2YaJsw4HBZSwDzVWhryhVQBdX32Oz-YxPMFPs-jCT6uhGKrRRqh3FCzw", Name = "Sandy", Height = 500, Age = 45, Origin = "Kenya", Price = 100 };
            var giraffe3 = new Giraffe() { Id = Guid.NewGuid(), PicId = "https://giraffeconservation.org/wp-content/uploads/2019/03/gcf_stock-22.jpg", Name = "Peter", Height = 580, Age = 10, Origin = "Madagascar", Price = 50 };
            var giraffe4 = new Giraffe() { Id = Guid.NewGuid(), PicId = "https://www.telegraph.co.uk/content/dam/news/2016/04/22/gmain_trans_NvBQzQNjv4Bq7t4Eljyiy6iRMFuEKY2dXG-a32b547KZvtuFJzFNsb8.jpg", Name = "Taharqa", Height = 450, Age = 20, Origin = "Kenya", Price = 1000 };

            Giraffes.Add(giraffe1);
            Giraffes.Add(giraffe2);
            Giraffes.Add(giraffe3);
            Giraffes.Add(giraffe4);

            Booking booking1 = new Booking { Id = Guid.NewGuid(), Booker = "Maria", BookerEmail="Maria@gmail.com", GiraffeId = giraffe1.Id, GiraffeName = giraffe1.Name, From = DateTime.Now, To = DateTime.Now.AddHours(2), TotalCost = 50};

            Bookings.Add(booking1);
        }

      
    }
}
