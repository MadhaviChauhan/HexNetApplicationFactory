using System.Collections.Generic;

namespace SPADemo.DataAccessInterface.Repository
{
    public interface IGetAll<out T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}