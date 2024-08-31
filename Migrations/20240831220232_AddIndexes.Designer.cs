﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using clinic_management_dotnet.Data;

#nullable disable

namespace clinic_management_dotnet.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240831220232_AddIndexes")]
    partial class AddIndexes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("clinic_management_dotnet.Models.AddressModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_address");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressNumber")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("nr_address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ds_city");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ds_neighborhood");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("nr_postal_code");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ds_state");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("nm_street");

                    b.HasKey("Id");

                    b.ToTable("T_CM_ADDRESS");
                });

            modelBuilder.Entity("clinic_management_dotnet.Models.HealthPlanModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_health_plan");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Coverage")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ds_coverage");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ds_name");

                    b.Property<string>("PlanCode")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)")
                        .HasColumnName("cod_plan");

                    b.HasKey("Id");

                    b.HasIndex("PlanCode")
                        .IsUnique();

                    b.ToTable("T_CM_HEALTH_PLAN");
                });

            modelBuilder.Entity("clinic_management_dotnet.Models.PatientHealthPlanModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_patient_health_plan");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AccessionDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("dt_accession");

                    b.Property<int>("id_health_plan")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("id_patient")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("id_health_plan");

                    b.HasIndex("id_patient");

                    b.ToTable("T_CM_PATIENT_HEALTH_PLAN");
                });

            modelBuilder.Entity("clinic_management_dotnet.Models.PatientModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_patient");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)")
                        .HasColumnName("nr_cpf");

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(10)")
                        .HasColumnName("dt_birth");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ds_name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)")
                        .HasColumnName("nr_phone");

                    b.Property<int>("id_address")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.HasIndex("id_address");

                    b.ToTable("T_CM_PATIENT");
                });

            modelBuilder.Entity("clinic_management_dotnet.Models.PatientHealthPlanModel", b =>
                {
                    b.HasOne("clinic_management_dotnet.Models.HealthPlanModel", "HealthPlan")
                        .WithMany("PatientHealthPlans")
                        .HasForeignKey("id_health_plan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("clinic_management_dotnet.Models.PatientModel", "Patient")
                        .WithMany("PatientHealthPlans")
                        .HasForeignKey("id_patient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HealthPlan");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("clinic_management_dotnet.Models.PatientModel", b =>
                {
                    b.HasOne("clinic_management_dotnet.Models.AddressModel", "Address")
                        .WithMany()
                        .HasForeignKey("id_address")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("clinic_management_dotnet.Models.HealthPlanModel", b =>
                {
                    b.Navigation("PatientHealthPlans");
                });

            modelBuilder.Entity("clinic_management_dotnet.Models.PatientModel", b =>
                {
                    b.Navigation("PatientHealthPlans");
                });
#pragma warning restore 612, 618
        }
    }
}
