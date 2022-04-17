namespace Heroes.Models.Tests;

[TestClass]
[SuppressMessage("Maintainability", "CA1508:Avoid dead conditional code", Justification = "Test")]
public class AbilityTalentIdTests
{
    [TestMethod]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, true)]
    [DataRow("abil1", "abil1", AbilityTypes.W, true)]
    [DataRow("abil1", "Abil1", AbilityTypes.W, true)]
    [DataRow("abil1", "abilbutton", AbilityTypes.W, true)]
    public void EqualsTest(string referenceId, string buttonId, AbilityTypes abilityTypes, bool isPassive)
    {
        AbilityTalentId abilityTalentId = new(referenceId, buttonId)
        {
            AbilityType = abilityTypes,
            IsPassive = isPassive,
        };

        Assert.AreEqual(abilityTalentId, abilityTalentId);
    }

    [TestMethod]
    public void EqualsMethodTests()
    {
        AbilityTalentId abilityTalentId = new("abil1", "abilbutton")
        {
            AbilityType = AbilityTypes.W,
            IsPassive = true,
        };

        Assert.IsFalse(abilityTalentId.Equals((int?)null));
        Assert.IsFalse(abilityTalentId.Equals(5));

        Assert.IsTrue(abilityTalentId.Equals(obj: abilityTalentId));
    }

    [TestMethod]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false)]
    [DataRow("abil1", "abil77", AbilityTypes.Q, true)]
    [DataRow("abil1", "abil77", AbilityTypes.W, false)]
    [DataRow("abil1", "abil77", AbilityTypes.Unknown, false)]
    [DataRow("abil11", "abil77", AbilityTypes.Q, false)]
    public void NotEqualsTest(string referenceId, string buttonId, AbilityTypes abilityTypes, bool isPassive)
    {
        AbilityTalentId abilityTalentId = new("abil1", "abil77")
        {
            AbilityType = AbilityTypes.Q,
            IsPassive = false,
        };

        Assert.AreNotEqual(abilityTalentId, new(referenceId, buttonId)
        {
            AbilityType = abilityTypes,
            IsPassive = isPassive,
        });
    }

    [TestMethod]
    public void NotSameObjectTest()
    {
        AbilityTalentId abilityTalentId = new("abil1", "abil77")
        {
            AbilityType = AbilityTypes.Q,
            IsPassive = false,
        };

        Assert.AreNotEqual(new List<string>() { "asdf" }, abilityTalentId);
    }

    [TestMethod]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, "abil1", "abil1", AbilityTypes.Q, false)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, "abil1", "Abil1", AbilityTypes.Q, false)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, "abil1", "abiL1", AbilityTypes.Q, false)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, "ABil1", "abil1", AbilityTypes.Q, false)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, "ABIL1", "ABIL1", AbilityTypes.Q, false)]
    [DataRow("ABIL1", "ABIL1", AbilityTypes.Q, false, "abil1", "abil1", AbilityTypes.Q, false)]
    public void OperatorEqualTest(string referenceId, string buttonId, AbilityTypes abilityTypes, bool isPassive, string referenceId2, string buttonId2, AbilityTypes abilityTypes2, bool isPassive2)
    {
        AbilityTalentId abilityTalentId2 = new(referenceId2, buttonId2)
        {
            AbilityType = abilityTypes2,
            IsPassive = isPassive2,
        };

        AbilityTalentId abilityTalentId = new(referenceId, buttonId)
        {
            AbilityType = abilityTypes,
            IsPassive = isPassive,
        };

#pragma warning disable SA1131 // Use readable conditions
        Assert.IsFalse(null! == abilityTalentId2);
#pragma warning restore SA1131 // Use readable conditions
        Assert.IsFalse(abilityTalentId2 == null!);

        Assert.IsTrue(null! == (AbilityTalentId)null!);
        Assert.IsTrue(abilityTalentId == abilityTalentId2);

        Assert.AreEqual(abilityTalentId.GetHashCode(), abilityTalentId2!.GetHashCode());
    }

    [TestMethod]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, "abil1", "abil1", AbilityTypes.Q, true)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, "abil1", "abil2", AbilityTypes.Q, false)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, "abil2", "abil1", AbilityTypes.Q, false)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, "abil1", "abil1", AbilityTypes.W, false)]
    [DataRow("abil1", "ab1", AbilityTypes.Q, false, "abil1", "abil1", AbilityTypes.Q, false)]
    public void OperatorNotEqualTest(string referenceId, string buttonId, AbilityTypes abilityTypes, bool isPassive, string referenceId2, string buttonId2, AbilityTypes abilityTypes2, bool isPassive2)
    {
        AbilityTalentId abilityTalentId2 = new(referenceId2, buttonId2)
        {
            AbilityType = abilityTypes2,
            IsPassive = isPassive2,
        };

        AbilityTalentId abilityTalentId = new(referenceId, buttonId)
        {
            AbilityType = abilityTypes,
            IsPassive = isPassive,
        };

#pragma warning disable SA1131 // Use readable conditions
        Assert.IsTrue(null! != abilityTalentId2);
#pragma warning restore SA1131 // Use readable conditions
        Assert.IsTrue(abilityTalentId2 != null!);

        Assert.IsFalse(null! != (AbilityTalentId)null!);
        Assert.IsTrue(abilityTalentId != abilityTalentId2);

        Assert.AreNotEqual(abilityTalentId.GetHashCode(), abilityTalentId2!.GetHashCode());
    }
}
