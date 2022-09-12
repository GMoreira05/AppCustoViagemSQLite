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

        public Task<Viagem> InsertViagem(Viagem v)
        {
             _db.InsertAsync(v);

            return _db.Table<Viagem>().OrderByDescending(i => i.Id).FirstOrDefaultAsync();
        }

        public Task<int> DeleteViagem(int id)
        {
            return _db.Table<Viagem>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Pedagio>> GetAllPedagios(int id_viagem)
        {
            return _db.Table<Pedagio>().OrderByDescending(i => i.Id_Viagem == id_viagem).ToListAsync();
        }

        public Task<int> InsertPedagio(Pedagio p)
        {
            return _db.InsertAsync(p);

            //return _db.Table<Viagem>().OrderByDescending(i => i.Id).FirstOrDefaultAsync();
        }
    }
}
