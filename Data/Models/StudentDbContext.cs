using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    internal class StudentDbContext : DbContext
    {

        public DbSet<Student> Students { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public StudentDbContext()
        {
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Furdui Robert\ProiectFastTrack\Data\Students.mdf"";Integrated Security=True");

        }
    }
}
