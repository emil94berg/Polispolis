using Polispolis.DAL.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polispolis.DAL
{
    class DatabaseService : IDatabaseService
    {
        public SQLiteAsyncConnection Database { get; }
        public DatabaseService()
        {
            Database = new SQLiteAsyncConnection(DatabaseConfig.DbPath);
        }

        public async Task InitializeAsync()
        {
            await Database.CreateTableAsync<Model.Exercise>();
            await Database.CreateTableAsync<Model.Category>();
        }
        public async Task AddExerciseAsync(Model.Exercise exercise)
        {
            await Database.InsertAsync(exercise);
        }
        public async Task<List<Model.Exercise>> GetAllExercisesAsync()
        {
            return await Database.Table<Model.Exercise>().ToListAsync();
        }
        public async Task<List<Model.Exercise>> GetExerciseByCategoryAsync(int CategoryId)
        {
            return await Database.Table<Model.Exercise>()
                .Where(e => e.Id == CategoryId)
                .ToListAsync();
        }
    }
}
