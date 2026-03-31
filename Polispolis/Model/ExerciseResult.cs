using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polispolis.Model
{
    public class ExerciseResult
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int WorkoutSessionId { get; set; }
        public int ExerciseId { get; set; }

        public double Value { get; set; }
        public int? Reps { get; set; }
        public int? Sets { get; set; }

    }
}
