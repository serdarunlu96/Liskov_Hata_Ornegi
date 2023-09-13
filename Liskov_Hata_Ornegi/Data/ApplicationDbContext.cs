using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Liskov_Hata_Ornegi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);  // bunu silmek ya da yoruma almak LSP'ye aykırı durum

            builder.Entity<Urun>()
                .Property(u => u.Ad)
                .IsRequired()
                .HasMaxLength(200); // Fluent API mapping

            builder.Entity<Urun>()
                .Property(u => u.Fiyat)
                .IsRequired()
                .HasPrecision(18, 2);
        }
    }
}