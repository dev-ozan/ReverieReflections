using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReverieReflections.Data;
using System.Reflection.Emit;

namespace ReverieReflections.Data
{
    public class ApplicationDbContext : IdentityDbContext<Kisi>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ReverieReflections.Data.Makale> Makale { get; set; } 


       


    }

}