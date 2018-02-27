using Library.Configuration;
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

        public DbSet<Author> Authors { get; set; }

        public DbSet<BookPublisher> BookPublisher { get; set; }

        public DbSet<BookAuthor> BookAuthor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConfigSettings.ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookPublisher>()
                .HasKey(pi => new
                {
                    pi.PublisherId,
                    pi.BookId
                });

            modelBuilder.Entity<BookAuthor>()
                .HasKey(pi => new
                {
                    pi.AuthorId,
                    pi.BookId
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
