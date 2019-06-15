using Heroes.Models.AbilityTalents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
                ReferenceId = "Ability1",
                ButtonId = "abil1",
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
            };

            Ability ability2 = new Ability()
            {
                ReferenceId = "AbilitY1",
                ButtonId = "abil1",
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
                ReferenceId = "Ability1",
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
            };

            Ability ability2 = new Ability()
            {
                ReferenceId = "Ability1",
                ButtonId = "Ability",
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
                ReferenceId = "Ability1",
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
            };

            Ability ability2 = new Ability()
            {
                ReferenceId = "AbilitY1",
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
                ReferenceId = "Ability1",
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
            };

            Ability ability2 = new Ability()
            {
                ReferenceId = "AbilitY1",
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
                ReferenceId = "Ability1",
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
            };

            Ability ability2 = new Ability()
            {
                ReferenceId = "Ability1",
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
            };

            Ability ability3 = new Ability()
            {
                ReferenceId = "Ability2",
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
                ReferenceId = "Ability1",
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
            };

            Ability ability2 = new Ability()
            {
                ReferenceId = "Ability1",
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
            };

            Ability ability3 = new Ability()
            {
                ReferenceId = "Ability2",
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
            };

            Unit unit = new Unit();
            unit.AddAbility(ability1);
            unit.AddAbility(ability2);
            unit.AddAbility(ability3);

            Assert.IsTrue(unit.ContainsAbility(new Ability()
            {
                ReferenceId = "Ability1",
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
            }));
            Assert.IsFalse(unit.ContainsAbility(new Ability()
            {
                ReferenceId = "Ability1",
                AbilityType = AbilityType.Hidden,
                IconFileName = "test.png",
            }));
            Assert.IsFalse(unit.ContainsAbility(new Ability()
            {
                ReferenceId = "Ability4",
                AbilityType = AbilityType.Hidden,
                IconFileName = "test.png",
            }));

            Assert.IsTrue(unit.ContainsAbility("Ability1"));
            Assert.IsFalse(unit.ContainsAbility("Ability5"));
        }

        [TestMethod]
        public void RemoveAbilityTest()
        {
            Ability ability1 = new Ability()
            {
                ReferenceId = "Ability1",
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
            };

            Ability ability2 = new Ability()
            {
                ReferenceId = "Ability1",
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
            };

            Ability ability3 = new Ability()
            {
                ReferenceId = "Ability2",
                AbilityType = AbilityType.Heroic,
            };

            Unit unit = new Unit();
            unit.AddAbility(ability1);
            unit.AddAbility(ability2);
            unit.AddAbility(ability3);

            Assert.AreEqual(3, unit.AbilitiesCount);

            Assert.IsTrue(unit.RemoveAbility(new Ability()
            {
                ReferenceId = "Ability1",
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
            }));

            // try to remove again
            Assert.IsFalse(unit.RemoveAbility(new Ability()
            {
                ReferenceId = "Ability1",
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
            }));

            Assert.IsFalse(unit.RemoveAbility(new Ability()
            {
                ReferenceId = "Ability3",
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
            }));

            Assert.AreEqual(2, unit.AbilitiesCount);

            // remove 1
            Assert.IsTrue(unit.RemoveAbility(new Ability()
            {
                ReferenceId = "Ability1",
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
            }));

            Assert.AreEqual(1, unit.AbilitiesCount);
        }
    }
}
