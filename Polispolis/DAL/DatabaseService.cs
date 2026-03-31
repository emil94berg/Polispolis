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
        public static async Task<DatabaseService> CreateAsync()
        {
            var svc = new DatabaseService();
            await svc.InitializeAsync();
            return svc;
        }

        public async Task InitializeAsync()
        {
            await Database.CreateTableAsync<Model.Exercise>();
            await Database.CreateTableAsync<Model.Category>();
        }
        
    }
}
