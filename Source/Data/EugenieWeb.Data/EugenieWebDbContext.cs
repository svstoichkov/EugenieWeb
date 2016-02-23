namespace EugenieWeb.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    public class EugenieWebDbContext : IdentityDbContext<User>, IEugenieWebDbContext
    {
        public EugenieWebDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Store> Stores { get; set; }

        public IDbSet<Backup> Backups { get; set; }

        public IDbSet<Download> Downloads { get; set; }

        public IDbSet<Message> Messages { get; set; }

        public static EugenieWebDbContext Create()
        {
            return new EugenieWebDbContext();
        }
    }
}
