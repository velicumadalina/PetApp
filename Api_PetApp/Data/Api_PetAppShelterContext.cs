using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi_PetApp.Models;

namespace Api_PetApp.Data
{
    public class Api_PetAppShelterContext : DbContext
    {
        public Api_PetAppShelterContext (DbContextOptions<Api_PetAppShelterContext> options)
            : base(options)
        {
        }

        public DbSet<WebApi_PetApp.Models.Shelter> Shelter { get; set; }
    }
}
