using System;
using System.Collections.Generic;
using System.Text;

namespace Polispolis.Model
{
    internal class Exercise
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public enum Units
        {
            Kg,
            M,
            Time
        } 
        public Units Unit { get; set; }
        public int Reps { get; set; }
    }
}
