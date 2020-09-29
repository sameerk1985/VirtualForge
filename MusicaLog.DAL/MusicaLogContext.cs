using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MusicaLog.DAL
{
    public partial class MusicaLogContext : DbContext
    {
        public MusicaLogContext() : base("name=MusicaLog")
        {
        }

        public DbSet<Common.Models.MusicaLog> MusicaLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
