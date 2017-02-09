using Castle.Windsor;
using SPADemo.Common.Dapper;
using SPADemo.DataAccessInterface;
using SPADemo.DataAccessInterface.Repository;
using System;

namespace SPADemo.DataAccess.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private DapperContext _dbContext = null;
        private ContextUoW _unitofWork;
        private ICustomerRepository _customerRepository = null;
        private IOrderRepository _orderRepository = null;

        //Castle Container
        private IWindsorContainer _container;
        public UnitOfWork(DapperContext dbcontext, IWindsorContainer container)
        {
            _dbContext = dbcontext;
            _unitofWork = _dbContext.CreateUnitOfWork();
            _container = container;
        }

        public ICustomerRepository CustomerRepository
        {
            //return _customerRep ?? new CustomerRepository(_dbContext); 
            get
            {

                if (this._customerRepository == null)
                {
                    _customerRepository = _container.Resolve<ICustomerRepository>(new { dbContext = _dbContext });

                }
                return _customerRepository;
            }

        }

        public IOrderRepository OrderRepository
        {
            get
            {

                if (this._orderRepository == null)
                {
                    _orderRepository = _container.Resolve<IOrderRepository>(new { dbContext = _dbContext }); //Windsor container

                }
                return _orderRepository;
            }
        }




        /// <summary>
        /// 
        /// </summary>
        /// <returns>1 if successful or -1 if Invalid Operation</returns>
        public int Commit()
        {
            try
            {
                _unitofWork.SaveChanges();
                return 1;
            }
            catch (InvalidOperationException ex)
            {
                return -1;
            }
        }

        public void Rollback()
        {
            _dbContext.Dispose();
        }

        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }

    }
}
