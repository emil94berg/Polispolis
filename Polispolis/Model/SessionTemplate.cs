using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Polispolis.Model
{
    public class SessionTemplate
    {
        [PrimaryKey, AutoIncrement]
        public int Id{ get; set; }
        public string Name { get; set; }
    }
}
