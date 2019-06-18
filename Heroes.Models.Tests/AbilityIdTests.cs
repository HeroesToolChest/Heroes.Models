using Heroes.Models.AbilityTalents;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Heroes.Models.Tests
{
    [TestClass]
    public class AbilityIdTests
    {
        [TestMethod]
        public void AbilityIdEqualsTest()
        {
            AbilityId abilityId1 = new AbilityId("1", "1");
            AbilityId abilityId2 = new AbilityId("1", "1");

            Assert.IsTrue(abilityId1 == abilityId2);
        }

        [TestMethod]
        public void AbilityIdNotEqualsTest()
        {
            AbilityId abilityId1 = new AbilityId("1", "1");
            AbilityId abilityId2 = new AbilityId("2", "2");

            Assert.IsTrue(abilityId1 != abilityId2);
        }

        [TestMethod]
        public void EqualsNullTest()
        {
            AbilityId abilityId1 = null;
            AbilityId abilityId2 = new AbilityId("1", "1");

            Assert.IsFalse(abilityId1 == abilityId2);
        }

        [TestMethod]
        public void NotEqualsNullTest()
        {
            AbilityId abilityId1 = null;
            AbilityId abilityId2 = new AbilityId("1", "1");

            Assert.IsFalse(abilityId1 != abilityId2);
        }
    }
}
