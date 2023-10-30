﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public interface IStudentDbContext
    {
        DbSet<Address> Adrese { get; set; }
        DbSet<Student> Studenti { get; set; }
    }
}
