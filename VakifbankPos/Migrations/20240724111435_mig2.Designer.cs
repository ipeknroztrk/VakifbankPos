﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VakifbankPos.DAL.Context;

#nullable disable

namespace VakifbankPos.Migrations
{
    [DbContext(typeof(VakifbankPosContext))]
    [Migration("20240724111435_mig2")]
    partial class mig2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VakifbankPos.DAL.Entities.PosAction", b =>
                {
                    b.Property<int>("PosActionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PosActionId"));

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("IssuedTo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("PosId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Returned")
                        .HasColumnType("boolean");

                    b.HasKey("PosActionId");

                    b.HasIndex("PosId");

                    b.ToTable("PosActions");
                });

            modelBuilder.Entity("VakifbankPos.DAL.Entities.PosInventory", b =>
                {
                    b.Property<int>("PosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PosId"));

                    b.Property<string>("Environment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("IssueDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastIssuedTo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OwnerBank")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PosMember")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PosType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Terminal")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Vendor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PosId");

                    b.ToTable("PosInventories");
                });

            modelBuilder.Entity("VakifbankPos.DAL.Entities.PosAction", b =>
                {
                    b.HasOne("VakifbankPos.DAL.Entities.PosInventory", "PosInventory")
                        .WithMany("PosActions")
                        .HasForeignKey("PosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PosInventory");
                });

            modelBuilder.Entity("VakifbankPos.DAL.Entities.PosInventory", b =>
                {
                    b.Navigation("PosActions");
                });
#pragma warning restore 612, 618
        }
    }
}
