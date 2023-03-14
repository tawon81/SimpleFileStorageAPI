﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleFileStorageAPI.Data;

#nullable disable

namespace SimpleFileStorageAPI.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20230314062821_DropChecksum")]
    partial class DropChecksum
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("SimpleFileStorageAPI.Models.BinaryFile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CheckSum")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("FileData")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Version")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("ApiFiles");
                });
#pragma warning restore 612, 618
        }
    }
}
