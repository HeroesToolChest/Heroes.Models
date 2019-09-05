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
            AbilityTalentId abilityId1 = new AbilityTalentId("1", "1");
            AbilityTalentId abilityId2 = new AbilityTalentId("1", "1");

            Assert.IsTrue(abilityId1 == abilityId2);
        }

        [TestMethod]
        public void AbilityIdNotEqualsTest()
        {
            AbilityTalentId abilityId1 = new AbilityTalentId("1", "1");
            AbilityTalentId abilityId2 = new AbilityTalentId("2", "2");

            Assert.IsTrue(abilityId1 != abilityId2);
        }

        [TestMethod]
        public void EqualsNullTest()
        {
            AbilityTalentId? abilityId1 = null;
            AbilityTalentId abilityId2 = new AbilityTalentId("1", "1");

            AbilityTalentId? abilityId3 = null;
            AbilityTalentId? abilityId4 = null;

            Assert.IsFalse(abilityId1 == abilityId2);
            Assert.IsTrue(abilityId3 == abilityId4);
        }

        [TestMethod]
        public void NotEqualsNullTest()
        {
            AbilityTalentId? abilityId1 = null;
            AbilityTalentId abilityId2 = new AbilityTalentId("1", "1");

            Assert.IsTrue(abilityId1 != abilityId2);
        }
    }
}
