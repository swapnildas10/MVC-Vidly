using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Helpers
    {
        public static string GetRDSConnection()
        {
            var appConfig = ConfigurationManager.AppSettings;

            string dbname = appConfig["mydb"];

            if (string.IsNullOrEmpty(dbname)) return null;

            string username = appConfig["swapnildas10"];
            string password = appConfig["Watermelon10!)"];
            string hostname = appConfig["mydbinstance.cthhfo74uhgt.us-west-1.rds.amazonaws.com"];
            string port = appConfig["1433"];

            return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";
        }
    }
}