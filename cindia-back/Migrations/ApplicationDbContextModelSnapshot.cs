﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using cindia_back.DbContext;

#nullable disable

namespace cindia_back.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("cindia_back.Models.Casier", b =>
                {
                    b.Property<int>("CasierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CasierId"));

                    b.Property<int>("CasierUserId")
                        .HasColumnType("integer");

                    b.Property<string>("DateAudiance")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DateDelie")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DateInculpation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Peine")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CasierId");

                    b.HasIndex("CasierUserId");

                    b.ToTable("Casiers");
                });

            modelBuilder.Entity("cindia_back.Models.Demande", b =>
                {
                    b.Property<int>("DemandeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DemandeId"));

                    b.Property<DateTime>("DateDemande")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TypeDemande")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("DemandeId");

                    b.HasIndex("UserId");

                    b.ToTable("Demande");
                });

            modelBuilder.Entity("cindia_back.Models.District", b =>
                {
                    b.Property<int>("DistrictId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DistrictId"));

                    b.Property<string>("DistrictName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DistrictId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("cindia_back.Models.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .HasColumnType("integer");

                    b.Property<int>("DistrictId")
                        .HasColumnType("integer");

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SectionId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("cindia_back.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Birthday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Birthplace")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FathersName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MothersName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NumCIN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PlaceOfIssue")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ScanCIN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SectionId")
                        .HasColumnType("integer");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserDistrictId")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.HasIndex("SectionId");

                    b.HasIndex("UserDistrictId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("cindia_back.Models.Casier", b =>
                {
                    b.HasOne("cindia_back.Models.User", "UserCasier")
                        .WithMany("UserCasier")
                        .HasForeignKey("CasierUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserCasier");
                });

            modelBuilder.Entity("cindia_back.Models.Demande", b =>
                {
                    b.HasOne("cindia_back.Models.User", "UserDemande")
                        .WithMany("DemandeUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserDemande");
                });

            modelBuilder.Entity("cindia_back.Models.Section", b =>
                {
                    b.HasOne("cindia_back.Models.District", "SectionDistrict")
                        .WithMany("DistrictSection")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SectionDistrict");
                });

            modelBuilder.Entity("cindia_back.Models.User", b =>
                {
                    b.HasOne("cindia_back.Models.Section", "Section")
                        .WithMany("Users")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cindia_back.Models.District", "UserDistrict")
                        .WithMany("DistrictUsers")
                        .HasForeignKey("UserDistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");

                    b.Navigation("UserDistrict");
                });

            modelBuilder.Entity("cindia_back.Models.District", b =>
                {
                    b.Navigation("DistrictSection");

                    b.Navigation("DistrictUsers");
                });

            modelBuilder.Entity("cindia_back.Models.Section", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("cindia_back.Models.User", b =>
                {
                    b.Navigation("DemandeUser");

                    b.Navigation("UserCasier");
                });
#pragma warning restore 612, 618
        }
    }
}
