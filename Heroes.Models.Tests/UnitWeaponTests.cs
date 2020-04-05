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

        [TestMethod]
        public void AddWeaponAttributeFactorTests()
        {
            UnitWeapon unitWeapon = new UnitWeapon();
            WeaponAttributeFactor weaponAttributeFactor = new WeaponAttributeFactor()
            {
                Type = "type1",
                Value = 5,
            };

            unitWeapon.AttributeFactors.Add(weaponAttributeFactor);

            Assert.IsTrue(unitWeapon.AttributeFactors.Contains(weaponAttributeFactor));

            WeaponAttributeFactor weaponAttributeFactor2 = new WeaponAttributeFactor()
            {
                Type = "type1",
                Value = 7,
            };

            unitWeapon.AttributeFactors.Add(weaponAttributeFactor2);

            Assert.AreEqual(1, unitWeapon.AttributeFactors.Count);
            Assert.IsTrue(unitWeapon.AttributeFactors.Contains(weaponAttributeFactor2));
        }

        [TestMethod]
        public void AttributeFactorDoesNotExistTest()
        {
            UnitWeapon unitWeapon = new UnitWeapon();

            Assert.IsFalse(unitWeapon.AttributeFactors.Contains(new WeaponAttributeFactor()));
        }
    }
}
