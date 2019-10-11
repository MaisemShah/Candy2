using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Candy2.Data;

namespace Candy2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Candy2.Data.Candy> Candy { get; set; }
        public DbSet<Candy2.Data.CandyStore> CandyStore { get; set; }
    }
}
