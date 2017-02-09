using System;
namespace SPADemo.DataAccessInterface.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        void Rollback();
        ICustomerRepository CustomerRepository { get; }
        IOrderRepository OrderRepository { get; }

    }
}
