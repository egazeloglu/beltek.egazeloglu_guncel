using Microsoft.EntityFrameworkCore;

namespace beltek.egazeloglu.Models
{
    public class OgrDbContext:DbContext
    {
        public OgrDbContext()
        {
        }
        public OgrDbContext(DbContextOptions<OgrDbContext> options) : base(options)
        {
        }

        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Sinif> Siniflar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=db_OgrenciSinif;Integrated Security=true;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");

            // Ögrenci tablosu ile Fluent API kullanarak bire çok ilişki kurma

            modelBuilder.Entity<Ogrenci>()
                .HasOne(i => i.Sinif)
                .WithMany(i => i.Ogrenciler)
                .HasForeignKey(i => i.SinifId);

            // sinifId alanını indexle
            modelBuilder.Entity<Ogrenci>().HasIndex(i => i.SinifId, "SinifId");
            modelBuilder.Entity<Ogrenci>().Property(p => p.OgrenciAd).HasMaxLength(20);
            modelBuilder.Entity<Ogrenci>().Property(p => p.OgrenciSoyad).HasMaxLength(30);
        }
    }
}
