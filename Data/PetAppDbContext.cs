using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetApp.Data
{
    public class PetAppDbContext : IdentityDbContext<PetAppUser, PetAppRole, int>
    {
        public PetAppDbContext(DbContextOptions<PetAppDbContext> options) : base(options)
        {
        }
    }
}
