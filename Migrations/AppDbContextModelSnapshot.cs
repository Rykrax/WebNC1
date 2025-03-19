﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebNC1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bank", b =>
                {
                    b.Property<int>("BankID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BankID"));

                    b.Property<string>("BankImage")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("BankID");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("BankAccount", b =>
                {
                    b.Property<string>("AccountNumber")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("BankID")
                        .HasColumnType("int");

                    b.Property<string>("StatusAccount")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("AccountNumber", "BankID");

                    b.HasIndex("BankID");

                    b.HasIndex("UserID");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionID"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("RecipientUser")
                        .HasColumnType("int");

                    b.Property<string>("RepAccount")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("RepBank")
                        .HasColumnType("int");

                    b.Property<int>("SendBank")
                        .HasColumnType("int");

                    b.Property<string>("SenderAccount")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("SenderUser")
                        .HasColumnType("int");

                    b.Property<string>("StatusTransaction")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("TransactionID");

                    b.HasIndex("RepAccount", "RepBank");

                    b.HasIndex("SenderAccount", "SendBank");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<int>("Balance")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CCCD")
                        .HasMaxLength(12)
                        .HasColumnType("char(12)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("PinCode")
                        .HasMaxLength(6)
                        .HasColumnType("char(6)");

                    b.Property<string>("RoleUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("StatusUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BankAccount", b =>
                {
                    b.HasOne("Bank", "Bank")
                        .WithMany("BankAccounts")
                        .HasForeignKey("BankID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "User")
                        .WithMany("BankAccounts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Transaction", b =>
                {
                    b.HasOne("BankAccount", "RecipientBankAccount")
                        .WithMany("ReceivedTransactions")
                        .HasForeignKey("RepAccount", "RepBank")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankAccount", "SenderBankAccount")
                        .WithMany("SentTransactions")
                        .HasForeignKey("SenderAccount", "SendBank")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RecipientBankAccount");

                    b.Navigation("SenderBankAccount");
                });

            modelBuilder.Entity("Bank", b =>
                {
                    b.Navigation("BankAccounts");
                });

            modelBuilder.Entity("BankAccount", b =>
                {
                    b.Navigation("ReceivedTransactions");

                    b.Navigation("SentTransactions");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Navigation("BankAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
