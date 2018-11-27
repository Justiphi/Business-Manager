using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MySQLDb
{

    public class DataContext : DbContext
    {

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ConComp> ContactCompanies { get; set; }
        public DbSet<Secret> Info { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(db.ConnectionString);
        }
    }

    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int AccessLevel { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }

    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Sector { get; set; }
        public List<ConComp> ConComps { get; set; }
        public List<Employee> Employees { get; set; }
    }

    public class ConComp
    {
        public int ConCompId { get; set; }
        public string CompanyName { get; set; }
        public string Sector { get; set; }
        public string StaffNotes { get; set; }
        public List<Contact> Contacts { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }

    public class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Region { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public string Contacter { get; set; }
        public string StaffNotes { get; set; }
        public string DOB { get; set; }
        public int ConCompId { get; set; }
        public ConComp ConComp { get; set; }
        public Secret Secret { get; set; }
    }

    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Region { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string EmergencyContact { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public string Role { get; set; }
        public string StaffNotes { get; set; }
        public string DOB { get; set; }
        public string Availability { get; set; }
        public User Login { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public Secret Secret { get; set; }
    }

    public class Secret
    {
        public int SecretId { get; set; }
        public string BankNo { get; set; }
        public string IRDNo { get; set; }
        public string TaxCode { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
