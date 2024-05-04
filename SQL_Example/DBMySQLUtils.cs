﻿using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace SQL_Example
{
    class DBMySQLUtils
    {
        public static MySqlConnection 
        GetDBConnection(string host, int port, string database, string username, string password)
        {
            //Connection String
            String connString = "Server = " + host + ";Database = " + database
                + ";port = " + port + ";User Id = " + username + ";password = " + password;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
    }
}
