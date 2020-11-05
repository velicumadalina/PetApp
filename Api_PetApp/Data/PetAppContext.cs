using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi_PetApp.Models;

namespace Api_PetApp.Data
{
    public class PetAppContext : DbContext
    {
        public PetAppContext (DbContextOptions<PetAppContext> options)
            : base(options)
        {
        }



        public DbSet<WebApi_PetApp.Models.Animal> Animal { get; set; }
        public DbSet<WebApi_PetApp.Models.Shelter> Shelter { get; set; }

    }
}
