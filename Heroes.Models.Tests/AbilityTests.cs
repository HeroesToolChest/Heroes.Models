using Heroes.Models.AbilityTalents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Heroes.Models.Tests;

[TestClass]
[SuppressMessage("Maintainability", "CA1508:Avoid dead conditional code", Justification = "Test")]
public class AbilityTests
{
    [DataTestMethod]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, AbilityTiers.Basic)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, true, AbilityTiers.Heroic)]
    [DataRow("abil1", "abil1", AbilityTypes.W, true, AbilityTiers.Activable)]
    [DataRow("abil1", "Abil1", AbilityTypes.W, true, AbilityTiers.Basic)]
    [DataRow("abil1", "abilbutton", AbilityTypes.W, true, AbilityTiers.Basic)]
    public void EqualsTest(string referenceId, string buttonId, AbilityTypes abilityTypes, bool isPassive, AbilityTiers tier)
    {
        Ability ability = new()
        {
            AbilityTalentId = new AbilityTalentId(referenceId, buttonId)
            {
                AbilityType = abilityTypes,
                IsPassive = isPassive,
            },
            Tier = tier,
        };

        Assert.AreEqual(ability, ability);
    }

    [TestMethod]
    public void EqualsMethodTests()
    {
        Ability ability = new()
        {
            AbilityTalentId = new AbilityTalentId("abil1", "abilbutton")
            {
                AbilityType = AbilityTypes.W,
                IsPassive = true,
            },
            Tier = AbilityTiers.Basic,
        };

        Talent talent = new()
        {
            AbilityTalentId = new AbilityTalentId("abil1", "abilbutton")
            {
                AbilityType = AbilityTypes.W,
                IsPassive = true,
            },
            Tier = TalentTiers.Level1,
        };

        Assert.IsFalse(ability.Equals((int?)null));
        Assert.IsFalse(ability.Equals(5));

        Assert.IsTrue(ability.Equals(obj: ability));
        Assert.IsTrue(ability.Equals(ability));
        Assert.IsFalse(ability.Equals(talent));
    }

    [DataTestMethod]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false)]
    [DataRow("abil1", "abil77", AbilityTypes.Q, true)]
    [DataRow("abil1", "abil77", AbilityTypes.W, false)]
    [DataRow("abil1", "abil77", AbilityTypes.Unknown, false)]
    [DataRow("abil11", "abil77", AbilityTypes.Q, false)]
    public void NotEqualsTest(string referenceId, string buttonId, AbilityTypes abilityTypes, bool isPassive)
    {
        Ability ability = new()
        {
            AbilityTalentId = new AbilityTalentId("abil1", "abil77")
            {
                AbilityType = AbilityTypes.Q,
                IsPassive = false,
            },
        };

        Assert.AreNotEqual(ability, new Ability()
        {
            AbilityTalentId = new AbilityTalentId(referenceId, buttonId)
            {
                AbilityType = abilityTypes,
                IsPassive = isPassive,
            },
        });
    }

    [TestMethod]
    public void NotSameObjectTest()
    {
        Ability ability = new()
        {
            AbilityTalentId = new AbilityTalentId("abil1", "abil77")
            {
                AbilityType = AbilityTypes.Q,
                IsPassive = false,
            },
        };

        Talent talent = new()
        {
            AbilityTalentId = new AbilityTalentId("abil1", "abil77")
            {
                AbilityType = AbilityTypes.Q,
                IsPassive = false,
            },
            Tier = TalentTiers.Level1,
        };

        Assert.AreNotEqual(new List<string>() { "asdf" }, ability);
        Assert.AreNotEqual(talent, ability);
    }

    [DataTestMethod]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, AbilityTiers.Hearth, "abil1", "abil1", AbilityTypes.Q, false, AbilityTiers.Hearth)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, AbilityTiers.Hearth, "abil1", "Abil1", AbilityTypes.Q, false, AbilityTiers.Hearth)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, AbilityTiers.Hearth, "abil1", "abiL1", AbilityTypes.Q, false, AbilityTiers.Hearth)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, AbilityTiers.Hearth, "ABil1", "abil1", AbilityTypes.Q, false, AbilityTiers.Hearth)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, AbilityTiers.Hearth, "ABIL1", "ABIL1", AbilityTypes.Q, false, AbilityTiers.Hearth)]
    [DataRow("ABIL1", "ABIL1", AbilityTypes.Q, false, AbilityTiers.Hearth, "abil1", "abil1", AbilityTypes.Q, false, AbilityTiers.Hearth)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, AbilityTiers.Heroic, "abil1", "abil1", AbilityTypes.Q, false, AbilityTiers.Heroic)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, AbilityTiers.Basic, "abil1", "abil1", AbilityTypes.Q, false, AbilityTiers.Basic)]
    public void OperatorEqualTest(string referenceId, string buttonId, AbilityTypes abilityTypes, bool isPassive, AbilityTiers tier, string referenceId2, string buttonId2, AbilityTypes abilityTypes2, bool isPassive2, AbilityTiers tier2)
    {
        Ability ability2 = new()
        {
            AbilityTalentId = new AbilityTalentId(referenceId2, buttonId2)
            {
                AbilityType = abilityTypes2,
                IsPassive = isPassive2,
            },
            Tier = tier2,
        };

        Ability ability = new()
        {
            AbilityTalentId = new AbilityTalentId(referenceId, buttonId)
            {
                AbilityType = abilityTypes,
                IsPassive = isPassive,
            },
            Tier = tier,
        };

#pragma warning disable SA1131 // Use readable conditions
        Assert.IsFalse(null! == ability2);
#pragma warning restore SA1131 // Use readable conditions
        Assert.IsFalse(ability2 == null!);

        Assert.IsTrue(null! == (AbilityTalentId)null!);
        Assert.IsTrue(ability == ability2);

        Assert.AreEqual(ability.GetHashCode(), ability2!.GetHashCode());
    }

    [DataTestMethod]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, AbilityTiers.Hearth, "abil1", "abil1", AbilityTypes.Q, true, AbilityTiers.Hearth)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, AbilityTiers.Hearth, "abil1", "abil2", AbilityTypes.Q, false, AbilityTiers.Hearth)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, AbilityTiers.Hearth, "abil2", "abil1", AbilityTypes.Q, false, AbilityTiers.Hearth)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, AbilityTiers.Hearth, "abil1", "abil1", AbilityTypes.W, false, AbilityTiers.Hearth)]
    [DataRow("abil1", "ab1", AbilityTypes.Q, false, AbilityTiers.Hearth, "abil1", "abil1", AbilityTypes.Q, false, AbilityTiers.Hearth)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, AbilityTiers.Hearth, "abil1", "abil1", AbilityTypes.Q, false, AbilityTiers.Basic)]
    [DataRow("abil1", "abil1", AbilityTypes.Q, false, AbilityTiers.Hearth, "abil1", "abil1", AbilityTypes.Q, false, AbilityTiers.Heroic)]
    public void OperatorNotEqualTest(string referenceId, string buttonId, AbilityTypes abilityTypes, bool isPassive, AbilityTiers tier, string referenceId2, string buttonId2, AbilityTypes abilityTypes2, bool isPassive2, AbilityTiers tier2)
    {
        Ability ability2 = new()
        {
            AbilityTalentId = new AbilityTalentId(referenceId2, buttonId2)
            {
                AbilityType = abilityTypes2,
                IsPassive = isPassive2,
            },
            Tier = tier2,
        };

        Ability ability = new()
        {
            AbilityTalentId = new AbilityTalentId(referenceId, buttonId)
            {
                AbilityType = abilityTypes,
                IsPassive = isPassive,
            },
            Tier = tier,
        };

        Talent talent = new()
        {
            AbilityTalentId = new AbilityTalentId(referenceId, buttonId)
            {
                AbilityType = abilityTypes,
                IsPassive = isPassive,
            },
            Tier = TalentTiers.Level1,
        };

#pragma warning disable SA1131 // Use readable conditions
        Assert.IsTrue(null! != ability2);
#pragma warning restore SA1131 // Use readable conditions
        Assert.IsTrue(ability2 != null!);

        Assert.IsFalse(null! != (AbilityTalentId)null!);
        Assert.IsTrue(ability != ability2);

        Assert.AreNotEqual(ability.GetHashCode(), ability2!.GetHashCode());
        Assert.AreNotEqual(talent.GetHashCode(), ability2!.GetHashCode());
    }

    [TestMethod]
    public void AbilityAddedSuccesfullyToHashSetTest()
    {
        Ability ability1 = new()
        {
            AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
            {
                AbilityType = AbilityTypes.Active,
            },
            IconFileName = "test.png",
        };

        Ability ability2 = new()
        {
            AbilityTalentId = new AbilityTalentId("AbilitY1", "abil1")
            {
                AbilityType = AbilityTypes.Heroic,
            },
            IconFileName = "test.png",
        };

        HashSet<Ability> abilities = new();
        Assert.IsTrue(abilities.Add(ability1));
        Assert.IsTrue(abilities.Add(ability2));
    }

    [TestMethod]
    public void AbilityAddedFailedToHashSetTest()
    {
        Ability ability1 = new()
        {
            AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
            {
                AbilityType = AbilityTypes.Active,
            },
            IconFileName = "test.png",
        };

        Ability ability2 = new()
        {
            AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
            {
                AbilityType = AbilityTypes.Active,
            },
            IconFileName = "test.png",
        };

        HashSet<Ability> abilities = new();
        Assert.IsTrue(abilities.Add(ability1));
        Assert.IsFalse(abilities.Add(ability2));
    }

    [TestMethod]
    public void GetAbilitiesCountTest()
    {
        Ability ability1 = new()
        {
            AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
            {
                AbilityType = AbilityTypes.Active,
            },
            IconFileName = "test.png",
        };

        Ability ability2 = new()
        {
            AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
            {
                AbilityType = AbilityTypes.Heroic,
            },
            IconFileName = "test.png",
        };

        Ability ability3 = new()
        {
            AbilityTalentId = new AbilityTalentId("Ability2", "abil2")
            {
                AbilityType = AbilityTypes.Heroic,
            },
            IconFileName = "test.png",
        };

        Unit unit = new();
        unit.AddAbility(ability1);
        unit.AddAbility(ability2);
        unit.AddAbility(ability3);

        Assert.AreEqual(3, unit.AbilitiesCount);
    }

    [TestMethod]
    public void ContainsAbilityTest()
    {
        Ability ability1 = new()
        {
            AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
            {
                AbilityType = AbilityTypes.Active,
            },
            IconFileName = "test.png",
        };

        Ability ability2 = new()
        {
            AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
            {
                AbilityType = AbilityTypes.Heroic,
            },
            IconFileName = "test.png",
        };

        Ability ability3 = new()
        {
            AbilityTalentId = new AbilityTalentId("Ability2", "abil2")
            {
                AbilityType = AbilityTypes.Heroic,
            },
            IconFileName = "test.png",
        };

        Unit unit = new();
        unit.AddAbility(ability1);
        unit.AddAbility(ability2);
        unit.AddAbility(ability3);

        Assert.IsTrue(unit.ContainsAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
            {
                AbilityType = AbilityTypes.Heroic,
            },
            IconFileName = "test.png",
        }));
        Assert.IsFalse(unit.ContainsAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
            {
                AbilityType = AbilityTypes.Hidden,
            },
            IconFileName = "test.png",
        }));
        Assert.IsFalse(unit.ContainsAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId("Ability4", "abil4")
            {
                AbilityType = AbilityTypes.Hidden,
            },
            IconFileName = "test.png",
        }));

        Assert.IsTrue(unit.ContainsAbility("Ability1", StringComparison.OrdinalIgnoreCase));

        Assert.IsTrue(unit.ContainsAbility(new AbilityTalentId("Ability1", "abil1")
        {
            AbilityType = AbilityTypes.Heroic,
        }));
        Assert.IsFalse(unit.ContainsAbility(new AbilityTalentId("Ability1", "abil1")));
        Assert.IsFalse(unit.ContainsAbility(new AbilityTalentId("Ability5", string.Empty)));
    }

    [TestMethod]
    public void RemoveAbilityTest()
    {
        Ability ability1 = new()
        {
            AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
            {
                AbilityType = AbilityTypes.Active,
            },
            IconFileName = "test.png",
        };

        Ability ability2 = new()
        {
            AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
            {
                AbilityType = AbilityTypes.Heroic,
            },
            IconFileName = "test.png",
        };

        Ability ability3 = new()
        {
            AbilityTalentId = new AbilityTalentId("Ability2", "abil2")
            {
                AbilityType = AbilityTypes.Heroic,
            },
        };

        Unit unit = new();
        unit.AddAbility(ability1);
        unit.AddAbility(ability2);
        unit.AddAbility(ability3);

        Assert.AreEqual(3, unit.AbilitiesCount);

        Assert.IsTrue(unit.RemoveAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
            {
                AbilityType = AbilityTypes.Active,
            },
            IconFileName = "test.png",
        }));

        // try to remove again
        Assert.IsFalse(unit.RemoveAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
            {
                AbilityType = AbilityTypes.Active,
            },
            IconFileName = "test.png",
        }));

        Assert.IsFalse(unit.RemoveAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId("Ability3", "abil3")
            {
                AbilityType = AbilityTypes.Heroic,
            },
            IconFileName = "test.png",
        }));

        Assert.AreEqual(2, unit.AbilitiesCount);

        // remove 1
        Assert.IsTrue(unit.RemoveAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
            {
                AbilityType = AbilityTypes.Heroic,
            },
            IconFileName = "test.png",
        }));

        Assert.AreEqual(1, unit.AbilitiesCount);
    }

    [TestMethod]
    public void AddPassiveAbilityTest()
    {
        Unit unit = new();
        unit.AddAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId(string.Empty, "pass1")
            {
                AbilityType = AbilityTypes.Passive,
                IsPassive = true,
            },
        });
        unit.AddAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId(string.Empty, "pass1")
            {
                AbilityType = AbilityTypes.Passive,
                IsPassive = true,
            },
        });
    }

    [TestMethod]
    public void ContainsPassiveAbilityTest()
    {
        Unit unit = new();
        unit.AddAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId(string.Empty, "pass1")
            {
                AbilityType = AbilityTypes.Passive,
                IsPassive = true,
            },
        });
        unit.AddAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId(string.Empty, "pass2")
            {
                AbilityType = AbilityTypes.Passive,
                IsPassive = true,
            },
        });

        Assert.IsTrue(unit.ContainsAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId(string.Empty, "pass2")
            {
                AbilityType = AbilityTypes.Passive,
                IsPassive = true,
            },
        }));

        Assert.IsFalse(unit.ContainsAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId(string.Empty, "pass3")
            {
                AbilityType = AbilityTypes.Passive,
                IsPassive = true,
            },
        }));

        Assert.IsFalse(unit.ContainsAbility(new AbilityTalentId(string.Empty, "asdf")));
        Assert.IsFalse(unit.ContainsAbility(new AbilityTalentId(string.Empty, "pass2")));
        Assert.IsTrue(unit.ContainsAbility(new AbilityTalentId(string.Empty, "pass2")
        {
            AbilityType = AbilityTypes.Passive,
            IsPassive = true,
        }));
    }

    [TestMethod]
    public void RemovePassiveAbilityTest()
    {
        Unit unit = new();
        unit.AddAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId(string.Empty, "pass1")
            {
                AbilityType = AbilityTypes.Passive,
                IsPassive = true,
            },
        });
        unit.AddAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId(string.Empty, "pass2")
            {
                AbilityType = AbilityTypes.Passive,
                IsPassive = true,
            },
        });

        Assert.IsTrue(unit.RemoveAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId(string.Empty, "pass1")
            {
                AbilityType = AbilityTypes.Passive,
                IsPassive = true,
            },
        }));
    }

    [TestMethod]
    public void GetAbilityTests()
    {
        Unit unit = new();
        unit.AddAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId(string.Empty, "pass1")
            {
                AbilityType = AbilityTypes.Passive,
                IsPassive = true,
            },
        });
        unit.AddAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId(string.Empty, "pass2")
            {
                AbilityType = AbilityTypes.Passive,
                IsPassive = true,
            },
        });

        Ability ability = unit.GetAbility(new AbilityTalentId(string.Empty, "pass1")
        {
            AbilityType = AbilityTypes.Passive,
            IsPassive = true,
        });

        Assert.AreEqual("pass1", ability.AbilityTalentId.ButtonId);

        Assert.ThrowsException<KeyNotFoundException>(() =>
        {
            unit.GetAbility(new AbilityTalentId("test", "test"));
        });

        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            unit.GetAbility(null!);
        });
    }

    [TestMethod]
    public void TryGetAbilityTests()
    {
        Unit unit = new();
        unit.AddAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId(string.Empty, "pass1")
            {
                AbilityType = AbilityTypes.Passive,
                IsPassive = true,
            },
        });
        unit.AddAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId(string.Empty, "pass2")
            {
                AbilityType = AbilityTypes.Passive,
                IsPassive = true,
            },
        });

        Assert.IsTrue(unit.TryGetAbility(
            new AbilityTalentId(string.Empty, "pass1")
            {
                AbilityType = AbilityTypes.Passive,
                IsPassive = true,
            },
            out Ability? ability));

        Assert.AreEqual("pass1", ability?.AbilityTalentId.ButtonId);

        Assert.IsFalse(unit.TryGetAbility(new AbilityTalentId(string.Empty, string.Empty), out Ability? _));

        Assert.ThrowsException<ArgumentNullException>(() =>
        {
            unit.TryGetAbility(null!, out Ability? _);
        });
    }

    [TestMethod]
    public void GetAbilitiesTests()
    {
        Unit unit = new();
        unit.AddAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId("hello", "pass1")
            {
                AbilityType = AbilityTypes.Passive,
                IsPassive = true,
            },
        });
        unit.AddAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId("hello", "pass2")
            {
                AbilityType = AbilityTypes.Passive,
                IsPassive = true,
            },
        });

        List<Ability> list = unit.GetAbilitiesFromReferenceId("hello", StringComparison.OrdinalIgnoreCase).ToList();
        Assert.AreEqual(2, list.Count);

        Assert.AreEqual(0, unit.GetAbilitiesFromReferenceId("empty", StringComparison.OrdinalIgnoreCase).ToList().Count);

        Assert.ThrowsException<ArgumentException>(() =>
        {
            unit.GetAbilitiesFromReferenceId(null!, StringComparison.OrdinalIgnoreCase);
        });
    }
}
