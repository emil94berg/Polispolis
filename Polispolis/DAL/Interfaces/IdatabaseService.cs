using Polispolis.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polispolis.DAL.Interfaces
{
    public interface IDatabaseService
    {
        Task InitializeAsync();
        Task AddExerciseAsync(Exercise exercise);
        Task<List<Exercise>> GetAllExercisesAsync();
        Task<List<Exercise>> GetExerciseByCategoryAsync(int categoryId);
        SQLiteAsyncConnection Database { get; }
    }
}
