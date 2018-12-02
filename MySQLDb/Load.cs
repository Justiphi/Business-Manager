using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLDb
{
    public class Load
    {
        public static User currentUser;
        public static Company currentCompany;

        public static List<Employee> GetAllEmployees(int company)
        {
            List<Employee> employees = new List<Employee>();
            using (var dbContext = new DataContext())
            {
                employees = dbContext.Employees.Where(x => x.CompanyId == company).ToList();
            }
            return (employees);
        }

        public static List<Contact> GetAllContacts(int company)
        {
            List<Contact> contacts = new List<Contact>();
            using (var dbContext = new DataContext())
            {
                contacts = dbContext.Contacts.Where(x => x.ConComp.CompanyId == company).ToList();
            }
            return (contacts);
        }

        public static List<ConComp> GetAllConComps(int company)
        {
            List<ConComp> companies = new List<ConComp>();
            using(var dbContext = new DataContext())
            {
                companies = dbContext.ContactCompanies.Where(x => x.CompanyId == company).Include(x => x.Contacts).ToList();
            }
            return (companies);
        }

        public static Employee GetEmployee(int EmpId)
        {
            Employee employee = new Employee();
            using(var dbContext = new DataContext())
            {
                employee = dbContext.Employees.Where(x => x.EmployeeId == EmpId).ToList().First();
            }
            return (employee);
        }
        
        public static Secret GetEmpSecret(int EmpId)
        {
            Secret secret = new Secret();
            using (var dbContext = new DataContext())
            {
                secret = dbContext.Employees.Where(x => x.EmployeeId == EmpId).ToList().First().Secret;
            }
            return (secret);
        }
        public static Secret GetcontactSecret(int ConId)
        {
            Secret secret = new Secret();
            using (var dbContext = new DataContext())
            {
                secret = dbContext.Contacts.Where(x => x.ContactId == ConId).ToList().First().Secret;
            }
            return (secret);
        }

        public static bool CheckLogin(string user, string password)
        {
            using (var dbContext = new DataContext())
            {
                if(!(dbContext.Users.Where(x => x.UserName == user && x.Password == password).ToList().Count == 0))
                {
                    currentUser = dbContext.Users.Where(x => x.UserName == user && x.Password == password).Include(x => x.Employee).ThenInclude(x => x.Company).First();
                    currentCompany = currentUser.Employee.Company;
                    return (true);
                }
            }
            return (false);
        }
    }
}
