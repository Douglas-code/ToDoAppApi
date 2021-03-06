﻿using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TodoItem> Todos { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().ToTable("TB_TODO");
            modelBuilder.Entity<TodoItem>().HasKey(x => x.Id);

            modelBuilder.Entity<TodoItem>().Property(x => x.Id).HasColumnName("ID");
            modelBuilder.Entity<TodoItem>().Property(x => x.Title).HasMaxLength(160).HasColumnType("varchar(160)").HasColumnName("TITLE");
            modelBuilder.Entity<TodoItem>().Property(x => x.Done).HasColumnType("bit").HasColumnName("DONE");
            modelBuilder.Entity<TodoItem>().Property(x => x.Date).HasColumnName("DATE");

            modelBuilder.Entity<TodoItem>().HasOne(e => e.User).WithMany(e => e.Todos).HasForeignKey("USER_ID");

            modelBuilder.Entity<User>().ToTable("TB_USER");
            modelBuilder.Entity<User>().HasKey(x => x.Id);

            modelBuilder.Entity<User>().Property(x => x.Id).HasColumnName("ID");
            modelBuilder.Entity<User>().Property(x => x.Name).HasMaxLength(160).HasColumnType("varchar(120)").HasColumnName("NAME"); 
            modelBuilder.Entity<User>().Property(x => x.Email).HasMaxLength(120).HasColumnType("varchar(120)").HasColumnName("EMAIL");
            modelBuilder.Entity<User>().Property(x => x.Password).HasMaxLength(8).HasColumnType("varchar(8)").HasColumnName("PASSWORD");

            modelBuilder.Entity<User>().HasMany(p => p.Todos).WithOne(p => p.User);
        }
    }
}
