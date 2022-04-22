﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SCANS_CQRS.Context;

namespace SCANS_CQRS.Migrations
{
    [DbContext(typeof(ScanDbContext))]
    [Migration("20220422215148_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SCANS_CQRS.Entity.Editora", b =>
                {
                    b.Property<int>("IdEditora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeEditora")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEditora");

                    b.ToTable("Editoras");
                });

            modelBuilder.Entity("SCANS_CQRS.Entity.HQ", b =>
                {
                    b.Property<int>("IdHQ")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DscResumoHQ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EditoraIdEditora")
                        .HasColumnType("int");

                    b.Property<int>("IdEditora")
                        .HasColumnType("int");

                    b.Property<int>("IdIdioma")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoPublicacao")
                        .HasColumnType("int");

                    b.Property<int?>("IdiomaIdIdioma")
                        .HasColumnType("int");

                    b.Property<string>("NomeHQ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroHQ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoPublicacaoIdTipoPublicacao")
                        .HasColumnType("int");

                    b.Property<string>("VolumeHQ")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdHQ");

                    b.HasIndex("EditoraIdEditora");

                    b.HasIndex("IdiomaIdIdioma");

                    b.HasIndex("TipoPublicacaoIdTipoPublicacao");

                    b.ToTable("HQs");
                });

            modelBuilder.Entity("SCANS_CQRS.Entity.HQ_PersEquipe", b =>
                {
                    b.Property<int>("IdHQPersEquipe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HQIdHQ")
                        .HasColumnType("int");

                    b.Property<int>("IdHQ")
                        .HasColumnType("int");

                    b.Property<int>("IdPersEquipe")
                        .HasColumnType("int");

                    b.Property<int?>("PersEquipeIdPersEquipe")
                        .HasColumnType("int");

                    b.HasKey("IdHQPersEquipe");

                    b.HasIndex("HQIdHQ");

                    b.HasIndex("PersEquipeIdPersEquipe");

                    b.ToTable("HQ_PersEquipes");
                });

            modelBuilder.Entity("SCANS_CQRS.Entity.Idioma", b =>
                {
                    b.Property<int>("IdIdioma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeIdioma")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdIdioma");

                    b.ToTable("Idiomas");
                });

            modelBuilder.Entity("SCANS_CQRS.Entity.PersEquipe", b =>
                {
                    b.Property<int>("IdPersEquipe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DscPersEquipe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomePersEquipe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPersEquipe");

                    b.ToTable("PersEquipes");
                });

            modelBuilder.Entity("SCANS_CQRS.Entity.TipoPublicacao", b =>
                {
                    b.Property<int>("IdTipoPublicacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeTipoPublicacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoPublicacao");

                    b.ToTable("TipoPublicacoes");
                });

            modelBuilder.Entity("SCANS_CQRS.Entity.HQ", b =>
                {
                    b.HasOne("SCANS_CQRS.Entity.Editora", "Editora")
                        .WithMany("HQs")
                        .HasForeignKey("EditoraIdEditora");

                    b.HasOne("SCANS_CQRS.Entity.Idioma", "Idioma")
                        .WithMany("HQs")
                        .HasForeignKey("IdiomaIdIdioma");

                    b.HasOne("SCANS_CQRS.Entity.TipoPublicacao", "TipoPublicacao")
                        .WithMany("HQs")
                        .HasForeignKey("TipoPublicacaoIdTipoPublicacao");

                    b.Navigation("Editora");

                    b.Navigation("Idioma");

                    b.Navigation("TipoPublicacao");
                });

            modelBuilder.Entity("SCANS_CQRS.Entity.HQ_PersEquipe", b =>
                {
                    b.HasOne("SCANS_CQRS.Entity.HQ", "HQ")
                        .WithMany("HQ_PersEquipe")
                        .HasForeignKey("HQIdHQ");

                    b.HasOne("SCANS_CQRS.Entity.PersEquipe", "PersEquipe")
                        .WithMany("HQ_PersEquipe")
                        .HasForeignKey("PersEquipeIdPersEquipe");

                    b.Navigation("HQ");

                    b.Navigation("PersEquipe");
                });

            modelBuilder.Entity("SCANS_CQRS.Entity.Editora", b =>
                {
                    b.Navigation("HQs");
                });

            modelBuilder.Entity("SCANS_CQRS.Entity.HQ", b =>
                {
                    b.Navigation("HQ_PersEquipe");
                });

            modelBuilder.Entity("SCANS_CQRS.Entity.Idioma", b =>
                {
                    b.Navigation("HQs");
                });

            modelBuilder.Entity("SCANS_CQRS.Entity.PersEquipe", b =>
                {
                    b.Navigation("HQ_PersEquipe");
                });

            modelBuilder.Entity("SCANS_CQRS.Entity.TipoPublicacao", b =>
                {
                    b.Navigation("HQs");
                });
#pragma warning restore 612, 618
        }
    }
}
