using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Heroes.Models.Tests
{
    [TestClass]
    public class UnitArmorTests
    {
        [TestMethod]
        public void SameUnitArmorObjectsTests()
        {
            UnitArmor unitArmor = new UnitArmor()
            {
                Type = "Hero",
                AbilityArmor = 5,
            };

            UnitArmor unitArmor2 = new UnitArmor()
            {
                Type = "Hero",
                AbilityArmor = 25,
            };

            Assert.IsTrue(unitArmor.Equals(unitArmor2));
        }

        [TestMethod]
        public void DifferentUnitArmorObjectsTests()
        {
            UnitArmor unitArmor = new UnitArmor()
            {
                Type = "Hero",
                AbilityArmor = 5,
            };

            UnitArmor unitArmor2 = new UnitArmor()
            {
                Type = "Merc",
                AbilityArmor = 25,
            };

            Assert.IsFalse(unitArmor.Equals(unitArmor2));
        }
    }
}
