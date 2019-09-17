﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoneyManager.DataAccess;

namespace MoneyManager.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20190905064306_Renaming")]
    partial class Renaming
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MoneyManager.DataAccess.Models.Asset", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Balance");

                    b.Property<string>("Name");

                    b.Property<int?>("UserId");

                    b.HasKey("AssetId");

                    b.HasIndex("UserId");

                    b.ToTable("Asset");
                });

            modelBuilder.Entity("MoneyManager.DataAccess.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsExpenses");

                    b.Property<string>("Name");

                    b.Property<int?>("ParentCategoryId");

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("MoneyManager.DataAccess.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int?>("AssetId");

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Comment");

                    b.Property<DateTime>("Date");

                    b.HasKey("TransactionId");

                    b.HasIndex("AssetId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("MoneyManager.DataAccess.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Balance");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MoneyManager.DataAccess.Models.Asset", b =>
                {
                    b.HasOne("MoneyManager.DataAccess.Models.User", "User")
                        .WithMany("Assets")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MoneyManager.DataAccess.Models.Category", b =>
                {
                    b.HasOne("MoneyManager.DataAccess.Models.Category", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("MoneyManager.DataAccess.Models.Transaction", b =>
                {
                    b.HasOne("MoneyManager.DataAccess.Models.Asset", "Asset")
                        .WithMany("Transactions")
                        .HasForeignKey("AssetId");

                    b.HasOne("MoneyManager.DataAccess.Models.Category", "Category")
                        .WithMany("TransactionList")
                        .HasForeignKey("CategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
