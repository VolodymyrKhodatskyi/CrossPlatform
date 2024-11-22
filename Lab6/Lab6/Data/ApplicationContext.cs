using Lab6.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Lab6.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<RefAddressTypes> RefAddressTypes { get; set; }
        public DbSet<CustomerAddresses> CustomerAddresses { get; set; }
        public DbSet<RefCustomerNumberTypes> RefCustomerNumberTypes { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<CustomerPhoneNumbers> CustomerPhoneNumbers { get; set; }
        public DbSet<RefNumberCalledTypes> RefNumberCalledTypes { get; set; }
        public DbSet<CustomerPhoneCalls> CustomerPhoneCalls { get; set; }
        public DbSet<BillDetailLines> BillDetailLines { get; set; }
        public DbSet<BillHeaders> BillHeaders { get; set; }
        public DbSet<Tariffs> Tariffs { get; set; }
        public DbSet<RefTariffTypes> RefTariffTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Addresses>().HasKey(b => b.AddressId);
            modelBuilder.Entity<RefAddressTypes>().HasKey(b => b.AddressTypeCode);
            modelBuilder.Entity<CustomerAddresses>().HasKey(b => b.CustomerAddressId);
            modelBuilder.Entity<RefCustomerNumberTypes>().HasKey(b => b.CustomerNumberTypeCode);
            modelBuilder.Entity<Customers>().HasKey(b => b.CustomerId);
            modelBuilder.Entity<CustomerPhoneNumbers>().HasKey(b => b.CustomerPhoneNumber);
            modelBuilder.Entity<RefNumberCalledTypes>().HasKey(b => b.NumberCalledTypeCode);
            modelBuilder.Entity<CustomerPhoneCalls>().HasKey(b => b.PhoneCallId);
            modelBuilder.Entity<BillDetailLines>().HasKey(b => b.BillDetailLineId);
            modelBuilder.Entity<BillHeaders>().HasKey(b => b.BillHeaderId);
            modelBuilder.Entity<Tariffs>().HasKey(b => b.TariffId);
            modelBuilder.Entity<RefTariffTypes>().HasKey(b => b.TariffTypeCode);

            
            modelBuilder.Entity<CustomerAddresses>()
                .HasOne(b => b.RefAddressTypes)
                .WithMany(a => a.CustomerAddresses)
                .HasForeignKey(b => b.AddressTypeCode)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CustomerAddresses>()
                .HasOne(b => b.Addresses)
                .WithMany(a => a.CustomerAddresses)
                .HasForeignKey(b => b.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CustomerAddresses>()
                .HasOne(b => b.Customers)
                .WithMany(a => a.CustomerAddresses)
                .HasForeignKey(b => b.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CustomerPhoneNumbers>()
                .HasOne(b => b.Customers)
                .WithMany(a => a.CustomerPhoneNumbers)
                .HasForeignKey(b => b.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CustomerPhoneNumbers>()
                .HasOne(b => b.RefCustomerNumberTypes)
                .WithMany(a => a.CustomerPhoneNumbers)
                .HasForeignKey(b => b.CustomerNumberTypeCode)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CustomerPhoneCalls>()
                .HasOne(b => b.CustomerPhoneNumbers)
                .WithMany(a => a.CustomerPhoneCalls)
                .HasForeignKey(b => b.CustomerPhoneNumber)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CustomerPhoneCalls>()
                .HasOne(b => b.RefNumberCalledTypes)
                .WithMany(a => a.CustomerPhoneCalls)
                .HasForeignKey(b => b.NumberCalledTypeCode)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BillHeaders>()
                .HasOne(b => b.CustomerPhoneNumbers)
                .WithMany(a => a.BillHeaders)
                .HasForeignKey(b => b.CustomerPhoneNumber)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tariffs>()
                .HasOne(b => b.RefTariffTypes)
                .WithMany(a => a.Tariffs)
                .HasForeignKey(b => b.TariffTypeCode)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<BillDetailLines>()
                .HasOne(b => b.BillHeaders)
                .WithMany(a => a.BillDetailLines)
                .HasForeignKey(b => b.BillHeaderId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<BillDetailLines>()
                .HasOne(b => b.Tariffs)
                .WithMany(a => a.BillDetailLines)
                .HasForeignKey(b => b.TariffId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<BillDetailLines>()
                .HasOne(b => b.CustomerPhoneCalls)
                .WithMany(a => a.BillDetailLines)
                .HasForeignKey(b => b.PhoneCallId)
                .OnDelete(DeleteBehavior.Restrict);

           
            modelBuilder.Entity<Addresses>().Property(b => b.AddressId).ValueGeneratedOnAdd();
            modelBuilder.Entity<RefAddressTypes>().Property(b => b.AddressTypeCode).ValueGeneratedOnAdd();
            modelBuilder.Entity<CustomerAddresses>().Property(b => b.CustomerAddressId).ValueGeneratedOnAdd();
            modelBuilder.Entity<RefCustomerNumberTypes>().Property(b => b.CustomerNumberTypeCode).ValueGeneratedOnAdd();
            modelBuilder.Entity<Customers>().Property(b => b.CustomerId).ValueGeneratedOnAdd();
            modelBuilder.Entity<CustomerPhoneNumbers>().Property(b => b.CustomerPhoneNumber).ValueGeneratedOnAdd();
            modelBuilder.Entity<RefNumberCalledTypes>().Property(b => b.NumberCalledTypeCode).ValueGeneratedOnAdd();
            modelBuilder.Entity<CustomerPhoneCalls>().Property(b => b.PhoneCallId).ValueGeneratedOnAdd();
            modelBuilder.Entity<BillHeaders>().Property(b => b.BillHeaderId).ValueGeneratedOnAdd();
            modelBuilder.Entity<BillDetailLines>().Property(b => b.BillDetailLineId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Tariffs>().Property(b => b.TariffId).ValueGeneratedOnAdd();
            modelBuilder.Entity<RefTariffTypes>().Property(b => b.TariffTypeCode).ValueGeneratedOnAdd();
        }

        public void Seed()
        {
            

            var addresses = new List<Addresses>
            {
                new Addresses { Line1 = "a", Line2 = "b", Line3 = "c", City = "a", Country="a", ZipPostcode = 111, OtherDetails="a", StateProvinceCountry="a" }
            };
            Addresses.AddRange(addresses);
            SaveChanges();

            var refAddressTypes = new List<RefAddressTypes>
            {
                new RefAddressTypes { AddressTypeDescription = "a"}
            };
            RefAddressTypes.AddRange(refAddressTypes);
            SaveChanges();

            var customers = new List<Customers>
            {
                new Customers { CustomerName = "a", CustomerEmail="a", CustomerAddress="a", CommercialOrDomestic="a", OtherCustomerDetails = "a"}
            };
            Customers.AddRange(customers);
            SaveChanges();

            var customerAddresses = new List<CustomerAddresses>
            {
                new CustomerAddresses { AddressId = addresses[0].AddressId, AddressTypeCode = refAddressTypes[0].AddressTypeCode, CustomerId = customers[0].CustomerId, DateAddressFrom = DateTime.Now.AddDays(-12), DateAddressTo = DateTime.Now.AddDays(12)}
            };
            CustomerAddresses.AddRange(customerAddresses);
            SaveChanges();

            var refCustomerNumberTypes = new List<RefCustomerNumberTypes>
            {
                new RefCustomerNumberTypes { NumberTypeDescription = "a"}
            };
            RefCustomerNumberTypes.AddRange(refCustomerNumberTypes);
            SaveChanges();

            var refTariffTypes = new List<RefTariffTypes>
            {
                new RefTariffTypes { TariffTypeDescription = "a"}
            };
            RefTariffTypes.AddRange(refTariffTypes);
            SaveChanges();

            var refNumberCalledTypes = new List<RefNumberCalledTypes>
            {
                new RefNumberCalledTypes { NumberCalledTypeDescription = "a"}
            };
            RefNumberCalledTypes.AddRange(refNumberCalledTypes);
            SaveChanges();

            var tariffs = new List<Tariffs>
            {
                new Tariffs { TariffName = "a", TariffTypeCode = refTariffTypes[0].TariffTypeCode,  TariffRate = "a", Otherdetails = "a"}
            };
            Tariffs.AddRange(tariffs);
            SaveChanges();

            var customerPhoneNumbers = new List<CustomerPhoneNumbers>
            {
                new CustomerPhoneNumbers {CustomerId = customers[0].CustomerId, CustomerNumberTypeCode = refCustomerNumberTypes[0].CustomerNumberTypeCode,  HeldFromDate = DateTime.Now.AddDays(-12), HeldToDate = DateTime.Now.AddDays(12), OtherDetails = "a" }
            };
            CustomerPhoneNumbers.AddRange(customerPhoneNumbers);
            SaveChanges();

            var customerPhoneCalls = new List<CustomerPhoneCalls>
            {
                new CustomerPhoneCalls {CustomerPhoneNumber = customerPhoneNumbers[0].CustomerPhoneNumber, NumberCalledTypeCode = refNumberCalledTypes[0].NumberCalledTypeCode,  NumberCalled = 1, CallStartDatetime = DateTime.Now.AddDays(-11), CallEndDatetime = DateTime.Now.AddDays(11), OtherDetails = "a" }
            };
            CustomerPhoneCalls.AddRange(customerPhoneCalls);
            SaveChanges();

            var billHeaders = new List<BillHeaders>
            {
                new BillHeaders {CustomerPhoneNumber = customerPhoneNumbers[0].CustomerPhoneNumber,  BillIssuedDate = DateTime.Now.AddDays(-10), PaymentDueDate = DateTime.Now.AddDays(10), OriginalAmountDue = 1, AmountOutstanding = 1 }
            };
            BillHeaders.AddRange(billHeaders);
            SaveChanges();

            var billDetailLines = new List<BillDetailLines>
            {
                new BillDetailLines { PhoneCallId = customerPhoneCalls[0].PhoneCallId, BillHeaderId = billHeaders[0].BillHeaderId,  TariffId = tariffs[0].TariffId, CallDuration = 1, CallCost = 1}
            };
            BillDetailLines.AddRange(billDetailLines);
            SaveChanges();

            


        }
    }
}
