﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Todo.Domain.Infra.Contexts;

namespace Todo.Domain.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210219000535_ThirdMigration")]
    partial class ThirdMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Todo.Domain.Entities.TodoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATE");

                    b.Property<bool>("Done")
                        .HasColumnType("bit")
                        .HasColumnName("DONE");

                    b.Property<string>("Title")
                        .HasMaxLength(160)
                        .HasColumnType("varchar(160)")
                        .HasColumnName("TITLE");

                    b.Property<Guid?>("USER_ID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("USER_ID");

                    b.ToTable("TB_TODO");
                });

            modelBuilder.Entity("Todo.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Email")
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Name")
                        .HasMaxLength(160)
                        .HasColumnType("varchar(160)")
                        .HasColumnName("NAME");

                    b.Property<string>("Password")
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("PASSWORD");

                    b.HasKey("Id");

                    b.ToTable("TB_USER");
                });

            modelBuilder.Entity("Todo.Domain.Entities.TodoItem", b =>
                {
                    b.HasOne("Todo.Domain.Entities.User", "User")
                        .WithMany("Todos")
                        .HasForeignKey("USER_ID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Todo.Domain.Entities.User", b =>
                {
                    b.Navigation("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}
