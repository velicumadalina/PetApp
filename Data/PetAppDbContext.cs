using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetApp.Data
{
    public class PetAppDbContext : IdentityDbContext<User, PetAppRole, int>
    {
        public PetAppDbContext(DbContextOptions<PetAppDbContext> options) : base(options)
        {
        }
        public DbSet<AdoptionRequest> adoptionRequests { get; set; }
        public DbSet<FavoriteAnimal> Favorites { get; set; }
        public DbSet<User> appUsers { get; set; }
    }
}
