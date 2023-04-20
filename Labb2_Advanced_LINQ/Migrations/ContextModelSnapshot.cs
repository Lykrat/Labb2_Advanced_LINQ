﻿// <auto-generated />
using System;
using Labb2_Advanced_LINQ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb2_Advanced_LINQ.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CourseSubject", b =>
                {
                    b.Property<int>("CoursesCourseID")
                        .HasColumnType("int");

                    b.Property<int>("SubjectsSubjectID")
                        .HasColumnType("int");

                    b.HasKey("CoursesCourseID", "SubjectsSubjectID");

                    b.HasIndex("SubjectsSubjectID");

                    b.ToTable("CourseSubject");
                });

            modelBuilder.Entity("Labb2_Advanced_LINQ.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseID"), 1L, 1);

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Labb2_Advanced_LINQ.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"), 1L, 1);

                    b.Property<int?>("CourseID")
                        .HasColumnType("int");

                    b.Property<string>("StudentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeacherID")
                        .HasColumnType("int");

                    b.HasKey("StudentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("TeacherID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Labb2_Advanced_LINQ.Models.Subject", b =>
                {
                    b.Property<int>("SubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectID"), 1L, 1);

                    b.Property<string>("SubjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectID");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Labb2_Advanced_LINQ.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherID"), 1L, 1);

                    b.Property<string>("TeacherName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherID");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.Property<int>("SubjectsSubjectID")
                        .HasColumnType("int");

                    b.Property<int>("TeachersTeacherID")
                        .HasColumnType("int");

                    b.HasKey("SubjectsSubjectID", "TeachersTeacherID");

                    b.HasIndex("TeachersTeacherID");

                    b.ToTable("SubjectTeacher");
                });

            modelBuilder.Entity("CourseSubject", b =>
                {
                    b.HasOne("Labb2_Advanced_LINQ.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesCourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb2_Advanced_LINQ.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsSubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Labb2_Advanced_LINQ.Models.Student", b =>
                {
                    b.HasOne("Labb2_Advanced_LINQ.Models.Course", "Course")
                        .WithMany("Students")
                        .HasForeignKey("CourseID");

                    b.HasOne("Labb2_Advanced_LINQ.Models.Teacher", "Teacher")
                        .WithMany("Students")
                        .HasForeignKey("TeacherID");

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.HasOne("Labb2_Advanced_LINQ.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsSubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb2_Advanced_LINQ.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersTeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Labb2_Advanced_LINQ.Models.Course", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Labb2_Advanced_LINQ.Models.Teacher", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}