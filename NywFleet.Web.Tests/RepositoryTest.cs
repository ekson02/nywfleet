using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NywFleet.Data;

namespace NywFleet.Tests {
    [TestClass]
    public class RepositoryTest {
        [TestMethod]
        public void TestMethod1() {
            using (var db = new FleetUow()) {
                var category = db.Engines.Query().ToList();
                Assert.IsTrue(category.Count > 0);
            }
        }
    }
}
