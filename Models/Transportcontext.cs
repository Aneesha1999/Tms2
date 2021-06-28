using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tms2.Models
{
    public class Transportcontext:DbContext
    {
       
        
            public Transportcontext(DbContextOptions options) : base(options)
            {

            }
            public DbSet<userregistration> userregs { get; set; }
            public DbSet<employeeinfo> empinfos { get; set; }
            public DbSet<vehicleinformation> vehicleinfos { get; set; }
            public DbSet<routeinformation> routeinfos { get; set; }
            public DbSet<allocatevehicle> allocatevehicles { get; set; }
            public DbSet<modify> modifies { get; set; }
            public DbSet<Admininfo> admininfos { get; set; }
            public DbSet<Tms2.Models.login> login { get; set; }

        }
    }
