using Holiday.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holiday.DataBaseContext
{
    public class HolidayContext: IdentityDbContext<IdentityUser>
    {
        public HolidayContext(DbContextOptions<HolidayContext> options)
            :base(options)
        { }
        public DbSet <Vacantion> Vacantions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<VacantionRequest> VacantionRequests { get; set; }
    }
}
