﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_1.Models;

#nullable disable

namespace Project_1.Migrations
{
    [DbContext(typeof(ProjectDemoContext))]
    [Migration("20230428132423_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrderStatus", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "StatusId");

                    b.HasIndex("StatusId");

                    b.ToTable("OrderStatus", (string)null);
                });

            modelBuilder.Entity("Project_1.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Category_1");

                    b.HasIndex("ServiceId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Project_1.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ServiceId");

                    b.HasIndex(new[] { "UserId" }, "IX_image")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("image", (string)null);
                });

            modelBuilder.Entity("Project_1.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Project_1.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("Project_1.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Service", (string)null);
                });

            modelBuilder.Entity("Project_1.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Status", (string)null);
                });

            modelBuilder.Entity("Project_1.Models.Suggestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("StartTime")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Suggestion", (string)null);
                });

            modelBuilder.Entity("Project_1.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("UserCategory", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("categoryId");

                    b.HasKey("UserId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("UserCategory", (string)null);
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId")
                        .HasName("PK_UserRole_1");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole", (string)null);
                });

            modelBuilder.Entity("OrderStatus", b =>
                {
                    b.HasOne("Project_1.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK_OrderStatus_Order");

                    b.HasOne("Project_1.Models.Status", null)
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .IsRequired()
                        .HasConstraintName("FK_OrderStatus_Status");
                });

            modelBuilder.Entity("Project_1.Models.Category", b =>
                {
                    b.HasOne("Project_1.Models.Service", "Service")
                        .WithMany("Categories")
                        .HasForeignKey("ServiceId")
                        .IsRequired()
                        .HasConstraintName("FK_Category_Service");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Project_1.Models.Image", b =>
                {
                    b.HasOne("Project_1.Models.Category", "Category")
                        .WithMany("Images")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_image_Category");

                    b.HasOne("Project_1.Models.Order", "Order")
                        .WithMany("Images")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_image_Order");

                    b.HasOne("Project_1.Models.Service", "Service")
                        .WithMany("Images")
                        .HasForeignKey("ServiceId")
                        .HasConstraintName("FK_image_Service");

                    b.HasOne("Project_1.Models.User", "User")
                        .WithOne("Image")
                        .HasForeignKey("Project_1.Models.Image", "UserId")
                        .HasConstraintName("FK_image_User");

                    b.Navigation("Category");

                    b.Navigation("Order");

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project_1.Models.Order", b =>
                {
                    b.HasOne("Project_1.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Order_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project_1.Models.Suggestion", b =>
                {
                    b.HasOne("Project_1.Models.User", "User")
                        .WithMany("Suggestions")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Suggestion_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserCategory", b =>
                {
                    b.HasOne("Project_1.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_UserCategory_Category1");

                    b.HasOne("Project_1.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserCategory_User");
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.HasOne("Project_1.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_UserRole_Role");

                    b.HasOne("Project_1.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserRole_User");
                });

            modelBuilder.Entity("Project_1.Models.Category", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("Project_1.Models.Order", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("Project_1.Models.Service", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("Project_1.Models.User", b =>
                {
                    b.Navigation("Image");

                    b.Navigation("Orders");

                    b.Navigation("Suggestions");
                });
#pragma warning restore 612, 618
        }
    }
}