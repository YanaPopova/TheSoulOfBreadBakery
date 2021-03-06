﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TheSoulOfBreadBakery.Models;

namespace TheSoulOfBreadBakery.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180102091702_AddShoppingCartItem")]
    partial class AddShoppingCartItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TheSoulOfBreadBakery.Models.Bread", b =>
                {
                    b.Property<int>("BreadId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AllergyInformation");

                    b.Property<int>("CategoryId");

                    b.Property<string>("ImageThumbnailUrl");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("InStock");

                    b.Property<bool>("IsBreadOfTheWeek");

                    b.Property<string>("LongDescription");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<string>("ShortDescription");

                    b.HasKey("BreadId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Breads");
                });

            modelBuilder.Entity("TheSoulOfBreadBakery.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.Property<string>("Description");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TheSoulOfBreadBakery.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int?>("BreadId");

                    b.Property<string>("ShoppingCartId");

                    b.HasKey("ShoppingCartItemId");

                    b.HasIndex("BreadId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("TheSoulOfBreadBakery.Models.Bread", b =>
                {
                    b.HasOne("TheSoulOfBreadBakery.Models.Category", "Category")
                        .WithMany("Breads")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TheSoulOfBreadBakery.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("TheSoulOfBreadBakery.Models.Bread", "Bread")
                        .WithMany()
                        .HasForeignKey("BreadId");
                });
#pragma warning restore 612, 618
        }
    }
}
