﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Phoenix.DAL.Context;

#nullable disable

namespace Phoenox.DAL.Migrations
{
    [DbContext(typeof(PhoenixDB))]
    [Migration("20230903173612_Inital")]
    partial class Inital
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Phoenix.DAL.Entityes.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("Phoenix.DAL.Entityes.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text")
                        .HasColumnName("patronymic");

                    b.Property<long?>("Phone")
                        .HasColumnType("bigint")
                        .HasColumnName("phone");

                    b.Property<string>("Surname")
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.HasKey("Id")
                        .HasName("pk_clients");

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("Phoenix.DAL.Entityes.Massage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int?>("Duration")
                        .HasColumnType("integer")
                        .HasColumnName("duration");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_massages");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_massages_category_id");

                    b.ToTable("massages", (string)null);
                });

            modelBuilder.Entity("Phoenix.DAL.Entityes.Master", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text")
                        .HasColumnName("patronymic");

                    b.Property<string>("Surname")
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.HasKey("Id")
                        .HasName("pk_masters");

                    b.ToTable("masters", (string)null);
                });

            modelBuilder.Entity("Phoenix.DAL.Entityes.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer")
                        .HasColumnName("client_id");

                    b.Property<int>("MassageId")
                        .HasColumnType("integer")
                        .HasColumnName("massage_id");

                    b.Property<int>("MasterId")
                        .HasColumnType("integer")
                        .HasColumnName("master_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("pk_visits");

                    b.HasIndex("ClientId")
                        .HasDatabaseName("ix_visits_client_id");

                    b.HasIndex("MassageId")
                        .HasDatabaseName("ix_visits_massage_id");

                    b.HasIndex("MasterId")
                        .HasDatabaseName("ix_visits_master_id");

                    b.ToTable("visits", (string)null);
                });

            modelBuilder.Entity("Phoenix.DAL.Entityes.Massage", b =>
                {
                    b.HasOne("Phoenix.DAL.Entityes.Category", "Category")
                        .WithMany("Massage")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("fk_massages_categories_category_id");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Phoenix.DAL.Entityes.Visit", b =>
                {
                    b.HasOne("Phoenix.DAL.Entityes.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_visits_clients_client_id");

                    b.HasOne("Phoenix.DAL.Entityes.Massage", "Massage")
                        .WithMany()
                        .HasForeignKey("MassageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_visits_massages_massage_id");

                    b.HasOne("Phoenix.DAL.Entityes.Master", "Master")
                        .WithMany()
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_visits_masters_master_id");

                    b.Navigation("Client");

                    b.Navigation("Massage");

                    b.Navigation("Master");
                });

            modelBuilder.Entity("Phoenix.DAL.Entityes.Category", b =>
                {
                    b.Navigation("Massage");
                });
#pragma warning restore 612, 618
        }
    }
}
