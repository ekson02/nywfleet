using System.Data.Entity;

namespace NywFleet.Data.DataContext {
    public class QTestContext : DbContext {
        static QTestContext() {
            Database.SetInitializer<QTestContext>(null);
        }

        public QTestContext()
            : base("Name=NywFleetContext") {
        }


        //public DbSet<UserTest> UserTests { get; set; }
        public int? UserId { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

        }
    }
}
