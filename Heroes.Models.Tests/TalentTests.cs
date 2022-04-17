using Heroes.Models.AbilityTalents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Heroes.Models.Tests;

[TestClass]
[SuppressMessage("Maintainability", "CA1508:Avoid dead conditional code", Justification = "Test")]
public class TalentTests
{
    [DataTestMethod]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level1)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, true, TalentTiers.Level4)]
    [DataRow("abil1", "abil1", AbilityTypes.W, true, TalentTiers.Level7)]
    [DataRow("abil1", "Abil1", AbilityTypes.W, true, TalentTiers.Level10)]
    [DataRow("abil1", "abilbutton", AbilityTypes.W, true, TalentTiers.Level13)]
    public void EqualsTest(string referenceId, string buttonId, AbilityTypes abilityTypes, bool isPassive, TalentTiers tier)
    {
        Talent talent = new Talent()
        {
            AbilityTalentId = new AbilityTalentId(referenceId, buttonId)
            {
                AbilityType = abilityTypes,
                IsPassive = isPassive,
            },
            Tier = tier,
        };

        Assert.AreEqual(talent, talent);
    }

    [TestMethod]
    public void EqualsMethodTests()
    {
        Ability ability = new Ability()
        {
            AbilityTalentId = new AbilityTalentId("abil1", "abilbutton")
            {
                AbilityType = AbilityTypes.W,
                IsPassive = true,
            },
            Tier = AbilityTiers.Basic,
        };

        Talent talent = new Talent()
        {
            AbilityTalentId = new AbilityTalentId("abil1", "abilbutton")
            {
                AbilityType = AbilityTypes.W,
                IsPassive = true,
            },
            Tier = TalentTiers.Level1,
        };

        Assert.IsFalse(talent.Equals((int?)null));
        Assert.IsFalse(talent.Equals(5));

        Assert.IsTrue(talent.Equals(obj: talent));
        Assert.IsTrue(talent.Equals(talent));
        Assert.IsFalse(talent.Equals(ability));
    }

    [DataTestMethod]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level7)]
    [DataRow("abil1", "abil77", AbilityTypes.Q, true, TalentTiers.Level10)]
    [DataRow("abil1", "abil77", AbilityTypes.W, false, TalentTiers.Level13)]
    [DataRow("abil1", "abil77", AbilityTypes.Unknown, false, TalentTiers.Level16)]
    [DataRow("abil11", "abil77", AbilityTypes.Q, false, TalentTiers.Level20)]
    public void NotEqualsTest(string referenceId, string buttonId, AbilityTypes abilityTypes, bool isPassive, TalentTiers tier)
    {
        Talent talent = new Talent()
        {
            AbilityTalentId = new AbilityTalentId("abil1", "abil77")
            {
                AbilityType = AbilityTypes.Q,
                IsPassive = false,
            },
            Tier = tier,
        };

        Assert.AreNotEqual(talent, new Talent()
        {
            AbilityTalentId = new AbilityTalentId(referenceId, buttonId)
            {
                AbilityType = abilityTypes,
                IsPassive = isPassive,
            },
            Tier = tier,
        });
    }

    [TestMethod]
    public void NotSameObjectTest()
    {
        Ability ability = new Ability()
        {
            AbilityTalentId = new AbilityTalentId("abil1", "abil77")
            {
                AbilityType = AbilityTypes.Q,
                IsPassive = false,
            },
        };

        Talent talent = new Talent()
        {
            AbilityTalentId = new AbilityTalentId("abil1", "abil77")
            {
                AbilityType = AbilityTypes.Q,
                IsPassive = false,
            },
            Tier = TalentTiers.Level1,
        };

        Assert.AreNotEqual(new List<string>() { "asdf" }, talent);
        Assert.AreNotEqual(ability, talent);
    }

    [DataTestMethod]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level1, "abil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level1)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level1, "abil1", "Abil1", AbilityTypes.Q, false, TalentTiers.Level1)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level1, "abil1", "abiL1", AbilityTypes.Q, false, TalentTiers.Level1)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level1, "ABil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level1)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level1, "ABIL1", "ABIL1", AbilityTypes.Q, false, TalentTiers.Level1)]
    [DataRow("ABIL1", "ABIL1", AbilityTypes.Q, false, TalentTiers.Level1, "abil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level1)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level10, "abil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level10)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level20, "abil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level20)]
    public void OperatorEqualTest(string referenceId, string buttonId, AbilityTypes abilityTypes, bool isPassive, TalentTiers tier, string referenceId2, string buttonId2, AbilityTypes abilityTypes2, bool isPassive2, TalentTiers tier2)
    {
        Talent talent2 = new Talent()
        {
            AbilityTalentId = new AbilityTalentId(referenceId2, buttonId2)
            {
                AbilityType = abilityTypes2,
                IsPassive = isPassive2,
            },
            Tier = tier2,
        };

        Talent talent = new Talent()
        {
            AbilityTalentId = new AbilityTalentId(referenceId, buttonId)
            {
                AbilityType = abilityTypes,
                IsPassive = isPassive,
            },
            Tier = tier,
        };

#pragma warning disable SA1131 // Use readable conditions
        Assert.IsFalse(null! == talent2);
#pragma warning restore SA1131 // Use readable conditions
        Assert.IsFalse(talent2 == null!);

        Assert.IsTrue(null! == (AbilityTalentId)null!);
        Assert.IsTrue(talent == talent2);

        Assert.AreEqual(talent.GetHashCode(), talent2!.GetHashCode());
    }

    [DataTestMethod]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level1, "abil1", "abil1", AbilityTypes.Q, true, TalentTiers.Level1)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level1, "abil1", "abil2", AbilityTypes.Q, false, TalentTiers.Level1)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level1, "abil2", "abil1", AbilityTypes.Q, false, TalentTiers.Level1)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level1, "abil1", "abil1", AbilityTypes.W, false, TalentTiers.Level1)]
    [DataRow("abil1", "ab1", AbilityTypes.Q, false, TalentTiers.Level1, "abil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level1)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level1, "abil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level4)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level1, "abil1", "abil1", AbilityTypes.Q, false, TalentTiers.Level7)]
    public void OperatorNotEqualTest(string referenceId, string buttonId, AbilityTypes abilityTypes, bool isPassive, TalentTiers tier, string referenceId2, string buttonId2, AbilityTypes abilityTypes2, bool isPassive2, TalentTiers tier2)
    {
        Talent talent2 = new Talent()
        {
            AbilityTalentId = new AbilityTalentId(referenceId2, buttonId2)
            {
                AbilityType = abilityTypes2,
                IsPassive = isPassive2,
            },
            Tier = tier2,
        };

        Talent talent = new Talent()
        {
            AbilityTalentId = new AbilityTalentId(referenceId, buttonId)
            {
                AbilityType = abilityTypes,
                IsPassive = isPassive,
            },
            Tier = tier,
        };

        Ability ability = new Ability()
        {
            AbilityTalentId = new AbilityTalentId(referenceId, buttonId)
            {
                AbilityType = abilityTypes,
                IsPassive = isPassive,
            },
            Tier = AbilityTiers.Hearth,
        };

#pragma warning disable SA1131 // Use readable conditions
        Assert.IsTrue(null! != talent2);
#pragma warning restore SA1131 // Use readable conditions
        Assert.IsTrue(talent2 != null!);

        Assert.IsFalse(null! != (AbilityTalentId)null!);
        Assert.IsTrue(talent != talent2);

        Assert.AreNotEqual(talent.GetHashCode(), talent2!.GetHashCode());
        Assert.AreNotEqual(ability.GetHashCode(), talent2!.GetHashCode());
    }
}
