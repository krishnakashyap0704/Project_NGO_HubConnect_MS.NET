using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_NGO_HubConnect.Models;
using NGO_HubConnect.Models;
using Razorpay.Api;

namespace Project_NGO_HubConnect.Data
{
    public class MyDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Project_NGO_HubConnect.Models.Donor>? Donor { get; set; }
        public DbSet<Project_NGO_HubConnect.Models.Event>? Event { get; set; }
        public DbSet<Project_NGO_HubConnect.Models.Volunteer>? Volunteer { get; set; }
        public DbSet<Project_NGO_HubConnect.Models.Ngo>? Ngo { get; set; }
        public DbSet<NGO_HubConnect.Models.AspNetUser>? aspnetusers { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Project_NGO_HubConnect.DTOs.RoleStore>? RoleStore { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationship
            modelBuilder.Entity<Enrollment>()
                .HasKey(au => new { au.Email, au.EventId });

            modelBuilder.Entity<Enrollment>()
                .HasOne(au => au.User)
                .WithMany(u => u.UserEvents)
                .HasForeignKey(au => au.Email);

            modelBuilder.Entity<Enrollment>()
                .HasOne(au => au.Event)
                .WithMany(e => e.UserEvents)
                .HasForeignKey(au => au.EventId);
        }
    }
}
