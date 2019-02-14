using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Heroes.Models.Tests
{
    [TestClass]
    public class UnitWeaponTests
    {
        public UnitWeaponTests()
        {
        }

        [TestMethod]
        public void GetWeponAttackSpeedTests()
        {
            UnitWeapon weapon = new UnitWeapon()
            {
                Period = 4,
            };

            Assert.AreEqual(0.25, weapon.GetAttacksPerSecond());

            weapon.Period = 0;

            Assert.AreEqual(0, weapon.GetAttacksPerSecond());
        }
    }
}
