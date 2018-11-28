using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using MySQLDb;

namespace Manager
{
    class Status
    {
        //list for company names and IDs used in the login sequence
        public static List<KeyValuePair<int, string>> CompanyNames;
        //Variable for storing the company currently in use
        public static KeyValuePair<int, string> CurrentCompany;

        //loading stage for splash screen information
        public static int LoadStage = 1;

        //decides if edit pages are editing or adding people
        public static bool EmpEditMode = false;
        public static bool ConEditMode = false;

        //easy access operators for verification
        public static string Password;
        public static int AccessLevel;
        public static int UserId;

        //currently selected IDs for employee and contact browsers
        public static int CurrentEmpId = 0;
        public static Employee CurrentEmployee;
        public static int CurrentConId = 0;
        public static Contact CurrentContact;

        //Lists of all employees and Contacts
        public static List<Employee> AllEmployees;
        public static List<Contact> AllContacts;

        //list or browse mode for filtering
        public static bool ListMode = false;

        //Lists for filtering employees and contacts
        public static List<Employee> FilteredEmployees;
        public static List<Contact> FilteredContacts;

        //bitmap image variable for memory conservation
        public static BitmapImage CurrentImage = new BitmapImage();
    }
}
