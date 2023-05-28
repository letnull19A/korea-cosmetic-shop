﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication1.DataBase;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(PostgresContext))]
    partial class PostgresContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.DTOs.BasketDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("Count")
                        .HasColumnType("integer")
                        .HasColumnName("count");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("basket");
                });

            modelBuilder.Entity("WebApplication1.Models.DTOs.CategoryDto", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("CategoryId");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("WebApplication1.Models.DTOs.FavoriteDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("ProductDtosId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<Guid?>("UserDtosId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("ProductDtosId");

                    b.HasIndex("UserDtosId");

                    b.ToTable("favorites");
                });

            modelBuilder.Entity("WebApplication1.Models.DTOs.ImageDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("file_name");

                    b.HasKey("Id");

                    b.ToTable("images");
                });

            modelBuilder.Entity("WebApplication1.Models.DTOs.PaymentMeanDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("card_number");

                    b.Property<string>("System")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("system");

                    b.Property<Guid?>("UserDtoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.HasKey("Id");

                    b.HasIndex("UserDtoId");

                    b.ToTable("payment_means");
                });

            modelBuilder.Entity("WebApplication1.Models.DTOs.ProductAndImageDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("ImageDtoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uuid")
                        .HasColumnName("image_id");

                    b.Property<Guid?>("ProductDtoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.HasKey("Id");

                    b.HasIndex("ImageDtoId");

                    b.HasIndex("ProductDtoId");

                    b.ToTable("products_and_images");
                });

            modelBuilder.Entity("WebApplication1.Models.DTOs.ProductDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<string>("Composition")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("composition");

                    b.Property<int>("Count")
                        .HasColumnType("integer")
                        .HasColumnName("count");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<string>("WrapperImage")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("wrapper_image");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("WebApplication1.Models.DTOs.ReviewDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("message");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("WebApplication1.Models.DTOs.RoleDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("BackendName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("backend_name");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("WebApplication1.Models.DTOs.UserDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FatherName")
                        .HasColumnType("text")
                        .HasColumnName("fatherName");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("login");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("role_id");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("WebApplication1.Models.DTOs.FavoriteDto", b =>
                {
                    b.HasOne("WebApplication1.Models.DTOs.ProductDto", "ProductDtos")
                        .WithMany("FavoriteDtos")
                        .HasForeignKey("ProductDtosId");

                    b.HasOne("WebApplication1.Models.DTOs.UserDto", "UserDtos")
                        .WithMany("FavoriteDtos")
                        .HasForeignKey("UserDtosId");

                    b.Navigation("ProductDtos");

                    b.Navigation("UserDtos");
                });

            modelBuilder.Entity("WebApplication1.Models.DTOs.PaymentMeanDto", b =>
                {
                    b.HasOne("WebApplication1.Models.DTOs.UserDto", "UserDto")
                        .WithMany("PaymentMeanDtos")
                        .HasForeignKey("UserDtoId");

                    b.Navigation("UserDto");
                });

            modelBuilder.Entity("WebApplication1.Models.DTOs.ProductAndImageDto", b =>
                {
                    b.HasOne("WebApplication1.Models.DTOs.ImageDto", "ImageDto")
                        .WithMany("ProductAndImageDtos")
                        .HasForeignKey("ImageDtoId");

                    b.HasOne("WebApplication1.Models.DTOs.ProductDto", "ProductDto")
                        .WithMany("ProductAndImageDtos")
                        .HasForeignKey("ProductDtoId");

                    b.Navigation("ImageDto");

                    b.Navigation("ProductDto");
                });

            modelBuilder.Entity("WebApplication1.Models.DTOs.ProductDto", b =>
                {
                    b.HasOne("WebApplication1.Models.DTOs.CategoryDto", "Category")
                        .WithMany("ProductDtos")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebApplication1.Models.DTOs.UserDto", b =>
                {
                    b.HasOne("WebApplication1.Models.DTOs.RoleDto", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WebApplication1.Models.DTOs.CategoryDto", b =>
                {
                    b.Navigation("ProductDtos");
                });

            modelBuilder.Entity("WebApplication1.Models.DTOs.ImageDto", b =>
                {
                    b.Navigation("ProductAndImageDtos");
                });

            modelBuilder.Entity("WebApplication1.Models.DTOs.ProductDto", b =>
                {
                    b.Navigation("FavoriteDtos");

                    b.Navigation("ProductAndImageDtos");
                });

            modelBuilder.Entity("WebApplication1.Models.DTOs.RoleDto", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("WebApplication1.Models.DTOs.UserDto", b =>
                {
                    b.Navigation("FavoriteDtos");

                    b.Navigation("PaymentMeanDtos");
                });
#pragma warning restore 612, 618
        }
    }
}