using SPADemo.BusinessEntities;
using Dapper;
using SPADemo.DataAccess.Constants;
using SPADemo.DataAccess.Context;
using SPADemo.DataAccessInterface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace SPADemo.DataAccess.Repository
{
    public class CustomerRepository : BaseRepository<DapperContext>, ICustomerRepository

    {
        private DapperContext _dataContext;
        public CustomerRepository(DapperContext dbContext)
            : base(dbContext)
        {
            _dataContext = dbContext;
        }

        public IEnumerable<CustomerEntity> GetAll()
        {
            return _dataContext.Query<CustomerEntity>(StoreProcedureConstants.spGetAllCustomer, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<CustomerEntity> GetCustomersByFilter(string filterObject, string sortObject)
        {
            var param = new DynamicParameters();
            param.AddDynamicParams(new
            {
                filterObject,
                sortObject

            });
            return _dataContext.Query<CustomerEntity>(StoreProcedureConstants.spGetCustomersByFilter, param, commandType: CommandType.StoredProcedure);
        }

        public CustomerEntity GetById(int id)
        {
            return _dataContext.Query<CustomerEntity>(StoreProcedureConstants.spGetCustomerByID, new { id = id }, commandType: CommandType.StoredProcedure).SingleOrDefault();
        }


        public void Save(CustomerEntity customer)
        {
            //Contract.Requires<ArgumentNullException>(customer != null, "Customer Entity cannot be null.");

            if (customer.Id == 0)
                Insert(customer);
            else
                Update(customer);
        }

        public void Delete(int Id)
        {
            //  Contract.Requires<ArgumentNullException>(Id != 0, "Provide Valid Customer Id");

            var param = new DynamicParameters();
            param.AddDynamicParams(new
            {
                Id

            });
            _dataContext.Execute(StoreProcedureConstants.spDeleteCustomer, param, commandType: CommandType.StoredProcedure);
        }


        private void Insert(CustomerEntity customer)
        {
            var param = new DynamicParameters();
            param.AddDynamicParams(new
            {
                customer.Id,
                customer.Name,
                customer.Phone,
                customer.Address,
                customer.Email

            });

            param.Add("ID", dbType: DbType.Int32, direction: ParameterDirection.Output);

            _dataContext.Execute(StoreProcedureConstants.spInsertCustomer, param, commandType: CommandType.StoredProcedure);
            customer.Id = param.Get<int>("ID");
        }
        private void Update(CustomerEntity customer)
        {
            var param = new DynamicParameters();
            param.AddDynamicParams(new
            {
                customer.Id,
                customer.Name,
                customer.Phone,
                customer.Address,
                customer.Email
            });

            _dataContext.Execute(StoreProcedureConstants.spUpdateCustomer, param, commandType: CommandType.StoredProcedure);

        }

        public CustomerEntity GetSingleBy(Expression<Func<CustomerEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerEntity> GetBy(Expression<Func<CustomerEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerEntity> GetIncluding(params Expression<Func<CustomerEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }
    }

}
