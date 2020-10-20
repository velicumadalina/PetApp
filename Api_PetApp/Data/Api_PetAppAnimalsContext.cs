using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi_PetApp.Models;

namespace Api_PetApp.Data
{
    public class Api_PetAppAnimalsContext : DbContext
    {
        public Api_PetAppAnimalsContext (DbContextOptions<Api_PetAppAnimalsContext> options)
            : base(options)
        {
        }

        public DbSet<WebApi_PetApp.Models.Animal> Animal { get; set; }
    }
}
