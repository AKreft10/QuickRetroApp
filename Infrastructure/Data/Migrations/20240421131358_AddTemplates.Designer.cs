﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240421131358_AddTemplates")]
    partial class AddTemplates
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.RetroBoard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("RetroBoards");
                });

            modelBuilder.Entity("Domain.Entities.RetroBoardColumn", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BoardIdId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BoardIdId");

                    b.ToTable("RetroBoardColumns");
                });

            modelBuilder.Entity("Domain.Entities.RetroBoardColumnItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ColumnIdId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ColumnIdId");

                    b.ToTable("RetroBoardColumnItems");
                });

            modelBuilder.Entity("Domain.Entities.RetroBoardTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BackgroundUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RetroBoardTemplates");
                });

            modelBuilder.Entity("Domain.Entities.RetroBoardTemplateColumn", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TemplateIdId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TemplateIdId");

                    b.ToTable("RetroBoardTemplateColumns");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PasswordResetTokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("VerificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.RetroBoard", b =>
                {
                    b.HasOne("Domain.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("Domain.Entities.RetroBoardColumn", b =>
                {
                    b.HasOne("Domain.Entities.RetroBoard", "BoardId")
                        .WithMany("Columns")
                        .HasForeignKey("BoardIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoardId");
                });

            modelBuilder.Entity("Domain.Entities.RetroBoardColumnItem", b =>
                {
                    b.HasOne("Domain.Entities.RetroBoardColumn", "ColumnId")
                        .WithMany("Items")
                        .HasForeignKey("ColumnIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ColumnId");
                });

            modelBuilder.Entity("Domain.Entities.RetroBoardTemplateColumn", b =>
                {
                    b.HasOne("Domain.Entities.RetroBoardTemplate", "TemplateId")
                        .WithMany("Columns")
                        .HasForeignKey("TemplateIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TemplateId");
                });

            modelBuilder.Entity("Domain.Entities.RetroBoard", b =>
                {
                    b.Navigation("Columns");
                });

            modelBuilder.Entity("Domain.Entities.RetroBoardColumn", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Domain.Entities.RetroBoardTemplate", b =>
                {
                    b.Navigation("Columns");
                });
#pragma warning restore 612, 618
        }
    }
}
