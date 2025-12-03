using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polispolis.Model
{
    public class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public enum Units
        {
            Kg,
            Km,
            Units,
            Time 
        }
        public Units? Unit { get; set; }
        public double Goal { get; set; }
    }
}
