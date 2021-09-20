using Microsoft.EntityFrameworkCore;
using ReadersAndBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadersAndBooks.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<BookGenre> BooksGenres { get; set; }
        public virtual DbSet<LibraryCard> LibraryCards { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>(a =>
            {
                a.HasMany(a => a.Books)
                .WithOne()
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");
                entity.HasOne(d => d.Author)
                     .WithMany(p => p.Books)
                     .HasForeignKey(d => d.AuthorId);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("genre_name");
            });

            modelBuilder.Entity<LibraryCard>(entity =>
            {
               
                entity.ToTable("library_card");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.Book)
                    .WithMany()
                    .HasForeignKey(d => d.BookId);


                entity.HasOne(d => d.Person)
                    .WithMany()
                    .HasForeignKey(d => d.PersonId);
                   
            });
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("middle_name");
            });

            
        }

    }
    }

