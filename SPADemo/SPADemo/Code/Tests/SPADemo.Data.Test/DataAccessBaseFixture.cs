using Castle.Windsor;
using Castle.Windsor.Installer;
using SPADemo.DataAccess.Installers;
using SPADemo.DataAccessInterface.Repository;
using NUnit.Framework;
using System.Configuration;
using System.Data.SqlClient;
using System.Transactions;

namespace SPADemo.Data.Test
{
    /// <summary>
    /// Data Access Base Fixture
    /// </summary>
	[TestFixture]
    public class DataAccessBaseFixture
    {
        protected readonly string ConnectionString = ConfigurationManager.ConnectionStrings["APPNAME"].ConnectionString;

        protected IWindsorContainer container;
        private TransactionScope _scope;
        protected IUnitOfWork _uow;
        /// <summary>
        /// Fixture Set Up
        /// </summary>
        /// <returns></returns>
        [TestFixtureSetUp]
        public virtual void FixtureSetUp()
        {
            container = new WindsorContainer();
            container.Install(FromAssembly.Containing(typeof(DataInstaller)));

        }

        /// <summary>
        /// Test Fixture Tear Down
        /// </summary>
        /// <returns></returns>
        [TestFixtureTearDown]
        public virtual void TestFixtureTearDown()
        {

            container.Dispose();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlstring"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        protected int SQLOperation(string sqlstring, SqlParameter[] sqlParams = null)
        {
            int returnValue;
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cmd = new SqlCommand { CommandText = sqlstring, Connection = connection };

                if (sqlParams != null) cmd.Parameters.AddRange(sqlParams);

                returnValue = System.Convert.ToInt32(cmd.ExecuteScalar());
                // Execute scalar used inseatd of ExecuteNonQuery to return the _scope identity value - Do SELECT SCOPE_IDENTITY() after Insert query
            }

            return returnValue;
        }
    }
}