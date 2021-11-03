using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GradesAPI.Data
{
    public class GradesDbContext  : DbContext
    {
        public GradesDbContext(DbContextOptions<GradesDbContext> options) : base(options)
        {

        }
        public DbSet<Grades> Grades { get; set; }

    }
}
