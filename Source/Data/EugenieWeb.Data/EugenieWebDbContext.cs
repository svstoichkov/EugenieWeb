namespace EugenieWeb.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;

    using EugenieWeb.Data.Models;

    public class EugenieWebDbContext : IdentityDbContext<User>
    {
        public EugenieWebDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static EugenieWebDbContext Create()
        {
            return new EugenieWebDbContext();
        }
    }
}
