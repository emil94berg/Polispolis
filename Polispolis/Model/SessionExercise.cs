using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polispolis.Model
{
    public class SessionExercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int SessionTemplateId { get; set; }
        public int ExerciseId { get; set; }
    }
}
