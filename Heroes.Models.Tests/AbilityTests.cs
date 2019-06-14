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
    }
}
