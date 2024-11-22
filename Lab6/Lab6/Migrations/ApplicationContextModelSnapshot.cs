﻿// <auto-generated />
using System;
using Lab6.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab6.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lab6.Models.Addresses", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Line2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Line3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateProvinceCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipPostcode")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Lab6.Models.BillDetailLines", b =>
                {
                    b.Property<int>("BillDetailLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillDetailLineId"));

                    b.Property<int>("BillHeaderId")
                        .HasColumnType("int");

                    b.Property<int>("CallCost")
                        .HasColumnType("int");

                    b.Property<int>("CallDuration")
                        .HasColumnType("int");

                    b.Property<int>("PhoneCallId")
                        .HasColumnType("int");

                    b.Property<int>("TariffId")
                        .HasColumnType("int");

                    b.HasKey("BillDetailLineId");

                    b.HasIndex("BillHeaderId");

                    b.HasIndex("PhoneCallId");

                    b.HasIndex("TariffId");

                    b.ToTable("BillDetailLines");
                });

            modelBuilder.Entity("Lab6.Models.BillHeaders", b =>
                {
                    b.Property<int>("BillHeaderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillHeaderId"));

                    b.Property<int>("AmountOutstanding")
                        .HasColumnType("int");

                    b.Property<DateTime>("BillIssuedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerPhoneNumber")
                        .HasColumnType("int");

                    b.Property<int>("OriginalAmountDue")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDueDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BillHeaderId");

                    b.HasIndex("CustomerPhoneNumber");

                    b.ToTable("BillHeaders");
                });

            modelBuilder.Entity("Lab6.Models.CustomerAddresses", b =>
                {
                    b.Property<int>("CustomerAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerAddressId"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("AddressTypeCode")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAddressFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateAddressTo")
                        .HasColumnType("datetime2");

                    b.HasKey("CustomerAddressId");

                    b.HasIndex("AddressId");

                    b.HasIndex("AddressTypeCode");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerAddresses");
                });

            modelBuilder.Entity("Lab6.Models.CustomerPhoneCalls", b =>
                {
                    b.Property<int>("PhoneCallId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhoneCallId"));

                    b.Property<DateTime>("CallEndDatetime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CallStartDatetime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerPhoneNumber")
                        .HasColumnType("int");

                    b.Property<int>("NumberCalled")
                        .HasColumnType("int");

                    b.Property<int>("NumberCalledTypeCode")
                        .HasColumnType("int");

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhoneCallId");

                    b.HasIndex("CustomerPhoneNumber");

                    b.HasIndex("NumberCalledTypeCode");

                    b.ToTable("CustomerPhoneCalls");
                });

            modelBuilder.Entity("Lab6.Models.CustomerPhoneNumbers", b =>
                {
                    b.Property<int>("CustomerPhoneNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerPhoneNumber"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerNumberTypeCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("HeldFromDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HeldToDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerPhoneNumber");

                    b.HasIndex("CustomerId");

                    b.HasIndex("CustomerNumberTypeCode");

                    b.ToTable("CustomerPhoneNumbers");
                });

            modelBuilder.Entity("Lab6.Models.Customers", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("CommercialOrDomestic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherCustomerDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Lab6.Models.RefAddressTypes", b =>
                {
                    b.Property<int>("AddressTypeCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressTypeCode"));

                    b.Property<string>("AddressTypeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressTypeCode");

                    b.ToTable("RefAddressTypes");
                });

            modelBuilder.Entity("Lab6.Models.RefCustomerNumberTypes", b =>
                {
                    b.Property<int>("CustomerNumberTypeCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerNumberTypeCode"));

                    b.Property<string>("NumberTypeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerNumberTypeCode");

                    b.ToTable("RefCustomerNumberTypes");
                });

            modelBuilder.Entity("Lab6.Models.RefNumberCalledTypes", b =>
                {
                    b.Property<int>("NumberCalledTypeCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumberCalledTypeCode"));

                    b.Property<string>("NumberCalledTypeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NumberCalledTypeCode");

                    b.ToTable("RefNumberCalledTypes");
                });

            modelBuilder.Entity("Lab6.Models.RefTariffTypes", b =>
                {
                    b.Property<int>("TariffTypeCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TariffTypeCode"));

                    b.Property<string>("TariffTypeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TariffTypeCode");

                    b.ToTable("RefTariffTypes");
                });

            modelBuilder.Entity("Lab6.Models.Tariffs", b =>
                {
                    b.Property<int>("TariffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TariffId"));

                    b.Property<string>("Otherdetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TariffName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TariffRate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TariffTypeCode")
                        .HasColumnType("int");

                    b.HasKey("TariffId");

                    b.HasIndex("TariffTypeCode");

                    b.ToTable("Tariffs");
                });

            modelBuilder.Entity("Lab6.Models.BillDetailLines", b =>
                {
                    b.HasOne("Lab6.Models.BillHeaders", "BillHeaders")
                        .WithMany("BillDetailLines")
                        .HasForeignKey("BillHeaderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Lab6.Models.CustomerPhoneCalls", "CustomerPhoneCalls")
                        .WithMany("BillDetailLines")
                        .HasForeignKey("PhoneCallId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Lab6.Models.Tariffs", "Tariffs")
                        .WithMany("BillDetailLines")
                        .HasForeignKey("TariffId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BillHeaders");

                    b.Navigation("CustomerPhoneCalls");

                    b.Navigation("Tariffs");
                });

            modelBuilder.Entity("Lab6.Models.BillHeaders", b =>
                {
                    b.HasOne("Lab6.Models.CustomerPhoneNumbers", "CustomerPhoneNumbers")
                        .WithMany("BillHeaders")
                        .HasForeignKey("CustomerPhoneNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CustomerPhoneNumbers");
                });

            modelBuilder.Entity("Lab6.Models.CustomerAddresses", b =>
                {
                    b.HasOne("Lab6.Models.Addresses", "Addresses")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Lab6.Models.RefAddressTypes", "RefAddressTypes")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("AddressTypeCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Lab6.Models.Customers", "Customers")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Addresses");

                    b.Navigation("Customers");

                    b.Navigation("RefAddressTypes");
                });

            modelBuilder.Entity("Lab6.Models.CustomerPhoneCalls", b =>
                {
                    b.HasOne("Lab6.Models.CustomerPhoneNumbers", "CustomerPhoneNumbers")
                        .WithMany("CustomerPhoneCalls")
                        .HasForeignKey("CustomerPhoneNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Lab6.Models.RefNumberCalledTypes", "RefNumberCalledTypes")
                        .WithMany("CustomerPhoneCalls")
                        .HasForeignKey("NumberCalledTypeCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CustomerPhoneNumbers");

                    b.Navigation("RefNumberCalledTypes");
                });

            modelBuilder.Entity("Lab6.Models.CustomerPhoneNumbers", b =>
                {
                    b.HasOne("Lab6.Models.Customers", "Customers")
                        .WithMany("CustomerPhoneNumbers")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Lab6.Models.RefCustomerNumberTypes", "RefCustomerNumberTypes")
                        .WithMany("CustomerPhoneNumbers")
                        .HasForeignKey("CustomerNumberTypeCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customers");

                    b.Navigation("RefCustomerNumberTypes");
                });

            modelBuilder.Entity("Lab6.Models.Tariffs", b =>
                {
                    b.HasOne("Lab6.Models.RefTariffTypes", "RefTariffTypes")
                        .WithMany("Tariffs")
                        .HasForeignKey("TariffTypeCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RefTariffTypes");
                });

            modelBuilder.Entity("Lab6.Models.Addresses", b =>
                {
                    b.Navigation("CustomerAddresses");
                });

            modelBuilder.Entity("Lab6.Models.BillHeaders", b =>
                {
                    b.Navigation("BillDetailLines");
                });

            modelBuilder.Entity("Lab6.Models.CustomerPhoneCalls", b =>
                {
                    b.Navigation("BillDetailLines");
                });

            modelBuilder.Entity("Lab6.Models.CustomerPhoneNumbers", b =>
                {
                    b.Navigation("BillHeaders");

                    b.Navigation("CustomerPhoneCalls");
                });

            modelBuilder.Entity("Lab6.Models.Customers", b =>
                {
                    b.Navigation("CustomerAddresses");

                    b.Navigation("CustomerPhoneNumbers");
                });

            modelBuilder.Entity("Lab6.Models.RefAddressTypes", b =>
                {
                    b.Navigation("CustomerAddresses");
                });

            modelBuilder.Entity("Lab6.Models.RefCustomerNumberTypes", b =>
                {
                    b.Navigation("CustomerPhoneNumbers");
                });

            modelBuilder.Entity("Lab6.Models.RefNumberCalledTypes", b =>
                {
                    b.Navigation("CustomerPhoneCalls");
                });

            modelBuilder.Entity("Lab6.Models.RefTariffTypes", b =>
                {
                    b.Navigation("Tariffs");
                });

            modelBuilder.Entity("Lab6.Models.Tariffs", b =>
                {
                    b.Navigation("BillDetailLines");
                });
#pragma warning restore 612, 618
        }
    }
}