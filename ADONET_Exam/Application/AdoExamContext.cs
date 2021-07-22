using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_Exam.Application
{
    public partial class AdoExamContext : DbContext
    {
        public AdoExamContext()
        {
        }

        public AdoExamContext(DbContextOptions<AdoExamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<AlbumsSong> AlbumsSongs { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=XUMUK\\SQLEXPRESS;Initial Catalog=AdoExam;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("albums");

                entity.Property(e => e.AlbumId)
                    .ValueGeneratedNever()
                    .HasColumnName("album_id");

                entity.Property(e => e.AlbumTitle)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("album_title");

                entity.Property(e => e.AlbumTracks)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("album_tracks");

                entity.Property(e => e.AlbumYear)
                    .HasColumnType("date")
                    .HasColumnName("album_year");

                entity.Property(e => e.ArtistId).HasColumnName("artist_id");

                entity.HasOne(d => d.IdArtistNavigation)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("FK__album__artist_id__5165187F");
            });

            modelBuilder.Entity<AlbumsSong>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("albums_songs");

                entity.Property(e => e.AlbumId).HasColumnName("album_id");

                entity.Property(e => e.SongId).HasColumnName("song_id");

                entity.Property(e => e.TrackNumber).HasColumnName("track_number");

                entity.HasOne(d => d.IdAlbumNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("FK__albums_so__album__571DF1D5");

                entity.HasOne(d => d.IdSongNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.SongId)
                    .HasConstraintName("FK__albums_so__song___5812160E");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("artists");

                entity.Property(e => e.ArtistId)
                    .ValueGeneratedNever()
                    .HasColumnName("artist_id");

                entity.Property(e => e.ArtistSiteUrl)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("artist_site_url");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__artists__country__4E88ABD4");

                entity.HasOne(d => d.IdGenreNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__artists__genre_i__4D94879B");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("countries");

                entity.Property(e => e.CountryId)
                    .ValueGeneratedNever()
                    .HasColumnName("country_id");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("country_name");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genres");

                entity.Property(e => e.GenreId)
                    .ValueGeneratedNever()
                    .HasColumnName("genre_id");

                entity.Property(e => e.GenreName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("genre_name");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("groups");

                entity.Property(e => e.ArtistId).HasColumnName("artist_id");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("group_name");

                entity.HasOne(d => d.IdArtistNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("FK__groups__artist_i__59FA5E80");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("persons");

                entity.Property(e => e.ArtistId).HasColumnName("artist_id");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("lastname");

                entity.Property(e => e.Sex)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("sex");

                entity.HasOne(d => d.IdArtistNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("FK__persons__artist___5BE2A6F2");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("songs");

                entity.Property(e => e.SongId)
                    .ValueGeneratedNever()
                    .HasColumnName("song_id");

                entity.Property(e => e.SongDuration).HasColumnName("song_duration");

                entity.Property(e => e.SongTitle)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("song_title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
