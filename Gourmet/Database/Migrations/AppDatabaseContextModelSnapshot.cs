﻿// <auto-generated />
using System;
using Gourmet.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gourmet.Database.Migrations
{
    [DbContext(typeof(AppDatabaseContext))]
    partial class AppDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.2");

            modelBuilder.Entity("Gourmet.Database.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("ProductImage")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<double>("ProductPrice")
                        .HasMaxLength(10000)
                        .HasColumnType("REAL");

                    b.Property<int>("ProductQuantity")
                        .HasMaxLength(10000)
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductId");

                    b.ToTable("ProductsDbSet");
                });

            modelBuilder.Entity("Gourmet.Database.Recipe", b =>
                {
                    b.Property<int>("RecipeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RecipeDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RecipeImage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("BLOB");

                    b.Property<string>("RecipeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("RecipeProductReferenceProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RecipeID");

                    b.HasIndex("RecipeProductReferenceProductId");

                    b.ToTable("RecipesDbSet");
                });

            modelBuilder.Entity("Gourmet.Database.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("UserImage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("BLOB");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Username");

                    b.ToTable("UsersDbSet");
                });

            modelBuilder.Entity("Gourmet.Database.Recipe", b =>
                {
                    b.HasOne("Gourmet.Database.Product", "RecipeProductReference")
                        .WithMany()
                        .HasForeignKey("RecipeProductReferenceProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RecipeProductReference");
                });
#pragma warning restore 612, 618
        }
    }
}
