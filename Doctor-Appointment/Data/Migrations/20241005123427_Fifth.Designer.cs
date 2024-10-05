﻿// <auto-generated />
using Doctor_Appointment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Doctor_Appointment.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241005123427_Fifth")]
    partial class Fifth
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Doctor_Appointment.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Date")
                        .IsRequired()
                        .HasColumnType("timestamp");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("PoliclinicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.HasIndex("PoliclinicId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Doctor_Appointment.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PoliclinicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PoliclinicId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Doctor_Appointment.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("Doctor_Appointment.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TcNO")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Doctor_Appointment.Models.Policlinic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Policlinics");
                });

            modelBuilder.Entity("PatientPoliclinic", b =>
                {
                    b.Property<int>("PatientsId")
                        .HasColumnType("int");

                    b.Property<int>("PoliclinicsId")
                        .HasColumnType("int");

                    b.HasKey("PatientsId", "PoliclinicsId");

                    b.HasIndex("PoliclinicsId");

                    b.ToTable("PatientPoliclinic");
                });

            modelBuilder.Entity("Doctor_Appointment.Models.Appointment", b =>
                {
                    b.HasOne("Doctor_Appointment.Models.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Doctor_Appointment.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Doctor_Appointment.Models.Policlinic", "Policlinic")
                        .WithMany("Appointments")
                        .HasForeignKey("PoliclinicId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("Policlinic");
                });

            modelBuilder.Entity("Doctor_Appointment.Models.Doctor", b =>
                {
                    b.HasOne("Doctor_Appointment.Models.Policlinic", "Policlinic")
                        .WithMany("Doctors")
                        .HasForeignKey("PoliclinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Policlinic");
                });

            modelBuilder.Entity("PatientPoliclinic", b =>
                {
                    b.HasOne("Doctor_Appointment.Models.Patient", null)
                        .WithMany()
                        .HasForeignKey("PatientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Doctor_Appointment.Models.Policlinic", null)
                        .WithMany()
                        .HasForeignKey("PoliclinicsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Doctor_Appointment.Models.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Doctor_Appointment.Models.Patient", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Doctor_Appointment.Models.Policlinic", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}
