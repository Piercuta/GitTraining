using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFCcoreMySQL.Models
{
    public partial class disquaireContext : DbContext
    {
        public disquaireContext()
        {
        }

        public disquaireContext(DbContextOptions<disquaireContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<AlbumArtist> AlbumArtist { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=disquaire", x => x.ServerVersion("8.0.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("album");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedYear)
                    .HasColumnName("created_year")
                    .HasColumnType("year");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<AlbumArtist>(entity =>
            {
                entity.ToTable("album_artist");

                entity.HasIndex(e => e.IdArtist)
                    .HasName("fk_album_artist_artist");

                entity.HasIndex(e => new { e.IdAlbum, e.IdArtist })
                    .HasName("uni_id_album_id_artist")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAlbum).HasColumnName("id_album");

                entity.Property(e => e.IdArtist).HasColumnName("id_artist");

                entity.HasOne(d => d.IdAlbumNavigation)
                    .WithMany(p => p.AlbumArtist)
                    .HasForeignKey(d => d.IdAlbum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_album_artist_album");

                entity.HasOne(d => d.IdArtistNavigation)
                    .WithMany(p => p.AlbumArtist)
                    .HasForeignKey(d => d.IdArtist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_album_artist_artist");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("artist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("booking");

                entity.HasIndex(e => e.IdAlbum)
                    .HasName("uni_id_album")
                    .IsUnique();

                entity.HasIndex(e => e.IdContact)
                    .HasName("fk_reser_contact");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookedAt)
                    .HasColumnName("booked_at")
                    .HasColumnType("date");

                entity.Property(e => e.IdAlbum).HasColumnName("id_album");

                entity.Property(e => e.IdContact).HasColumnName("id_contact");

                entity.HasOne(d => d.IdAlbumNavigation)
                    .WithOne(p => p.Booking)
                    .HasForeignKey<Booking>(d => d.IdAlbum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_booking_album");

                entity.HasOne(d => d.IdContactNavigation)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.IdContact)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reser_contact");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contact");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FisrtName)
                    .IsRequired()
                    .HasColumnName("fisrt_name")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasColumnName("mail")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
