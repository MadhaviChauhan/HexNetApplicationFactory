using SPADemo.DataAccess.CustomMaps;
using NUnit.Framework;

namespace SPADemo.Data.Test
{
    /// <summary>
    /// 
    /// </summary>
    [SetUpFixture]
    public class BaseFixture
    {
        /// <summary>
        /// 
        /// </summary>
        public BaseFixture()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void Setup()
        {
            var mastermap = new MasterMap();
        }
    }
}