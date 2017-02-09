using SPADemo.Common.Dapper;
using System;
using System.Linq;
namespace SPADemo.DataAccess.Repository
{
    public abstract class BaseRepository<TContext> : IDisposable
        where TContext : DbContext
    {
        private TContext _dataContext;

        public BaseRepository(DbContext context)
        {
            _dataContext = (TContext)context;
        }

        public void SetIdentity<T>(Action<T> setId)
        {
            dynamic identity = _dataContext.Query("SELECT @@IDENTITY AS Id").Single();
            T newId = (T)identity.Id;
            setId(newId);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}