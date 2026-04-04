using Polispolis.DAL.Interfaces;
using Polispolis.Model;
using Polispolis.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polispolis.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IDatabaseService _databaseService;
        public ExerciseService(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<List<Exercise>> GetAllExerciseFromCategoryIdAsync(int categoryId)
        {
            var database = _databaseService.Database;
            var list = await database.Table<Exercise>().Where(p => p.CategoryId == categoryId).ToListAsync();
            if(list != null)
            {
                return list;
            }
            return new List<Exercise>();
        }


    }
}
