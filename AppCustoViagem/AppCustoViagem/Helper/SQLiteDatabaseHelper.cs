using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using AppCustoViagem.Model;
using System.Threading.Tasks;

namespace AppCustoViagem.Helper
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _db;

        public SQLiteDatabaseHelper(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Viagem>().Wait();
            _db.CreateTableAsync<Pedagio>().Wait();
        }
        public Task<List<Viagem>> GetAllViagens()
        {
            return _db.Table<Viagem>().OrderByDescending(i => i.Id).ToListAsync();
        }

        public Task<Viagem> GetViagemById(int id)
        {
            return _db.Table<Viagem>().FirstAsync(i => i.Id == id);
        }

        public Task<int> InsertViagem(Viagem v)
        {
            return _db.InsertAsync(v);
        }

        public Task<int> DeleteViagem(int id)
        {
            return _db.Table<Viagem>().DeleteAsync(i => i.Id == id);
        }
    }
}
