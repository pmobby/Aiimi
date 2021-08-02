using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Entities;

namespace Web.Infrastructure.EntityFrameworkCore
{
    public class AiimiContext : DbContext
    {
        public AiimiContext(DbContextOptions<AiimiContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
    }
}
