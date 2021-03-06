﻿// <auto-generated />
using System;
using GetInShape.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GetInShape.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GetInShape.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<int>("Number");

                    b.Property<string>("Street");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("GetInShape.Models.FitnessClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Img");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FitnessClasses");
                });

            modelBuilder.Entity("GetInShape.Models.GymClub", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("GymClubs");
                });

            modelBuilder.Entity("GetInShape.Models.GymClubFitnessClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FitnessClassId");

                    b.Property<int>("GymClubId");

                    b.Property<DateTime>("TimeSchedule");

                    b.HasKey("Id");

                    b.HasIndex("FitnessClassId");

                    b.HasIndex("GymClubId");

                    b.ToTable("GymClubClasses");
                });

            modelBuilder.Entity("GetInShape.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("GetInShape.Models.InstructorFitnessClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FitnessClassId");

                    b.Property<int>("InstructorId");

                    b.HasKey("Id");

                    b.HasIndex("FitnessClassId");

                    b.HasIndex("InstructorId");

                    b.ToTable("InstructorClasses");
                });

            modelBuilder.Entity("GetInShape.Models.InstructorSpecialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("GrantDate");

                    b.Property<int>("InstructorId");

                    b.Property<int>("SpecializationId");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("InstructorSpecializations");
                });

            modelBuilder.Entity("GetInShape.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Bpm");

                    b.Property<int>("FitnessClassId");

                    b.Property<string>("Name");

                    b.Property<string>("Singer");

                    b.HasKey("Id");

                    b.HasIndex("FitnessClassId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("GetInShape.Models.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("GetInShape.Models.GymClub", b =>
                {
                    b.HasOne("GetInShape.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GetInShape.Models.GymClubFitnessClass", b =>
                {
                    b.HasOne("GetInShape.Models.FitnessClass", "FitnessClass")
                        .WithMany("GymClubClass")
                        .HasForeignKey("FitnessClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GetInShape.Models.GymClub", "GymClub")
                        .WithMany("GymClubFitnessClass")
                        .HasForeignKey("GymClubId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GetInShape.Models.InstructorFitnessClass", b =>
                {
                    b.HasOne("GetInShape.Models.FitnessClass", "FitnessClass")
                        .WithMany("InstructorClass")
                        .HasForeignKey("FitnessClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GetInShape.Models.Instructor", "Instructor")
                        .WithMany("InstructorClass")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GetInShape.Models.InstructorSpecialization", b =>
                {
                    b.HasOne("GetInShape.Models.Instructor", "Instructor")
                        .WithMany("InstructorSpecialization")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GetInShape.Models.Specialization", "Specialization")
                        .WithMany("InstructorSpecialization")
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GetInShape.Models.Song", b =>
                {
                    b.HasOne("GetInShape.Models.FitnessClass", "FitnessClass")
                        .WithMany("Song")
                        .HasForeignKey("FitnessClassId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
