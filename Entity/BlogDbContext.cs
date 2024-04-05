using Microsoft.EntityFrameworkCore;

namespace BlogApp.Entity
{
    public class BlogDbContext :DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { 
        }

        public DbSet<Blog> Blogs { get; set; } 
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().HasMany(e=>e.Blogs).WithOne(e=>e.Users).HasForeignKey(e=>e.UserId).IsRequired();

            modelBuilder.Entity<Blog>().HasKey(x => x.Id);
            modelBuilder.Entity<Blog>().HasOne(x=>x.Users).WithMany(x=>x.Blogs).HasForeignKey(x=>x.UserId).IsRequired();

        }
    }
}
