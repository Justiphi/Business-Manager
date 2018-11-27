using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLDb
{
    public class db
    {
        public static string ConnectionString;

        public static void Create()
        {
            using (var dbContext = new DataContext())
            {
                dbContext.Database.EnsureCreated();
            }
        }

        public static List<KeyValuePair<int, string>> GetCompanies()
        {
            using(var dbContext = new DataContext())
            {
                return (dbContext.Companies.Select(x => new KeyValuePair<int, string>(x.CompanyId, x.CompanyName)).ToList());
            }
        }

        public static string CheckDb(int CompanyId)
        {
            using (var dbContext = new DataContext())
            {
                int CountCheck;
                CountCheck = dbContext.Employees.Where(x => x.CompanyId == CompanyId).Count();
                if(CountCheck == 0)
                {
                    return ("employees");
                }
                CountCheck = dbContext.Users.Where(x => x.Employee.CompanyId == CompanyId).Count();
                if(CountCheck == 0)
                {
                    return ("users");
                }
                CountCheck = dbContext.Users.Count();
                return ("ok");
            }
        }

        public static void Connect(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
