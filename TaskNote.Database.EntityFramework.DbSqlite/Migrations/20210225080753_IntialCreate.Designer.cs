﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskNote.Database.EntityFramework.DbSqlite;

namespace TaskNote.Database.EntityFramework.DbSqlite.Migrations
{
    [DbContext(typeof(TaskNoteSqliteContext))]
    [Migration("20210225080753_IntialCreate")]
    partial class IntialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("TaskNote.Database.TaskItems.TaskItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT")
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdateData")
                        .HasColumnType("DateTime2")
                        .HasColumnName("updateData");

                    b.HasKey("Id");

                    b.ToTable("tasks");
                });
#pragma warning restore 612, 618
        }
    }
}