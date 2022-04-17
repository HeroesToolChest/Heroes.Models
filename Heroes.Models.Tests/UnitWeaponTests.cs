namespace Heroes.Models.Tests;

[TestClass]
[SuppressMessage("Maintainability", "CA1508:Avoid dead conditional code", Justification = "Test")]
public class UnitWeaponTests
{
    [TestMethod]
    [DataRow("weaponId1")]
    [DataRow("weaponId2")]
    public void EqualsTest(string id)
    {
        UnitWeapon unitWeapon = new()
        {
            WeaponNameId = id,
        };

        Assert.AreEqual(unitWeapon, unitWeapon);
    }

    [TestMethod]
    public void EqualsMethodTests()
    {
        UnitWeapon unitWeapon = new()
        {
            WeaponNameId = "weaponId1",
        };

        Assert.IsFalse(unitWeapon.Equals((int?)null));
        Assert.IsFalse(unitWeapon.Equals(5));

        Assert.IsTrue(unitWeapon.Equals(obj: unitWeapon));
    }

    [TestMethod]
    [DataRow("weaponId1")]
    [DataRow("weaponId2")]
    public void NotEqualsTest(string id)
    {
        UnitWeapon unitWeapon = new()
        {
            WeaponNameId = "abc",
        };

        Assert.AreNotEqual(unitWeapon, new UnitWeapon()
        {
            WeaponNameId = id,
        });
    }

    [TestMethod]
    public void NotSameObjectTest()
    {
        UnitWeapon unitWeapon = new()
        {
            WeaponNameId = "abc",
        };

        Assert.AreNotEqual(new List<string>() { "asdf" }, unitWeapon);
    }

    [TestMethod]
    [DataRow("weaponId1", "weaponId1")]
    [DataRow("weaponId1", "WeaponId1")]
    [DataRow("weaponId1", "WEAPONID1")]
    [DataRow("WEAPONID1", "weaponId1")]
    [DataRow("WEAPONID1", "WEAPONID1")]
    public void OperatorEqualTest(string id, string id2)
    {
        UnitWeapon unitWeapon = new()
        {
            WeaponNameId = id,
        };

        UnitWeapon unitWeapon2 = new()
        {
            WeaponNameId = id2,
        };

#pragma warning disable SA1131 // Use readable conditions
        Assert.IsFalse(null! == unitWeapon2);
#pragma warning restore SA1131 // Use readable conditions
        Assert.IsFalse(unitWeapon2 == null!);

        Assert.IsTrue(null! == (Announcer)null!);
        Assert.IsTrue(unitWeapon == unitWeapon2);

        Assert.AreEqual(unitWeapon.GetHashCode(), unitWeapon2!.GetHashCode());
    }

    [TestMethod]
    [DataRow("weaponId1", "weaponId11")]
    [DataRow("weaponId1", "WeaponId11")]
    [DataRow("weaponId1", "WEAPONID11")]
    [DataRow("WEAPONID1", "weaponId11")]
    [DataRow("WEAPONID1", "WEAPONID11")]
    public void OperatorNotEqualTest(string id, string id2)
    {
        UnitWeapon unitWeapon = new()
        {
            WeaponNameId = id,
        };

        UnitWeapon unitWeapon2 = new()
        {
            WeaponNameId = id2,
        };

#pragma warning disable SA1131 // Use readable conditions
        Assert.IsTrue(null! != unitWeapon2);
#pragma warning restore SA1131 // Use readable conditions
        Assert.IsTrue(unitWeapon2 != null!);

        Assert.IsFalse(null! != (Announcer)null!);
        Assert.IsTrue(unitWeapon != unitWeapon2);

        Assert.AreNotEqual(unitWeapon.GetHashCode(), unitWeapon2!.GetHashCode());
    }

    [TestMethod]
    [DataRow(4, 0.25)]
    [DataRow(0, 0)]
    [DataRow(-1, 0)]
    public void GetWeponAttackSpeedTests(double period, double attackPerSecond)
    {
        UnitWeapon weapon = new()
        {
            Period = period,
        };

        Assert.AreEqual(attackPerSecond, weapon.AttacksPerSecond);
    }

    [TestMethod]
    public void AddWeaponAttributeFactorTests()
    {
        UnitWeapon unitWeapon = new();
        WeaponAttributeFactor weaponAttributeFactor = new()
        {
            Type = "type1",
            Value = 5,
        };

        unitWeapon.AttributeFactors.Add(weaponAttributeFactor);

        Assert.IsTrue(unitWeapon.AttributeFactors.Contains(weaponAttributeFactor));

        WeaponAttributeFactor weaponAttributeFactor2 = new()
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
        UnitWeapon unitWeapon = new();

        Assert.IsFalse(unitWeapon.AttributeFactors.Contains(new WeaponAttributeFactor()));
    }
}
