using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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

            unitWeapon.AddAttributeFactor(weaponAttributeFactor);

            Assert.IsTrue(unitWeapon.AttributeFactorExists(weaponAttributeFactor));

            WeaponAttributeFactor weaponAttributeFactor2 = new WeaponAttributeFactor()
            {
                Type = "type1",
                Value = 7,
            };

            unitWeapon.AddAttributeFactor(weaponAttributeFactor2);

            Assert.AreEqual(1, unitWeapon.AttributeFactors.Count());
            Assert.AreEqual(7, unitWeapon.AttributeFactors.ToList()[0].Value);
        }

        [TestMethod]
        public void AttributeFactorDoesNotExistTest()
        {
            UnitWeapon unitWeapon = new UnitWeapon();

            Assert.IsFalse(unitWeapon.AttributeFactorExists(new WeaponAttributeFactor()));
        }
    }
}
