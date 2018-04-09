using Microsoft.AspNet.Identity.EntityFramework;
using Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Implementations
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Post> PostTable { get; set; }
        
        public DbSet<Friends> FriendsTable { get;set;}
        public DbSet<Message> MessageTable { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Post>().ToTable("PostTable");
            modelBuilder.Entity<ApplicationUser>().ToTable("UserTable");
            modelBuilder.Entity<Friends>().ToTable("FriendsTable");
            modelBuilder.Entity<Message>().ToTable("MessageTable");

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

    }
}
