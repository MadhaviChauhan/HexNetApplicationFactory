using IdentityServer3.Admin.EntityFramework;
using IdentityServer3.Admin.EntityFramework.Entities;

namespace SPADemo.AppSecurity.Service
{
    public class IdentityAdminManagerService : IdentityAdminCoreManager<IdentityClient, int, IdentityScope, int>
    {
        public IdentityAdminManagerService()
            : base("SecurityTokenServiceConfig")
        {

        }
    }
}