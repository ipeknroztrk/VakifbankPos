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
    [Migration("20240806063831_migımage")]
    partial class migımage
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

                    b.Property<int>("PosReceiverId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Returned")
                        .HasColumnType("boolean");

                    b.HasKey("PosActionId");

                    b.HasIndex("PosId");

                    b.HasIndex("PosReceiverId");

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

                    b.Property<bool>("IsDefective")
                        .HasColumnType("boolean");

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

                    b.Property<bool?>("Status")
                        .HasColumnType("boolean");

                    b.Property<string>("Terminal")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Vendor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PosId");

                    b.ToTable("PosInventories");
                });

            modelBuilder.Entity("VakifbankPos.DAL.Entities.PosReceiver", b =>
                {
                    b.Property<int>("PosReceiverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PosReceiverId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("PosReceiverId");

                    b.ToTable("PosReceivers");
                });

            modelBuilder.Entity("VakifbankPos.DAL.Entities.PosAction", b =>
                {
                    b.HasOne("VakifbankPos.DAL.Entities.PosInventory", "PosInventory")
                        .WithMany("PosActions")
                        .HasForeignKey("PosId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("VakifbankPos.DAL.Entities.PosReceiver", "PosReceiver")
                        .WithMany("PosActions")
                        .HasForeignKey("PosReceiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PosInventory");

                    b.Navigation("PosReceiver");
                });

            modelBuilder.Entity("VakifbankPos.DAL.Entities.PosInventory", b =>
                {
                    b.Navigation("PosActions");
                });

            modelBuilder.Entity("VakifbankPos.DAL.Entities.PosReceiver", b =>
                {
                    b.Navigation("PosActions");
                });
#pragma warning restore 612, 618
        }
    }
}
