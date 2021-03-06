﻿// <auto-generated />
using Cert;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cert.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210121120211_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11");

            modelBuilder.Entity("Cert.Uchastniki_SMEV", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Kratkoe_naimenovanie_IS")
                        .HasColumnType("TEXT");

                    b.Property<string>("Kratkoe_naimenovanie_Uchastnika")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mnemonika_IS_v_SMEV3")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mnemonika_Uchastnika_v_SMEV3")
                        .HasColumnType("TEXT");

                    b.Property<string>("OGRN")
                        .HasColumnType("TEXT");

                    b.Property<string>("Polnoe_naimenovanie_IS")
                        .HasColumnType("TEXT");

                    b.Property<string>("Polnoe_naimenovanie_Uchastnika")
                        .HasColumnType("TEXT");

                    b.Property<int>("Tip_Uchastnika")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Uchastniki_SMEV");
                });
#pragma warning restore 612, 618
        }
    }
}
