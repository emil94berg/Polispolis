using Polispolis.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polispolis.Services.Interfaces
{
    public interface IExerciseService
    {
        Task<List<Exercise>> GetAllExerciseFromCategoryIdAsync(int categoryId);
    }
}
