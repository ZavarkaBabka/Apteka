using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using NpgsqlTypes;

namespace Apteka
{
    class DataBase1
    {
        public static NpgsqlConnection conn;
        public static NpgsqlTransaction t;
        public static NpgsqlCommand command;
        public static NpgsqlDataReader dr;

    }
}
