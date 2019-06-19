using Heroes.Models.AbilityTalents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Models.Tests
{
    [TestClass]
    public class AbilityTests
    {
        [TestMethod]
        public void AbilitiesAreEqualTest()
        {
            Ability ability1 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1"),
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
            };

            Ability ability2 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1"),
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
            };

            Assert.AreEqual(ability1, ability2);
        }

        [TestMethod]
        public void AbilitiesAreNotEqualTest()
        {
            Ability ability1 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1"),
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
            };

            Ability ability2 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "Ability"),
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
            };

            Assert.AreNotEqual(ability1, ability2);
        }

        [TestMethod]
        public void AbilityAddedSuccesfullyToHashSetTest()
        {
            Ability ability1 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1"),
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
            };

            Ability ability2 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("AbilitY1", "abil1"),
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
            };

            HashSet<Ability> abilities = new HashSet<Ability>();
            Assert.IsTrue(abilities.Add(ability1));
            Assert.IsTrue(abilities.Add(ability2));
        }

        [TestMethod]
        public void AbilityAddedFailedToHashSetTest()
        {
            Ability ability1 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1"),
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
            };

            Ability ability2 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1"),
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
            };

            HashSet<Ability> abilities = new HashSet<Ability>();
            Assert.IsTrue(abilities.Add(ability1));
            Assert.IsFalse(abilities.Add(ability2));
        }

        [TestMethod]
        public void GetAbilitiesCountTest()
        {
            Ability ability1 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1"),
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
            };

            Ability ability2 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1"),
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
            };

            Ability ability3 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability2", "abil2"),
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
            };

            Unit unit = new Unit();
            unit.AddAbility(ability1);
            unit.AddAbility(ability2);
            unit.AddAbility(ability3);

            Assert.AreEqual(3, unit.AbilitiesCount);
        }

        [TestMethod]
        public void ContainsAbilityTest()
        {
            Ability ability1 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1"),
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
            };

            Ability ability2 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1"),
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
            };

            Ability ability3 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability2", "abil2"),
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
            };

            Unit unit = new Unit();
            unit.AddAbility(ability1);
            unit.AddAbility(ability2);
            unit.AddAbility(ability3);

            Assert.IsTrue(unit.ContainsAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1"),
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
            }));
            Assert.IsFalse(unit.ContainsAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1"),
                AbilityType = AbilityType.Hidden,
                IconFileName = "test.png",
            }));
            Assert.IsFalse(unit.ContainsAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability4", "abil4"),
                AbilityType = AbilityType.Hidden,
                IconFileName = "test.png",
            }));

            Assert.IsTrue(unit.ContainsAbility(new AbilityTalentId("Ability1", "abil1")));
            Assert.IsFalse(unit.ContainsAbility(new AbilityTalentId("Ability5", string.Empty)));
        }

        [TestMethod]
        public void RemoveAbilityTest()
        {
            Ability ability1 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1"),
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
            };

            Ability ability2 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1"),
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
            };

            Ability ability3 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability2", "abil2"),
                AbilityType = AbilityType.Heroic,
            };

            Unit unit = new Unit();
            unit.AddAbility(ability1);
            unit.AddAbility(ability2);
            unit.AddAbility(ability3);

            Assert.AreEqual(3, unit.AbilitiesCount);

            Assert.IsTrue(unit.RemoveAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1"),
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
            }));

            // try to remove again
            Assert.IsFalse(unit.RemoveAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1"),
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
            }));

            Assert.IsFalse(unit.RemoveAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability3", "abil3"),
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
            }));

            Assert.AreEqual(2, unit.AbilitiesCount);

            // remove 1
            Assert.IsTrue(unit.RemoveAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1"),
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
            }));

            Assert.AreEqual(1, unit.AbilitiesCount);
        }

        [TestMethod]
        public void AddAbilityIsNullTest()
        {
            Unit unit = new Unit();
            Assert.ThrowsException<ArgumentNullException>(() => { unit.AddAbility(null); });
        }

        [TestMethod]
        public void AddPassiveAbilityTest()
        {
            Unit unit = new Unit();
            unit.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId(string.Empty, "pass1"),
                AbilityType = AbilityType.Passive,
                IsPassive = true,
            });
            unit.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId(string.Empty, "pass1"),
                AbilityType = AbilityType.Passive,
                IsPassive = true,
            });
        }

        [TestMethod]
        public void ContainsPassiveAbilityTest()
        {
            Unit unit = new Unit();
            unit.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId(string.Empty, "pass1"),
                AbilityType = AbilityType.Passive,
                IsPassive = true,
            });
            unit.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId(string.Empty, "pass2"),
                AbilityType = AbilityType.Passive,
                IsPassive = true,
            });

            Assert.IsTrue(unit.ContainsAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId(string.Empty, "pass2"),
                AbilityType = AbilityType.Passive,
                IsPassive = true,
            }));

            Assert.IsFalse(unit.ContainsAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId(string.Empty, "pass3"),
                AbilityType = AbilityType.Passive,
                IsPassive = true,
            }));

            Assert.IsFalse(unit.ContainsAbility(new AbilityTalentId(string.Empty, "asdf")));
            Assert.IsTrue(unit.ContainsAbility(new AbilityTalentId(string.Empty, "pass2")));
        }

        [TestMethod]
        public void RemovePassiveAbilityTest()
        {
            Unit unit = new Unit();
            unit.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId(string.Empty, "pass1"),
                AbilityType = AbilityType.Passive,
                IsPassive = true,
            });
            unit.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId(string.Empty, "pass2"),
                AbilityType = AbilityType.Passive,
                IsPassive = true,
            });

            Assert.IsTrue(unit.RemoveAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId(string.Empty, "pass1"),
                AbilityType = AbilityType.Passive,
                IsPassive = true,
            }));
        }

        [TestMethod]
        public void GetPassiveAbilitiesTest()
        {
            Unit unit = new Unit();
            unit.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId(string.Empty, "pass1"),
                AbilityType = AbilityType.Passive,
                IsPassive = true,
            });
            unit.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId(string.Empty, "pass2"),
                AbilityType = AbilityType.Passive,
                IsPassive = true,
            });

            Ability ability = unit.GetAbilities(new AbilityTalentId(string.Empty, "pass2")).ToList()[0];
            Assert.AreEqual("pass2", ability.AbilityTalentId.ButtonId);
            Assert.AreEqual(string.Empty, ability.AbilityTalentId.ReferenceId);
        }

        [TestMethod]
        public void TryGetPassiveAbilitiesTest()
        {
            Unit unit = new Unit();
            unit.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId(string.Empty, "pass1"),
                AbilityType = AbilityType.Passive,
                IsPassive = true,
            });
            unit.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId(string.Empty, "pass2"),
                AbilityType = AbilityType.Passive,
                IsPassive = true,
            });

            Assert.IsTrue(unit.TryGetAbilities(new AbilityTalentId(string.Empty, "pass2"), out _));
        }
    }
}
