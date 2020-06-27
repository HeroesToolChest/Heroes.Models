using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Heroes.Models.Tests
{
    [TestClass]
    public class WeaponAttributeFactorTests
    {
        [DataTestMethod]
        [DataRow("type1", 5.0)]
        [DataRow("type2", 1.0)]
        public void EqualsTest(string type, double value)
        {
            WeaponAttributeFactor weaponAttributeFactor = new WeaponAttributeFactor()
            {
                Type = type,
                Value = value,
            };

            Assert.AreEqual(weaponAttributeFactor, weaponAttributeFactor);
        }

        [TestMethod]
        public void EqualsMethodTests()
        {
            WeaponAttributeFactor weaponAttributeFactor = new WeaponAttributeFactor()
            {
                Type = "type1",
                Value = 12.0,
            };

            Assert.IsFalse(weaponAttributeFactor.Equals((int?)null));
            Assert.IsFalse(weaponAttributeFactor.Equals(5));

            Assert.IsTrue(weaponAttributeFactor.Equals(obj: weaponAttributeFactor));
        }

        [DataTestMethod]
        [DataRow("type1", 5.0)]
        [DataRow("type2", 1.0)]
        public void NotEqualsTest(string type, double value)
        {
            WeaponAttributeFactor weaponAttributeFactor = new WeaponAttributeFactor()
            {
                Type = "type1333",
                Value = 12.0,
            };

            Assert.AreNotEqual(weaponAttributeFactor, new WeaponAttributeFactor()
            {
                Type = type,
                Value = value,
            });
        }

        [TestMethod]
        public void NotSameObjectTest()
        {
            WeaponAttributeFactor weaponAttributeFactor = new WeaponAttributeFactor()
            {
                Type = "type1333",
                Value = 12.0,
            };

            Assert.AreNotEqual(new List<string>() { "asdf" }, weaponAttributeFactor);
        }

        [DataTestMethod]
        [DataRow("type", 5.0, "type", 5.0)]
        [DataRow("type", 5.0, "type", 10.0)]
        [DataRow("type", 5.0, "Type", 6.0)]
        [DataRow("type", 7.0, "TYPE", 5.0)]
        [DataRow("TYPE", 5.0, "type", 6.0)]
        [DataRow("TYPE", -1.0, "TYPE", 5.0)]
        public void OperatorEqualTest(string type, double value, string type2, double value2)
        {
            WeaponAttributeFactor weaponAttributeFactor = new WeaponAttributeFactor()
            {
                Type = type,
                Value = value,
            };

            WeaponAttributeFactor weaponAttributeFactor2 = new WeaponAttributeFactor()
            {
                Type = type2,
                Value = value2,
            };

#pragma warning disable SA1131 // Use readable conditions
            Assert.IsFalse(null! == weaponAttributeFactor2);
#pragma warning restore SA1131 // Use readable conditions
            Assert.IsFalse(weaponAttributeFactor2 == null!);

            Assert.IsTrue(null! == (Announcer)null!);
            Assert.IsTrue(weaponAttributeFactor == weaponAttributeFactor2);

            Assert.AreEqual(weaponAttributeFactor.GetHashCode(), weaponAttributeFactor2!.GetHashCode());
        }

        [DataTestMethod]
        [DataRow("type", 5.0, "type1", 5.0)]
        [DataRow("type", 5.0, "Type1", 6.0)]
        [DataRow("type", 7.0, "TYPE1", 5.0)]
        [DataRow("TYPE", 5.0, "type1", 6.0)]
        [DataRow("TYPE", -1.0, "TYPE1", 5.0)]
        public void OperatorNotEqualTest(string type, double value, string type2, double value2)
        {
            WeaponAttributeFactor weaponAttributeFactor = new WeaponAttributeFactor()
            {
                Type = type,
                Value = value,
            };

            WeaponAttributeFactor weaponAttributeFactor2 = new WeaponAttributeFactor()
            {
                Type = type2,
                Value = value2,
            };

#pragma warning disable SA1131 // Use readable conditions
            Assert.IsTrue(null! != weaponAttributeFactor2);
#pragma warning restore SA1131 // Use readable conditions
            Assert.IsTrue(weaponAttributeFactor2 != null!);

            Assert.IsFalse(null! != (Announcer)null!);
            Assert.IsTrue(weaponAttributeFactor != weaponAttributeFactor2);

            Assert.AreNotEqual(weaponAttributeFactor.GetHashCode(), weaponAttributeFactor2!.GetHashCode());
        }
    }
}
