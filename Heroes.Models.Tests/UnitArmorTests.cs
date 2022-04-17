using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Heroes.Models.Tests;

[TestClass]
[SuppressMessage("Maintainability", "CA1508:Avoid dead conditional code", Justification = "Test")]
public class UnitArmorTests
{
    [DataTestMethod]
    [DataRow("Hero")]
    [DataRow("Merc")]
    public void EqualsTest(string type)
    {
        UnitArmor unitArmor = new()
        {
            Type = type,
        };

        Assert.AreEqual(unitArmor, unitArmor);
    }

    [TestMethod]
    public void EqualsMethodTests()
    {
        UnitArmor unitArmor = new()
        {
            Type = "Hero",
        };

        Assert.IsFalse(unitArmor.Equals((int?)null));
        Assert.IsFalse(unitArmor.Equals(5));

        Assert.IsTrue(unitArmor.Equals(obj: unitArmor));
    }

    [DataTestMethod]
    [DataRow("Hero")]
    [DataRow("hero")]
    public void NotEqualsTest(string type)
    {
        UnitArmor unitArmor = new()
        {
            Type = "merc",
        };

        Assert.AreNotEqual(unitArmor, new UnitArmor()
        {
            Type = type,
        });
    }

    [TestMethod]
    public void NotSameObjectTest()
    {
        UnitArmor unitArmor = new()
        {
            Type = "merc",
        };

        Assert.AreNotEqual(new List<string>() { "asdf" }, unitArmor);
    }

    [DataTestMethod]
    [DataRow("hero", "hero")]
    [DataRow("hero", "Hero")]
    [DataRow("hero", "HERO")]
    [DataRow("HERO", "HERO")]
    [DataRow("HERO", "hero")]
    public void OperatorEqualTest(string type, string type2)
    {
        UnitArmor unitArmor = new()
        {
            Type = type,
        };

        UnitArmor unitArmor2 = new()
        {
            Type = type2,
        };

#pragma warning disable SA1131 // Use readable conditions
        Assert.IsFalse(null! == unitArmor2);
#pragma warning restore SA1131 // Use readable conditions
        Assert.IsFalse(unitArmor2 == null!);

        Assert.IsTrue(null! == (Announcer)null!);
        Assert.IsTrue(unitArmor == unitArmor2);

        Assert.AreEqual(unitArmor.GetHashCode(), unitArmor2!.GetHashCode());
    }

    [DataTestMethod]
    [DataRow("hero", "hero1")]
    [DataRow("hero", "merc")]
    [DataRow("hero", "")]
    public void OperatorNotEqualTest(string type, string type2)
    {
        UnitArmor unitArmor = new()
        {
            Type = type,
        };

        UnitArmor unitArmor2 = new()
        {
            Type = type2,
        };

#pragma warning disable SA1131 // Use readable conditions
        Assert.IsTrue(null! != unitArmor2);
#pragma warning restore SA1131 // Use readable conditions
        Assert.IsTrue(unitArmor2 != null!);

        Assert.IsFalse(null! != (Announcer)null!);
        Assert.IsTrue(unitArmor != unitArmor2);

        Assert.AreNotEqual(unitArmor.GetHashCode(), unitArmor2!.GetHashCode());
    }
}
