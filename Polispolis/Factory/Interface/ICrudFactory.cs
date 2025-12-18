using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Polispolis.Factory.Interface
{
    // Added a default constructor constraint to match the implementation's requirement.
    // Ensure this file's members match your existing interface; adjust method signatures if needed.
    public interface ICrudFactory<TModel> where TModel : class, new()
    {
        Task CreateAsync(TModel model);
        Task DeleteAsync(TModel model);
        Task<List<TModel>> GetAllAsync();
        Task UpdateAsync(TModel model);   
    }
}
