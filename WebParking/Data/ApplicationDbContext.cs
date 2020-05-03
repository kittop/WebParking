using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebParking.Domain;

namespace WebParking.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Client> Clients { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
