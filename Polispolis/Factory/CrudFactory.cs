using System;
using System.Collections.Generic;
using System.Text;
using Polispolis.Factory.Interface;
using Polispolis.DAL.Interfaces;

namespace Polispolis.Factory
{
    class CrudFactory<TModel> : ICrudFactory<TModel> where TModel : class, new()
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
        public async Task<List<TModel>> GetAll(TModel model)
        {
            var database = _databaseService.Database;
            var list = await database.Table<TModel>().ToListAsync();
            return list;
        }
    }
}
