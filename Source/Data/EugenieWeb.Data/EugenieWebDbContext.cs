namespace EugenieWeb.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Eugenie.Data;
    
    using EugenieWeb.Data.Models;

    public class EugenieWebDbContext : IdentityDbContext<User>, IEugenieWebDbContext
    {
        public EugenieWebDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static EugenieWebDbContext Create()
        {
            return new EugenieWebDbContext();
        }

        public IDbSet<Store> Stores { get; set; }
    }
}
