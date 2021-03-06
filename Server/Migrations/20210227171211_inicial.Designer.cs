﻿// <auto-generated />
using System;
using AppNetS22021.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppNetS22021.Server.Migrations
{
    [DbContext(typeof(RegistroAcademicoContext))]
    [Migration("20210227171211_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppNetS22021.Server.Models.Cursos", b =>
                {
                    b.Property<int>("CursoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCurso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("onLineMaestrosId")
                        .HasColumnType("int");

                    b.Property<int?>("presencialMaestrosID")
                        .HasColumnType("int");

                    b.HasKey("CursoId");

                    b.HasIndex("onLineMaestrosId");

                    b.HasIndex("presencialMaestrosID");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("AppNetS22021.Server.Models.DireccionEstudiante", b =>
                {
                    b.Property<int>("IdDireccionEstudiante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstudianteIdEstudiante")
                        .HasColumnType("int");

                    b.HasKey("IdDireccionEstudiante");

                    b.HasIndex("EstudianteIdEstudiante");

                    b.ToTable("DireccionEstudiantes");
                });

            modelBuilder.Entity("AppNetS22021.Server.Models.Estudiantes", b =>
                {
                    b.Property<int>("IdEstudiante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Altura")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("CursosCursoId")
                        .HasColumnType("int");

                    b.Property<string>("EstudianteNombre")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnName("Nombre")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("FacultadRefId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnName("DoB")
                        .HasColumnType("DateTime2");

                    b.Property<int>("GradoId")
                        .HasColumnType("int");

                    b.Property<int>("NumeroRegistro")
                        .HasColumnType("int");

                    b.Property<float>("Peso")
                        .HasColumnType("real");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("IdEstudiante");

                    b.HasIndex("CursosCursoId");

                    b.HasIndex("FacultadRefId");

                    b.HasIndex("GradoId");

                    b.ToTable("Estudiante","dbo");
                });

            modelBuilder.Entity("AppNetS22021.Server.Models.Facultad", b =>
                {
                    b.Property<int>("FacultadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FacultadId");

                    b.ToTable("Facultad");
                });

            modelBuilder.Entity("AppNetS22021.Server.Models.Grado", b =>
                {
                    b.Property<int>("GradoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GradoNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Seccion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GradoId");

                    b.ToTable("Grado");
                });

            modelBuilder.Entity("AppNetS22021.Server.Models.Maestros", b =>
                {
                    b.Property<int>("MaestroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaestroId");

                    b.ToTable("Maestros");
                });

           
            modelBuilder.Entity("AppNetS22021.Server.Models.Cursos", b =>
                {
                    b.HasOne("AppNetS22021.Server.Models.Maestros", "onLineMaestros")
                        .WithMany("onLineCursos")
                        .HasForeignKey("onLineMaestrosId");

                    b.HasOne("AppNetS22021.Server.Models.Maestros", "presencialMaestros")
                        .WithMany("presencialCursos")
                        .HasForeignKey("presencialMaestrosID");
                });

            modelBuilder.Entity("AppNetS22021.Server.Models.DireccionEstudiante", b =>
                {
                    b.HasOne("AppNetS22021.Server.Models.Estudiantes", "Estudiante")
                        .WithMany()
                        .HasForeignKey("EstudianteIdEstudiante");
                });

            modelBuilder.Entity("AppNetS22021.Server.Models.Estudiantes", b =>
                {
                    b.HasOne("AppNetS22021.Server.Models.Cursos", null)
                        .WithMany("Estudiantes")
                        .HasForeignKey("CursosCursoId");

                    b.HasOne("AppNetS22021.Server.Models.Facultad", "Facultad")
                        .WithMany("EstudiantesFacultades")
                        .HasForeignKey("FacultadRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppNetS22021.Server.Models.Grado", "Grado")
                        .WithMany()
                        .HasForeignKey("GradoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
