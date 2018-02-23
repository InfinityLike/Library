using Library.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL
{
    public class LibraryDb : IdentityDbContext<User>
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Magazine> Magazines { get; set; }

        public DbSet<Brochure> Brochures { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<BookPublisher> BookPublisher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BookPublisher>()
            //    .HasOne(pi => pi.Publisher)
            //    .WithMany(p => p.Books)
            //    .HasForeignKey(pi => pi.PublisherId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<BookPublisher>()
            //    .HasOne(pi => pi.Book)
            //    .WithMany(i => i.Publishers)
            //    .HasForeignKey(pi => pi.BookId)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookPublisher>()
                .HasKey(pi => new
                {
                    pi.PublisherId,
                    pi.BookId
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
