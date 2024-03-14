using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftwareCompany.Domain.Entities;

namespace SoftwareCompany.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "d97bc39f-7fa2-4873-b565-f973d6c24faf",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "c62b3e59-4bc2-4b66-8bac-9bdebd999971",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "myEmail@email.com",
                NormalizedEmail = "MYEMAIL@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpass"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "d97bc39f-7fa2-4873-b565-f973d6c24faf",
                UserId = "c62b3e59-4bc2-4b66-8bac-9bdebd999971"
            });

            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("70b88b22-c284-40bd-a921-bb0abd7db6fe"),
                CodeWord = "PageIndex",
                Title = "Головна"
            });

            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("0186a571-a353-4468-a432-1a6b4c851426"),
                CodeWord = "PageServices",
                Title = "Сервіс"
            });

            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("36029281-b0a7-4cd7-97f6-e7cfe417346f"),
                CodeWord = "PageContacts",
                Title = "Контакти"
            });
        }
    }
}
