using CpfGenerator.Entities;
using CpfGenerator.Interfaces;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CpfGenerator.Database
{
    public class DatabaseAccess
    {
        readonly SQLiteAsyncConnection db;
        public DatabaseAccess()
        {
            try
            {
                var config = DependencyService.Get<IConfig>();

                var connectionFactory = new Func<SQLiteConnectionWithLock>(() => new SQLiteConnectionWithLock(config.Plataforma, new SQLiteConnectionString(config.SQLiteDirectory + "\\cpfgenerator.db3", storeDateTimeAsTicks: false)));

                db = new SQLiteAsyncConnection(connectionFactory);
                db.CreateTableAsync<Cpf>().Wait();
            }
            catch (Exception ex)
            {

                throw ex;
            }           
        }
        
        public Task<List<Cpf>> GetAll()
        {
            return db.Table<Cpf>().ToListAsync();
        }

        public Task<Cpf> GetById(int id)
        {
            return db.Table<Cpf>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> Save(Cpf cpf)
        {
            return db.InsertAsync(cpf);
        }

        public Task<int> DeleteAll()
        {
            return db.DeleteAllAsync<Cpf>();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
