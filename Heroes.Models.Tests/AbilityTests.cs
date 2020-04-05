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
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
                {
                    AbilityType = AbilityTypes.Active,
                },
                IconFileName = "test.png",
            };

            Ability ability2 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
                {
                    AbilityType = AbilityTypes.Active,
                },
                IconFileName = "test.png",
            };

            Assert.AreEqual(ability1, ability2);
        }

        [TestMethod]
        public void AbilitiesAreNotEqualTest()
        {
            Ability ability1 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
                {
                    AbilityType = AbilityTypes.Active,
                },
                IconFileName = "test.png",
            };

            Ability ability2 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "Ability")
                {
                    AbilityType = AbilityTypes.Heroic,
                },
                IconFileName = "test.png",
            };

            Assert.AreNotEqual(ability1, ability2);
        }

        [TestMethod]
        public void AbilityAddedSuccesfullyToHashSetTest()
        {
            Ability ability1 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
                {
                    AbilityType = AbilityTypes.Active,
                },
                IconFileName = "test.png",
            };

            Ability ability2 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("AbilitY1", "abil1")
                {
                    AbilityType = AbilityTypes.Heroic,
                },
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
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
                {
                    AbilityType = AbilityTypes.Active,
                },
                IconFileName = "test.png",
            };

            Ability ability2 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
                {
                    AbilityType = AbilityTypes.Active,
                },
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
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
                {
                    AbilityType = AbilityTypes.Active,
                },
                IconFileName = "test.png",
            };

            Ability ability2 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
                {
                    AbilityType = AbilityTypes.Heroic,
                },
                IconFileName = "test.png",
            };

            Ability ability3 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability2", "abil2")
                {
                    AbilityType = AbilityTypes.Heroic,
                },
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
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
                {
                    AbilityType = AbilityTypes.Active,
                },
                IconFileName = "test.png",
            };

            Ability ability2 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
                {
                    AbilityType = AbilityTypes.Heroic,
                },
                IconFileName = "test.png",
            };

            Ability ability3 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability2", "abil2")
                {
                    AbilityType = AbilityTypes.Heroic,
                },
                IconFileName = "test.png",
            };

            Unit unit = new Unit();
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
            Ability ability1 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
                {
                    AbilityType = AbilityTypes.Active,
                },
                IconFileName = "test.png",
            };

            Ability ability2 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability1", "abil1")
                {
                    AbilityType = AbilityTypes.Heroic,
                },
                IconFileName = "test.png",
            };

            Ability ability3 = new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Ability2", "abil2")
                {
                    AbilityType = AbilityTypes.Heroic,
                },
            };

            Unit unit = new Unit();
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
            Unit unit = new Unit();
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
            Unit unit = new Unit();
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
            Unit unit = new Unit();
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
            Unit unit = new Unit();
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
            Unit unit = new Unit();
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
                }, out Ability? ability));

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
            Unit unit = new Unit();
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
}
