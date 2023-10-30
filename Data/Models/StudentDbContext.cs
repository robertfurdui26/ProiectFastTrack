using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    internal class StudentDbContext : DbContext ,IStudentDbContext
    {

      

        public DbSet<Curs> Curses { get; set; }
        public DbSet<Address> Adrese { get; set; }
        public DbSet<Student> Studenti { get ; set  }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) :base(options)
        {
            Database.EnsureCreated();
        }


      
    }
}
