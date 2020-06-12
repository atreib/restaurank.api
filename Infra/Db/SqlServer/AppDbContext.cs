using Microsoft.EntityFrameworkCore;
using restaurank.api.Domain.Models;

namespace restaurank.api.Infra.Db.SqlServer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<RestaurantModel> Restaurants { get; set; }

        public DbSet<VoteModel> Votes { get; set; }

        protected override void OnModelCreating (ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.Entity<UserModel>().ToTable("Users");
            builder.Entity<UserModel>().HasKey(p => p.Id);
            builder.Entity<UserModel>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserModel>().Property(p => p.Login).IsRequired().HasMaxLength(100);
            builder.Entity<UserModel>().Property(p => p.Password).IsRequired().HasMaxLength(255);
            builder.Entity<UserModel>().HasData(
                new UserModel { Id = 10, Login = "andre", Password = "$2b$12$F9IJedOAcH4QB/Jk3h3w9OTmo/UAIKf4dEJve1OcAd9TDZyG6zU4W" },
                new UserModel { Id = 20, Login = "teste", Password = "$2b$12$F9IJedOAcH4QB/Jk3h3w9OTmo/UAIKf4dEJve1OcAd9TDZyG6zU4W" },
                new UserModel { Id = 30, Login = "teste2", Password = "$2b$12$F9IJedOAcH4QB/Jk3h3w9OTmo/UAIKf4dEJve1OcAd9TDZyG6zU4W" }
            );

            builder.Entity<RestaurantModel>().ToTable("Restaurants");
            builder.Entity<RestaurantModel>().HasKey(p => p.Id);
            builder.Entity<RestaurantModel>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<RestaurantModel>().Property(p => p.Name).IsRequired().HasMaxLength(128);
            builder.Entity<RestaurantModel>().HasData(
                new RestaurantModel { Id = 10, Name = "Restaurante A" },
                new RestaurantModel { Id = 20, Name = "Restaurante B" },
                new RestaurantModel { Id = 30, Name = "Restaurante C" },
                new RestaurantModel { Id = 40, Name = "Restaurante D" },
                new RestaurantModel { Id = 50, Name = "Restaurante E" }
            );

            builder.Entity<VoteModel>().ToTable("Votes");
            builder.Entity<VoteModel>().HasKey(p => p.Id);
            builder.Entity<VoteModel>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<VoteModel>().Property(p => p.LunchDay).IsRequired();
            builder.Entity<VoteModel>().Property(p => p.UserId).IsRequired();
            builder.Entity<VoteModel>()
                .HasOne<UserModel>(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .IsRequired();
            builder.Entity<VoteModel>().Property(p => p.RestaurantId).IsRequired();
            builder.Entity<VoteModel>()
                .HasOne<RestaurantModel>(p => p.Restaurant)
                .WithMany()
                .HasForeignKey(p => p.RestaurantId)
                .IsRequired();
            builder.Entity<VoteModel>().HasData(
                new VoteModel { Id = 10, UserId = 10, RestaurantId = 10, LunchDay = System.DateTime.Now.AddDays(-4) },
                new VoteModel { Id = 20, UserId = 20, RestaurantId = 10, LunchDay = System.DateTime.Now.AddDays(-4) },
                new VoteModel { Id = 30, UserId = 10, RestaurantId = 20, LunchDay = System.DateTime.Now.AddDays(-5) },
                new VoteModel { Id = 40, UserId = 20, RestaurantId = 20, LunchDay = System.DateTime.Now.AddDays(-5) },
                new VoteModel { Id = 50, UserId = 10, RestaurantId = 10, LunchDay = System.DateTime.Now.AddDays(-2) },
                new VoteModel { Id = 60, UserId = 20, RestaurantId = 30, LunchDay = System.DateTime.Now.AddDays(-2) },
                new VoteModel { Id = 70, UserId = 10, RestaurantId = 40, LunchDay = System.DateTime.Now.AddDays(-1) },
                new VoteModel { Id = 80, UserId = 10, RestaurantId = 10, LunchDay = System.DateTime.Now },
                new VoteModel { Id = 90, UserId = 30, RestaurantId = 10, LunchDay = System.DateTime.Now },
                new VoteModel { Id = 91, UserId = 20, RestaurantId = 50, LunchDay = System.DateTime.Now }
            );
        }
    }
}