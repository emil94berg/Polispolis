using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polispolis.Model
{
    public class WorkoutSession
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int SessíonTemplateId{ get; set; }
        public DateOnly WorkoutDate { get; set; }

    }
}
