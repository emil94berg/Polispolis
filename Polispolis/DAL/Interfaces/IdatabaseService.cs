using Polispolis.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polispolis.DAL.Interfaces
{
    public interface IDatabaseService
    {
        SQLiteAsyncConnection Database { get; }
        Task InitializeAsync();
    }
}
