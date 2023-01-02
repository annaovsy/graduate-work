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
    [Migration("20221230101403_salaryReguriment")]
    partial class salaryReguriment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CitizenshipResume", b =>
                {
                    b.Property<int>("CitizenshipsId")
                        .HasColumnType("int");

                    b.Property<int>("ResumesId")
                        .HasColumnType("int");

                    b.HasKey("CitizenshipsId", "ResumesId");

                    b.HasIndex("ResumesId");

                    b.ToTable("CitizenshipResume");
                });

            modelBuilder.Entity("ForeignLanguageResume", b =>
                {
                    b.Property<int>("ForeignLanguagesId")
                        .HasColumnType("int");

                    b.Property<int>("ResumesId")
                        .HasColumnType("int");

                    b.HasKey("ForeignLanguagesId", "ResumesId");

                    b.HasIndex("ResumesId");

                    b.ToTable("ForeignLanguageResume");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.Citizenship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Citizenship");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EndYear")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResumeId")
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
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageLevelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("LanguageLevelId");

                    b.ToTable("ForeignLanguage");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LanguageLevel");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.PlaceOfWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Organization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
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
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyId")
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
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<string>("Site")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.Resume", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutMyself")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EducationLevelId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SalaryId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("SexId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkExperienceId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("EducationLevelId");

                    b.HasIndex("SalaryId")
                        .IsUnique();

                    b.HasIndex("SexId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.HasIndex("WorkExperienceId");

                    b.ToTable("Resume");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("TestWithoutAutentification.Models.Vacancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Conditions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Remote")
                        .HasColumnType("bit");

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SalaryId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("WorkExperienceId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("SalaryId")
                        .IsUnique();

                    b.HasIndex("WorkExperienceId");

                    b.ToTable("Vacancy");
                });

            modelBuilder.Entity("CitizenshipResume", b =>
                {
                    b.HasOne("TestWithoutAutentification.Models.AdditionalModels.Citizenship", null)
                        .WithMany()
                        .HasForeignKey("CitizenshipsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestWithoutAutentification.Models.Resume", null)
                        .WithMany()
                        .HasForeignKey("ResumesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ForeignLanguageResume", b =>
                {
                    b.HasOne("TestWithoutAutentification.Models.AdditionalModels.ForeignLanguage", null)
                        .WithMany()
                        .HasForeignKey("ForeignLanguagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestWithoutAutentification.Models.Resume", null)
                        .WithMany()
                        .HasForeignKey("ResumesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.EducationalInstitution", b =>
                {
                    b.HasOne("TestWithoutAutentification.Models.Resume", "Resume")
                        .WithMany("EducationalInstitutions")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.ForeignLanguage", b =>
                {
                    b.HasOne("TestWithoutAutentification.Models.AdditionalModels.Language", "Language")
                        .WithMany("ForeignLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestWithoutAutentification.Models.AdditionalModels.LanguageLevel", "LanguageLevel")
                        .WithMany("ForeignLanguages")
                        .HasForeignKey("LanguageLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("LanguageLevel");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.PlaceOfWork", b =>
                {
                    b.HasOne("TestWithoutAutentification.Models.Resume", "Resume")
                        .WithMany("PlacesOfWork")
                        .HasForeignKey("ResumeId");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.Salary", b =>
                {
                    b.HasOne("TestWithoutAutentification.Models.AdditionalModels.Currency", "Currency")
                        .WithMany("Salaries")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                        .WithMany("Resumes")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestWithoutAutentification.Models.AdditionalModels.EducationLevel", "EducationLevel")
                        .WithMany("Resumes")
                        .HasForeignKey("EducationLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestWithoutAutentification.Models.AdditionalModels.Salary", "Salary")
                        .WithOne("Resume")
                        .HasForeignKey("TestWithoutAutentification.Models.Resume", "SalaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestWithoutAutentification.Models.AdditionalModels.Sex", "Sex")
                        .WithMany("Resumes")
                        .HasForeignKey("SexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestWithoutAutentification.Models.User", "User")
                        .WithOne("Resume")
                        .HasForeignKey("TestWithoutAutentification.Models.Resume", "UserId");

                    b.HasOne("TestWithoutAutentification.Models.AdditionalModels.WorkExperience", "WorkExperience")
                        .WithMany("Resumes")
                        .HasForeignKey("WorkExperienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("EducationLevel");

                    b.Navigation("Salary");

                    b.Navigation("Sex");

                    b.Navigation("User");

                    b.Navigation("WorkExperience");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.User", b =>
                {
                    b.HasOne("TestWithoutAutentification.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.Vacancy", b =>
                {
                    b.HasOne("TestWithoutAutentification.Models.AdditionalModels.City", "City")
                        .WithMany("Vacancies")
                        .HasForeignKey("CityId");

                    b.HasOne("TestWithoutAutentification.Models.Company", "Company")
                        .WithMany("Vacancies")
                        .HasForeignKey("CompanyId");

                    b.HasOne("TestWithoutAutentification.Models.AdditionalModels.Salary", "Salary")
                        .WithOne("Vacancy")
                        .HasForeignKey("TestWithoutAutentification.Models.Vacancy", "SalaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestWithoutAutentification.Models.AdditionalModels.WorkExperience", "WorkExperience")
                        .WithMany("Vacancies")
                        .HasForeignKey("WorkExperienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Company");

                    b.Navigation("Salary");

                    b.Navigation("WorkExperience");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.City", b =>
                {
                    b.Navigation("Resumes");

                    b.Navigation("Vacancies");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.Currency", b =>
                {
                    b.Navigation("Salaries");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.EducationLevel", b =>
                {
                    b.Navigation("Resumes");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.Language", b =>
                {
                    b.Navigation("ForeignLanguages");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.LanguageLevel", b =>
                {
                    b.Navigation("ForeignLanguages");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.Salary", b =>
                {
                    b.Navigation("Resume");

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.Sex", b =>
                {
                    b.Navigation("Resumes");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.AdditionalModels.WorkExperience", b =>
                {
                    b.Navigation("Resumes");

                    b.Navigation("Vacancies");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.Company", b =>
                {
                    b.Navigation("Vacancies");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.Resume", b =>
                {
                    b.Navigation("EducationalInstitutions");

                    b.Navigation("PlacesOfWork");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.Role", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("TestWithoutAutentification.Models.User", b =>
                {
                    b.Navigation("Resume");
                });
#pragma warning restore 612, 618
        }
    }
}
