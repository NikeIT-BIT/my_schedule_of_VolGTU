using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShedule.SheduleClasses
{
    static class Connect
    {
        static public MySqlConnection mycon;
        static public MySqlCommand mycom;
        static public string connect = "Server=localhost;Database=example_app;port=3306;UserId=sail;password=password;";
    }
}
