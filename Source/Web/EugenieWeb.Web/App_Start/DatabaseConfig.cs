namespace Eugenie.Server.Api
{
    using System.Data.Entity;

    using EugenieWeb.Data;
    using EugenieWeb.Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EugenieWebDbContext, Configuration>());
            EugenieWebDbContext.Create().Database.Initialize(true);
        }
    }
}