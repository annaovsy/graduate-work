﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestWithoutAutentification.Models;

namespace TestWithoutAutentification.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220922074247_AddResumeModelsMigr")]
    partial class AddResumeModelsMigr
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.Citizenship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResumeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("Citizenship");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.EducationLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EducationLevel");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.EducationalInstitution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EndYear")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResumeId")
                        .HasColumnType("int");

                    b.Property<string>("Specialization")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("EducationalInstitution");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.ForeignLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int?>("LanguageLevelId")
                        .HasColumnType("int");

                    b.Property<int?>("ResumeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("LanguageLevelId");

                    b.HasIndex("ResumeId");

                    b.ToTable("ForeignLanguage");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.LanguageLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LanguageLevel");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.NativeLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("NativeLanguage");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.PlaceOfWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Organization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResumeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("PlaceOfWork");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("CurrencyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Salary");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.Sex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sex");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.WorkExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkExperience");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstNameContactPerson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastNameContactPerson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.Resume", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AboutMyself")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EducationLevelId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NativeLanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SalaryId")
                        .HasColumnType("int");

                    b.Property<int?>("SexId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkExperienceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("EducationLevelId");

                    b.HasIndex("NativeLanguageId");

                    b.HasIndex("SalaryId");

                    b.HasIndex("SexId");

                    b.HasIndex("WorkExperienceId");

                    b.ToTable("Resume");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "user"
                        },
                        new
                        {
                            Id = 2,
                            Name = "company"
                        });
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.Citizenship", b =>
                {
                    b.HasOne("TestWithoutAutentification.Models.Resume", null)
                        .WithMany("Citizenship")
                        .HasForeignKey("ResumeId");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.EducationalInstitution", b =>
                {
                    b.HasOne("TestWithoutAutentification.Models.Resume", null)
                        .WithMany("EducationalInstitution")
                        .HasForeignKey("ResumeId");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.ForeignLanguage", b =>
                {
                    b.HasOne("TestWithoutAutentification.Models.AdditionalModels.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId");

                    b.HasOne("TestWithoutAutentification.Models.AdditionalModels.LanguageLevel", "LanguageLevel")
                        .WithMany()
                        .HasForeignKey("LanguageLevelId");

                    b.HasOne("TestWithoutAutentification.Models.Resume", null)
                        .WithMany("ForeignLanguage")
                        .HasForeignKey("ResumeId");

                    b.Navigation("Language");

                    b.Navigation("LanguageLevel");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.NativeLanguage", b =>
                {
                    b.HasOne("TestWithoutAutentification.Models.AdditionalModels.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.PlaceOfWork", b =>
                {
                    b.HasOne("TestWithoutAutentification.Models.Resume", null)
                        .WithMany("PlaceOfWork")
                        .HasForeignKey("ResumeId");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.Salary", b =>
                {
                    b.HasOne("TestWithoutAutentification.Models.AdditionalModels.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.Company", b =>
                {
                    b.HasOne("TestWithoutAutentification.Models.Role", "Role")
                        .WithMany("Companies")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.Resume", b =>
                {
                    b.HasOne("TestWithoutAutentification.Models.AdditionalModels.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("TestWithoutAutentification.Models.AdditionalModels.EducationLevel", "EducationLevel")
                        .WithMany()
                        .HasForeignKey("EducationLevelId");

                    b.HasOne("TestWithoutAutentification.Models.AdditionalModels.NativeLanguage", "NativeLanguage")
                        .WithMany()
                        .HasForeignKey("NativeLanguageId");

                    b.HasOne("TestWithoutAutentification.Models.AdditionalModels.Salary", "Salary")
                        .WithMany()
                        .HasForeignKey("SalaryId");

                    b.HasOne("TestWithoutAutentification.Models.AdditionalModels.Sex", "Sex")
                        .WithMany()
                        .HasForeignKey("SexId");

                    b.HasOne("TestWithoutAutentification.Models.AdditionalModels.WorkExperience", "WorkExperience")
                        .WithMany()
                        .HasForeignKey("WorkExperienceId");

                    b.Navigation("City");

                    b.Navigation("EducationLevel");

                    b.Navigation("NativeLanguage");

                    b.Navigation("Salary");

                    b.Navigation("Sex");

                    b.Navigation("WorkExperience");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.User", b =>
                {
                    b.HasOne("TestWithoutAutentification.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.Resume", b =>
                {
                    b.Navigation("Citizenship");

                    b.Navigation("EducationalInstitution");

                    b.Navigation("ForeignLanguage");

                    b.Navigation("PlaceOfWork");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.Role", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}