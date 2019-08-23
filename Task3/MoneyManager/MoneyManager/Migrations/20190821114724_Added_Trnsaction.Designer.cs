﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoneyManager;
using MoneyManager.DataAccess;


namespace MoneyManager.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20190821114724_Added_Trnsaction")]
    partial class Added_Trnsaction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MoneyManagerClassLibrary.Asset", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Balance");

                    b.Property<string>("Name");

                    b.Property<int?>("UserForeignKey");

                    b.HasKey("AssetId");

                    b.HasIndex("UserForeignKey");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("MoneyManagerClassLibrary.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsExpenses");

                    b.Property<string>("Name");

                    b.Property<int?>("ParentCategoryCategoryId");

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentCategoryCategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("MoneyManagerClassLibrary.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int?>("AssetForeignKey");

                    b.Property<int?>("CategoryForeignKey");

                    b.Property<string>("Comment");

                    b.Property<DateTime>("Date");

                    b.HasKey("TransactionId");

                    b.HasIndex("AssetForeignKey");

                    b.HasIndex("CategoryForeignKey");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("MoneyManagerClassLibrary.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Balance");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MoneyManagerClassLibrary.Asset", b =>
                {
                    b.HasOne("MoneyManagerClassLibrary.User", "User")
                        .WithMany("Assets")
                        .HasForeignKey("UserForeignKey");
                });

            modelBuilder.Entity("MoneyManagerClassLibrary.Category", b =>
                {
                    b.HasOne("MoneyManagerClassLibrary.Category", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryCategoryId");
                });

            modelBuilder.Entity("MoneyManagerClassLibrary.Transaction", b =>
                {
                    b.HasOne("MoneyManagerClassLibrary.Asset", "Asset")
                        .WithMany("Transactions")
                        .HasForeignKey("AssetForeignKey");

                    b.HasOne("MoneyManagerClassLibrary.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryForeignKey");
                });
#pragma warning restore 612, 618
        }
    }
}
