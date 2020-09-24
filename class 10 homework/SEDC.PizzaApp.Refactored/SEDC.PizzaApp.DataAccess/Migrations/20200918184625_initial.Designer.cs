﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEDC.PizzaApp.DataAccess;

namespace SEDC.PizzaApp.DataAccess.Migrations
{
    [DbContext(typeof(PizzaAppDbContext))]
    [Migration("20200918184625_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Delivered");

                    b.Property<int>("PaymentMethod");

                    b.Property<string>("PizzaStore");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new { Id = 1, Delivered = true, PaymentMethod = 2, PizzaStore = "Store1", UserId = 1 },
                        new { Id = 2, Delivered = false, PaymentMethod = 1, PizzaStore = "Store2", UserId = 2 }
                    );
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsOnPromotion");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new { Id = 1, IsOnPromotion = true, Name = "Kaprichioza" },
                        new { Id = 2, IsOnPromotion = false, Name = "Pepperoni" },
                        new { Id = 3, IsOnPromotion = false, Name = "Margarita" }
                    );
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.PizzaOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId");

                    b.Property<int>("PizzaId");

                    b.Property<int>("PizzaSize");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("PizzaOrder");

                    b.HasData(
                        new { Id = 1, OrderId = 1, PizzaId = 1, PizzaSize = 1, Price = 300.0 },
                        new { Id = 2, OrderId = 1, PizzaId = 2, PizzaSize = 1, Price = 350.0 },
                        new { Id = 3, OrderId = 2, PizzaId = 3, PizzaSize = 2, Price = 400.0 }
                    );
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1, Address = "Address1", FirstName = "Tanja", LastName = "Stojanovska" },
                        new { Id = 2, Address = "Address2", FirstName = "Kristina", LastName = "Spasevska" }
                    );
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.Order", b =>
                {
                    b.HasOne("SEDC.PizzaApp.Domain.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.PizzaOrder", b =>
                {
                    b.HasOne("SEDC.PizzaApp.Domain.Models.Order", "Order")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SEDC.PizzaApp.Domain.Models.Pizza", "Pizza")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
