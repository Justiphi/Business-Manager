using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLDb
{
    public class Save
    {
        public static void CreateCompany(string CN, string Sect)
        {
            using (var dbContext = new DataContext())
            {
                Company comp = new Company()
                {
                    CompanyName = CN,
                    Sector = Sect
                };
                dbContext.Companies.Add(comp);
                dbContext.SaveChanges();
            }
        }

        public static void CreateEmployee(int Company, string FName, string LName, string reg, string ph, string email, string econ, string img, string rol, string des, string notes, string dob, string avail)
        {
            using (var dbContext = new DataContext())
            {
                Employee emp = new Employee()
                {
                    FirstName = FName,
                    LastName = LName,
                    Region = reg,
                    Email = email,
                    PhoneNumber = ph,
                    EmergencyContact = econ,
                    ImageURL = img,
                    Description = des,
                    StaffNotes = notes,
                    Role = rol,
                    DOB = dob,
                    Availability = avail
                };
                var company = dbContext.Companies.Where(x => x.CompanyId == Company).First();
                if (company.Employees == null)
                {
                    company.Employees = new List<Employee>();
                }
                company.Employees.Add(emp);
                dbContext.SaveChanges();
            }
        }

        public static void CreateEmployee(int Company, Employee emp)
        {
            using (var dbContext = new DataContext())
            {
                var company = dbContext.Companies.Where(x => x.CompanyId == Company).First();
                if (company.Employees == null)
                {
                    company.Employees = new List<Employee>();
                }
                company.Employees.Add(emp);
                dbContext.SaveChanges();
            }
        }

        public static void AddConComp(int Company, string conName, string sec, string notes)
        {
            using (var dbContext = new DataContext())
            {
                ConComp comp = new ConComp()
                {
                    CompanyName = conName,
                    Sector = sec,
                    StaffNotes = notes
                };
                dbContext.Companies.Where(x => x.CompanyId == Company).First().ConComps.Add(comp);
                dbContext.SaveChanges();
            }
        }

        public static void AddConComp(int Company, ConComp comp)
        {
            using (var dbContext = new DataContext())
            {
                dbContext.Companies.Where(x => x.CompanyId == Company).First().ConComps.Add(comp);
                dbContext.SaveChanges();
            }
        }

        public static void AddContact(int Company, int concomp, string fname, string lname, string reg, string email, string ph, string img, string des, string person, string notes, string dob)
        {
            using (var dbContext = new DataContext())
            {
                Contact con = new Contact
                {
                    FirstName = fname,
                    LastName = lname,
                    Region = reg,
                    Email = email,
                    PhoneNumber = ph,
                    ImageURL = img,
                    Description = des,
                    Contacter = person,
                    StaffNotes = notes,
                    DOB = dob
                };
                dbContext.Companies.Where(x => x.CompanyId == Company).First().ConComps.Where(x => x.ConCompId == concomp).First().Contacts.Add(con);
                dbContext.SaveChanges();
            }
        }

        public static void AddContact(int Company, int concomp, Contact con)
        {
            using (var dbContext = new DataContext())
            {
                dbContext.Companies.Where(x => x.CompanyId == Company).First().ConComps.Where(x => x.ConCompId == concomp).First().Contacts.Add(con);
                dbContext.SaveChanges();
            }
        }

        public static void UpdateContact(Contact con)
        {
            using(var dbContext = new DataContext())
            {
                Contact update = dbContext.Contacts.Where(x => x.ContactId == con.ContactId).First();
                dbContext.SaveChanges();
            }
        }

        public static void AuthenticateUser(int employee, string uname, string pass, int al)
        {
            using (var dbContext = new DataContext())
            {
                User use = new User()
                {
                    UserName = uname,
                    Password = pass,
                    AccessLevel = al
                };
                dbContext.Employees.Where(x => x.EmployeeId == employee).First().Login = use;
                dbContext.SaveChanges();
            }
        }

        public static void EmpSecret(int employee, string bank, string ird, string tax)
        {
            using (var dbContext = new DataContext())
            {
                Secret secret = new Secret()
                {
                    BankNo = bank,
                    IRDNo = ird,
                    TaxCode = tax
                };
                dbContext.Employees.Where(x => x.EmployeeId == employee).First().Secret = secret;
                dbContext.SaveChanges();
            }
        }

        public static void EmpSecret(int employee, Secret secret)
        {
            using (var dbContext = new DataContext())
            {
                dbContext.Employees.Where(x => x.EmployeeId == employee).First().Secret = secret;
                dbContext.SaveChanges();
            }
        }

        public static void ConSecret(int employee, string bank, string ird, string tax)
        {
            using (var dbContext = new DataContext())
            {
                Secret secret = new Secret()
                {
                    BankNo = bank,
                    IRDNo = ird,
                    TaxCode = tax
                };
                dbContext.Contacts.Where(x => x.ContactId == employee).First().Secret = secret;
                dbContext.SaveChanges();
            }
        }

        public static void ConSecret(int employee, Secret secret)
        {
            using (var dbContext = new DataContext())
            {
                dbContext.Contacts.Where(x => x.ContactId == employee).First().Secret = secret;
                dbContext.SaveChanges();
            }
        }

        public static void AddCompany(Company company, Employee employee, User user)
        {
            using (var dbContext = new DataContext())
            {
                employee.Login = user;
                company.Employees = new List<Employee> { employee };
                dbContext.Companies.Add(company);
                dbContext.SaveChanges();
            }
        }
    }
}
