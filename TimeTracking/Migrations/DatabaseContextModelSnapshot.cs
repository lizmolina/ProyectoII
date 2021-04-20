﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TimeTracking.Models;

namespace TimeTracking.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.Property<long>("ProjectsId")
                        .HasColumnType("bigint")
                        .HasColumnName("projects_id");

                    b.Property<long>("UsersId")
                        .HasColumnType("bigint")
                        .HasColumnName("users_id");

                    b.HasKey("ProjectsId", "UsersId")
                        .HasName("pk_project_user");

                    b.HasIndex("UsersId")
                        .HasDatabaseName("ix_project_user_users_id");

                    b.ToTable("project_user");
                });

            modelBuilder.Entity("TimeTracking.Models.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_projects");

                    b.ToTable("projects");
                });

            modelBuilder.Entity("TimeTracking.Models.Team", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer")
                        .HasColumnName("project_id");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_teams");

                    b.ToTable("teams");
                });

            modelBuilder.Entity("TimeTracking.Models.Tracking", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Hours")
                        .HasColumnType("double precision")
                        .HasColumnName("hours");

                    b.Property<string>("HoursDescription")
                        .HasColumnType("text")
                        .HasColumnName("hours_description");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer")
                        .HasColumnName("project_id");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_tracking");

                    b.ToTable("tracking");
                });

            modelBuilder.Entity("TimeTracking.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users");
                });

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.HasOne("TimeTracking.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .HasConstraintName("fk_project_user_projects_projects_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimeTracking.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .HasConstraintName("fk_project_user_users_users_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
