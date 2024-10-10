﻿// <auto-generated />
using System;
using Appointments.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Appointments.Infrastructure.Migrations
{
    [DbContext(typeof(AppointmentContext))]
    [Migration("20241010150449_mig2")]
    partial class mig2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Appointments.Domain.Models.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AppointmentFinishTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("AppointmentTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClinicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsPayed")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ClinicId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Appointments", (string)null);
                });

            modelBuilder.Entity("Appointments.Domain.Models.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TcId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("Appointments.Domain.Models.Clinic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int>("Minute")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clinics", (string)null);
                });

            modelBuilder.Entity("Appointments.Domain.Models.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.ToTable("Payments", (string)null);
                });

            modelBuilder.Entity("Appointments.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TcId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TcId")
                        .IsUnique();

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("fd7d9a11-8915-4d50-b4de-a7bdd8635c82"),
                            CreateDate = new DateTime(2000, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "boyr4z.m@gmail.com",
                            Name = "Muhammet",
                            Password = "boyraz46",
                            PhoneNumber = "05366765246",
                            Role = 1,
                            Surname = "Boyraz",
                            TcId = "25117914842"
                        },
                        new
                        {
                            Id = new Guid("eb92f722-6898-4fdb-87d1-7ed84120b838"),
                            CreateDate = new DateTime(1998, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "serhatdnli@gmail.com",
                            Name = "Serhat",
                            Password = "serhat01",
                            PhoneNumber = "05353264771",
                            Role = 1,
                            Surname = "Denli",
                            TcId = "37458542624"
                        },
                        new
                        {
                            Id = new Guid("e0f5a473-9172-42fb-a030-85146bdf5da1"),
                            CreateDate = new DateTime(2000, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ahmetilhannm@gmail.com",
                            Name = "Ahmet",
                            Password = "ahmet65.",
                            PhoneNumber = "05432865247",
                            Role = 4,
                            Surname = "İlhan",
                            TcId = "18243593503"
                        },
                        new
                        {
                            Id = new Guid("0fcfbfda-cbea-4467-a07d-9ebdc706ef32"),
                            CreateDate = new DateTime(1998, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "merter61m@gmail.com",
                            Name = "Gürkan",
                            Password = "merter61",
                            PhoneNumber = "05428564525",
                            Role = 2,
                            Surname = "Merter",
                            TcId = "27485393001"
                        },
                        new
                        {
                            Id = new Guid("c06d79bd-0257-4cb2-abda-588ec82bea52"),
                            CreateDate = new DateTime(2000, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "dayanir34@gmail.com",
                            Name = "Talha",
                            Password = "dayanir34",
                            PhoneNumber = "05421452636",
                            Role = 5,
                            Surname = "Toğuşlu",
                            TcId = "28493040339"
                        },
                        new
                        {
                            Id = new Guid("2137a539-e264-4bfc-9387-b19fa3604c09"),
                            CreateDate = new DateTime(1999, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "iboaydin34@gmail.com",
                            Name = "İbrahim",
                            Password = "iboaydin34",
                            PhoneNumber = "05424586954",
                            Role = 2,
                            Surname = "Aydın",
                            TcId = "38492039432"
                        },
                        new
                        {
                            Id = new Guid("7b01c236-57ef-4cad-9c61-fed98b731fbc"),
                            CreateDate = new DateTime(1995, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "bakirr35@gmail.com",
                            Name = "Ali",
                            Password = "bakirr35",
                            PhoneNumber = "05489652542",
                            Role = 6,
                            Surname = "Bakır",
                            TcId = "78585458632"
                        },
                        new
                        {
                            Id = new Guid("01166186-329e-4151-aea9-5f1d8d4bf18f"),
                            CreateDate = new DateTime(1998, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "kayali06@gmail.com",
                            Name = "Ramazan",
                            Password = "kayali06",
                            PhoneNumber = "05471236549",
                            Role = 3,
                            Surname = "Kayalı",
                            TcId = "85458960214"
                        });
                });

            modelBuilder.Entity("Appointments.Domain.Models.Appointment", b =>
                {
                    b.HasOne("Appointments.Domain.Models.Client", "Client")
                        .WithMany("Appointments")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Appointments.Domain.Models.Clinic", "Clinic")
                        .WithMany("Appointments")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Appointments.Domain.Models.User", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Clinic");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Appointments.Domain.Models.Payment", b =>
                {
                    b.HasOne("Appointments.Domain.Models.Appointment", "Appointment")
                        .WithMany("Payments")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("Appointments.Domain.Models.Appointment", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Appointments.Domain.Models.Client", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Appointments.Domain.Models.Clinic", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Appointments.Domain.Models.User", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
