using SPADemo.BusinessEntities;
using SPADemo.Common.Dapper;
using Dapper;

namespace SPADemo.DataAccess.CustomMaps.Shared
{
    internal class AuditDetailMap
    {
        internal AuditDetailMap()
        {
            var map = new CustomTypeMap<CustomerEntity>();
            map.Map("CustomerID", "Id");
            SqlMapper.SetTypeMap(map.Type, map);
        }
    }
}