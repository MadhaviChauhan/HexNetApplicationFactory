
using SPADemo.Common.Dapper;
using System;
namespace SPADemo.DataAccess.Context
{
    public class DapperContext : DbContext, IDisposable
    {
        public DapperContext() : base("APPNAME") { }
    }
}