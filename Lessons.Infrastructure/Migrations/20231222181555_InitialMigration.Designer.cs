﻿// <auto-generated />
using System;
using Lessons.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lessons.Infrastructure.Migrations
{
    [DbContext(typeof(LessonsDbContext))]
    [Migration("20231222181555_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GroupTeacher", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("integer");

                    b.Property<int>("TeachersId")
                        .HasColumnType("integer");

                    b.HasKey("GroupsId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("GroupTeacher");
                });

            modelBuilder.Entity("Lessons.Domain.Model.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Course")
                        .HasColumnType("integer");

                    b.Property<int?>("LectureId")
                        .HasColumnType("integer");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Speciality")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Lessons.Domain.Model.Homework", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("File")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<int?>("Grade")
                        .HasColumnType("integer");

                    b.Property<int>("PracticalLessonId")
                        .HasColumnType("integer");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PracticalLessonId");

                    b.HasIndex("StudentId");

                    b.ToTable("Homeworks");
                });

            modelBuilder.Entity("Lessons.Domain.Model.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Classroom")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte[]>("Material")
                        .HasColumnType("bytea");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TeacherId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Lessons");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Lessons.Domain.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PatronymicName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Lessons.Domain.Model.Lecture", b =>
                {
                    b.HasBaseType("Lessons.Domain.Model.Lesson");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("Lessons.Domain.Model.PracticalLesson", b =>
                {
                    b.HasBaseType("Lessons.Domain.Model.Lesson");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasIndex("GroupId");

                    b.ToTable("PracticalLessons");
                });

            modelBuilder.Entity("Lessons.Domain.Model.Student", b =>
                {
                    b.HasBaseType("Lessons.Domain.Model.Person");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.HasIndex("GroupId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Lessons.Domain.Model.Supervisor", b =>
                {
                    b.HasBaseType("Lessons.Domain.Model.Person");

                    b.ToTable("Supervisors");
                });

            modelBuilder.Entity("Lessons.Domain.Model.Teacher", b =>
                {
                    b.HasBaseType("Lessons.Domain.Model.Person");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("GroupTeacher", b =>
                {
                    b.HasOne("Lessons.Domain.Model.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lessons.Domain.Model.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lessons.Domain.Model.Group", b =>
                {
                    b.HasOne("Lessons.Domain.Model.Lecture", null)
                        .WithMany("Groups")
                        .HasForeignKey("LectureId");
                });

            modelBuilder.Entity("Lessons.Domain.Model.Homework", b =>
                {
                    b.HasOne("Lessons.Domain.Model.PracticalLesson", "PracticalLesson")
                        .WithMany()
                        .HasForeignKey("PracticalLessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lessons.Domain.Model.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PracticalLesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Lessons.Domain.Model.Lesson", b =>
                {
                    b.HasOne("Lessons.Domain.Model.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Lessons.Domain.Model.Lecture", b =>
                {
                    b.HasOne("Lessons.Domain.Model.Lesson", null)
                        .WithOne()
                        .HasForeignKey("Lessons.Domain.Model.Lecture", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lessons.Domain.Model.PracticalLesson", b =>
                {
                    b.HasOne("Lessons.Domain.Model.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lessons.Domain.Model.Lesson", null)
                        .WithOne()
                        .HasForeignKey("Lessons.Domain.Model.PracticalLesson", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Lessons.Domain.Model.Student", b =>
                {
                    b.HasOne("Lessons.Domain.Model.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lessons.Domain.Model.Person", null)
                        .WithOne()
                        .HasForeignKey("Lessons.Domain.Model.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Lessons.Domain.Model.Supervisor", b =>
                {
                    b.HasOne("Lessons.Domain.Model.Person", null)
                        .WithOne()
                        .HasForeignKey("Lessons.Domain.Model.Supervisor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lessons.Domain.Model.Teacher", b =>
                {
                    b.HasOne("Lessons.Domain.Model.Person", null)
                        .WithOne()
                        .HasForeignKey("Lessons.Domain.Model.Teacher", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lessons.Domain.Model.Group", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Lessons.Domain.Model.Lecture", b =>
                {
                    b.Navigation("Groups");
                });
#pragma warning restore 612, 618
        }
    }
}