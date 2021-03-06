﻿// <auto-generated />
using System;
using CoinFac.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoinFac.Persistence.Migrations
{
    [DbContext(typeof(DatabaseService))]
    [Migration("20200107030151_InitialDbMigration")]
    partial class InitialDbMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoinFac.Domain.Accounts.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountType");

                    b.Property<string>("Comments")
                        .HasMaxLength(100);

                    b.Property<int>("Goal");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("UserForeignKey");

                    b.HasKey("Id");

                    b.HasIndex("UserForeignKey");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("CoinFac.Domain.Accounts.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountForeignKey");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Notes");

                    b.Property<int>("Value")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("AccountForeignKey");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("CoinFac.Domain.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("EmailVerified");

                    b.Property<string>("FamilyName");

                    b.Property<string>("GivenName");

                    b.Property<string>("Locale");

                    b.Property<string>("Name");

                    b.Property<string>("PictureUrl");

                    b.Property<string>("Sub");

                    b.Property<string>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CoinFac.Domain.Accounts.Account", b =>
                {
                    b.HasOne("CoinFac.Domain.Identity.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CoinFac.Domain.Accounts.Record", b =>
                {
                    b.HasOne("CoinFac.Domain.Accounts.Account", "Account")
                        .WithMany("Records")
                        .HasForeignKey("AccountForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
