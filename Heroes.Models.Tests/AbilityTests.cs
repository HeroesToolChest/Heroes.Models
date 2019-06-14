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
                ReferenceNameId = "Ability1",
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
            };

            Ability ability2 = new Ability()
            {
                ReferenceNameId = "AbilitY1",
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
            };

            Assert.AreEqual(ability1, ability2);
        }

        [TestMethod]
        public void AbilitiesAreNotEqualTest()
        {
            Ability ability1 = new Ability()
            {
                ReferenceNameId = "Ability1",
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
            };

            Ability ability2 = new Ability()
            {
                ReferenceNameId = "Ability1",
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
            };

            Assert.AreNotEqual(ability1, ability2);
        }

        [TestMethod]
        public void AbilityAddedSuccesfullyToHashSetTest()
        {
            Ability ability1 = new Ability()
            {
                ReferenceNameId = "Ability1",
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
            };

            Ability ability2 = new Ability()
            {
                ReferenceNameId = "AbilitY1",
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
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
                ReferenceNameId = "Ability1",
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
            };

            Ability ability2 = new Ability()
            {
                ReferenceNameId = "AbilitY1",
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
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
                ReferenceNameId = "Ability1",
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
            };

            Ability ability2 = new Ability()
            {
                ReferenceNameId = "Ability1",
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
            };

            Ability ability3 = new Ability()
            {
                ReferenceNameId = "Ability2",
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
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
                ReferenceNameId = "Ability1",
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
            };

            Ability ability2 = new Ability()
            {
                ReferenceNameId = "Ability1",
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
            };

            Ability ability3 = new Ability()
            {
                ReferenceNameId = "Ability2",
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
            };

            Unit unit = new Unit();
            unit.AddAbility(ability1);
            unit.AddAbility(ability2);
            unit.AddAbility(ability3);

            Assert.IsTrue(unit.ContainsAbility(new Ability()
            {
                ReferenceNameId = "Ability1",
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
            }));
            Assert.IsFalse(unit.ContainsAbility(new Ability()
            {
                ReferenceNameId = "Ability1",
                AbilityType = AbilityType.Hidden,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
            }));
            Assert.IsFalse(unit.ContainsAbility(new Ability()
            {
                ReferenceNameId = "Ability4",
                AbilityType = AbilityType.Hidden,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
            }));

            Assert.IsTrue(unit.ContainsAbility("Ability1"));
            Assert.IsFalse(unit.ContainsAbility("Ability5"));
        }

        [TestMethod]
        public void RemoveAbilityTest()
        {
            Ability ability1 = new Ability()
            {
                ReferenceNameId = "Ability1",
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
            };

            Ability ability2 = new Ability()
            {
                ReferenceNameId = "Ability1",
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
            };

            Ability ability3 = new Ability()
            {
                ReferenceNameId = "Ability2",
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
            };

            Unit unit = new Unit();
            unit.AddAbility(ability1);
            unit.AddAbility(ability2);
            unit.AddAbility(ability3);

            Assert.AreEqual(3, unit.AbilitiesCount);

            Assert.IsTrue(unit.RemoveAbility(new Ability()
            {
                ReferenceNameId = "Ability1",
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
            }));

            // try to remove again
            Assert.IsFalse(unit.RemoveAbility(new Ability()
            {
                ReferenceNameId = "Ability1",
                AbilityType = AbilityType.Active,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
            }));

            Assert.IsFalse(unit.RemoveAbility(new Ability()
            {
                ReferenceNameId = "Ability3",
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
            }));

            Assert.AreEqual(2, unit.AbilitiesCount);

            // remove 1
            Assert.IsTrue(unit.RemoveAbility(new Ability()
            {
                ReferenceNameId = "Ability1",
                AbilityType = AbilityType.Heroic,
                IconFileName = "test.png",
                ShortTooltipNameId = "abil1",
                FullTooltipNameId = "abil1",
            }));

            Assert.AreEqual(1, unit.AbilitiesCount);
        }
    }
}
