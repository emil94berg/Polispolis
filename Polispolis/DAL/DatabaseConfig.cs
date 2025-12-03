using System;
using System.Collections.Generic;
using System.Text;

namespace Polispolis.DAL
{
    class DatabaseConfig
    {
        public static string DbPath => System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "exerciseDb.db3");
    }
}
