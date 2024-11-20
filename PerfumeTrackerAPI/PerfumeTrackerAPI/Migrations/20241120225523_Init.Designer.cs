﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PerfumeTrackerAPI.Models;

#nullable disable

namespace PerfumeTrackerAPI.Migrations
{
    [DbContext(typeof(PerfumetrackerContext))]
    [Migration("20241120225523_fulltext")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pgagent", "pgagent");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PerfumeTrackerAPI.Models.Perfume", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Autumn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("autumn");

                    b.Property<string>("House")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("house");

                    b.Property<string>("ImageObjectKey")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("imageObjectKey")
                        .HasDefaultValueSql("''::text");

                    b.Property<int>("Ml")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(2)
                        .HasColumnName("ml");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("notes")
                        .HasDefaultValueSql("''::text");

                    b.Property<string>("Perfume1")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("perfume");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision")
                        .HasColumnName("rating");

                    b.Property<bool>("Spring")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("spring");

                    b.Property<bool>("Summer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("summer");

                    b.Property<bool>("Winter")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("winter");

                    b.HasKey("Id")
                        .HasName("Perfume_pkey");

                    b.ToTable("Perfume", (string)null);
                });

            modelBuilder.Entity("PerfumeTrackerAPI.Models.PerfumeSuggested", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PerfumeId")
                        .HasColumnType("integer")
                        .HasColumnName("perfumeId");

                    b.Property<DateTime>("SuggestedOn")
                        .HasColumnType("timestamp(3) without time zone")
                        .HasColumnName("suggestedOn");

                    b.HasKey("Id")
                        .HasName("PerfumeSuggested_pkey");

                    b.HasIndex("PerfumeId");

                    b.ToTable("PerfumeSuggested", (string)null);
                });

            modelBuilder.Entity("PerfumeTrackerAPI.Models.PerfumeTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PerfumeId")
                        .HasColumnType("integer")
                        .HasColumnName("perfumeId");

                    b.Property<int>("TagId")
                        .HasColumnType("integer")
                        .HasColumnName("tagId");

                    b.HasKey("Id")
                        .HasName("PerfumeTag_pkey");

                    b.HasIndex("PerfumeId");

                    b.HasIndex("TagId");

                    b.ToTable("PerfumeTag", (string)null);
                });

            modelBuilder.Entity("PerfumeTrackerAPI.Models.PerfumeWorn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PerfumeId")
                        .HasColumnType("integer")
                        .HasColumnName("perfumeId");

                    b.Property<DateTime>("WornOn")
                        .HasColumnType("timestamp(3) without time zone")
                        .HasColumnName("wornOn");

                    b.HasKey("Id")
                        .HasName("PerfumeWorn_pkey");

                    b.HasIndex("PerfumeId");

                    b.ToTable("PerfumeWorn", (string)null);
                });

            modelBuilder.Entity("PerfumeTrackerAPI.Models.PrismaMigration", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)")
                        .HasColumnName("id");

                    b.Property<int>("AppliedStepsCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("applied_steps_count");

                    b.Property<string>("Checksum")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("checksum");

                    b.Property<DateTime?>("FinishedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("finished_at");

                    b.Property<string>("Logs")
                        .HasColumnType("text")
                        .HasColumnName("logs");

                    b.Property<string>("MigrationName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("migration_name");

                    b.Property<DateTime?>("RolledBackAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("rolled_back_at");

                    b.Property<DateTime>("StartedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("started_at")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id")
                        .HasName("_prisma_migrations_pkey");

                    b.ToTable("_prisma_migrations", (string)null);
                });

            modelBuilder.Entity("PerfumeTrackerAPI.Models.Recommendation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp(3) without time zone")
                        .HasColumnName("date")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Query")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("query");

                    b.Property<string>("Recommendations")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("recommendations");

                    b.HasKey("Id")
                        .HasName("Recommendation_pkey");

                    b.ToTable("Recommendation", (string)null);
                });

            modelBuilder.Entity("PerfumeTrackerAPI.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("color");

                    b.Property<string>("Tag1")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("tag");

                    b.HasKey("Id")
                        .HasName("Tag_pkey");

                    b.HasIndex(new[] { "Tag1" }, "Tag_tag_key")
                        .IsUnique();

                    b.ToTable("Tag", (string)null);
                });

            modelBuilder.Entity("PerfumeTrackerAPI.Models.PerfumeSuggested", b =>
                {
                    b.HasOne("PerfumeTrackerAPI.Models.Perfume", "Perfume")
                        .WithMany("PerfumeSuggesteds")
                        .HasForeignKey("PerfumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PerfumeSuggested_perfumeId_fkey");

                    b.Navigation("Perfume");
                });

            modelBuilder.Entity("PerfumeTrackerAPI.Models.PerfumeTag", b =>
                {
                    b.HasOne("PerfumeTrackerAPI.Models.Perfume", "Perfume")
                        .WithMany("PerfumeTags")
                        .HasForeignKey("PerfumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PerfumeTag_perfumeId_fkey");

                    b.HasOne("PerfumeTrackerAPI.Models.Tag", "Tag")
                        .WithMany("PerfumeTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("PerfumeTag_tagId_fkey");

                    b.Navigation("Perfume");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("PerfumeTrackerAPI.Models.PerfumeWorn", b =>
                {
                    b.HasOne("PerfumeTrackerAPI.Models.Perfume", "Perfume")
                        .WithMany("PerfumeWorns")
                        .HasForeignKey("PerfumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PerfumeWorn_perfumeId_fkey");

                    b.Navigation("Perfume");
                });

            modelBuilder.Entity("PerfumeTrackerAPI.Models.Perfume", b =>
                {
                    b.Navigation("PerfumeSuggesteds");

                    b.Navigation("PerfumeTags");

                    b.Navigation("PerfumeWorns");
                });

            modelBuilder.Entity("PerfumeTrackerAPI.Models.Tag", b =>
                {
                    b.Navigation("PerfumeTags");
                });
#pragma warning restore 612, 618
        }
    }
}
