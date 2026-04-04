using System;
using System.Collections.Generic;
using System.Text;
using Polispolis.Factory.Interface;
using Polispolis.DAL.Interfaces;
using System.Collections.ObjectModel;

namespace Polispolis.Factory
{
    public class CrudFactory<TModel> : ICrudFactory<TModel> where TModel : class, new()
    {
        private readonly IDatabaseService _databaseService;
        public CrudFactory(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public async Task CreateAsync(TModel model)
        {
            var database = _databaseService.Database;
            await database.InsertAsync(model);
        }
        public async Task DeleteAsync(TModel model)
        {
            var database = _databaseService.Database;
            await database.DeleteAsync(model);
        }
        public async Task<ObservableCollection<TModel>> GetAllAsync()
        {
            var database = _databaseService.Database;
            var list = await database.Table<TModel>().ToListAsync();
            return new ObservableCollection<TModel>(list);
        }
        public async Task UpdateAsync(TModel model)
        {
            var database = _databaseService.Database;
            await database.UpdateAsync(model);
        }
        
    }
}
