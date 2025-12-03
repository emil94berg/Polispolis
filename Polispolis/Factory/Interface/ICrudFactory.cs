using System;
using System.Collections.Generic;
using System.Text;

namespace Polispolis.Factory.Interface
{
    interface ICrudFactory<TModel> where TModel : class
    {
        Task CreateAsync(TModel model);
        Task DeleteAsync(TModel model);
        Task<List<TModel>> GetAll(TModel model);
        
        
    }
}
