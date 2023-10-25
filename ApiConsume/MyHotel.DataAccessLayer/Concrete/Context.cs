using Microsoft.EntityFrameworkCore;
using MyHotel.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Subscribe> Subscribes { get; set; }

        public DbSet<Testimonial> Testimonials { get; set; }

    }
}
