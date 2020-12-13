using Heroes.Models.AbilityTalents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Models.Tests
{
    [TestClass]
    public class HeroTests
    {
        private readonly Hero _hero = new Hero();
        private readonly Hero _nullHero = new Hero();

        public HeroTests()
        {
            AddAbilities();
            AddTalents();
        }

        [TestMethod]
        public void GetAbilityTests()
        {
            Ability abil = _hero.GetAbility(new AbilityTalentId("Abil3", "Abil3"));
            Assert.AreEqual(AbilityTiers.Basic, abil.Tier);
            Assert.IsNull(abil.ParentLink);
        }

        [TestMethod]
        public void GetTalentTests()
        {
            Talent talent = _hero.GetTalent("Talent2");
            Assert.AreEqual("Talent 2", talent.Name);
            Assert.AreEqual("storm_ui.png", talent.IconFileName);

            Assert.ThrowsException<KeyNotFoundException>(() => _hero.GetTalent(string.Empty));
            Assert.ThrowsException<KeyNotFoundException>(() => _hero.GetTalent("asdf"));
        }

        [TestMethod]
        public void GetTierTalentsTests()
        {
            Assert.AreEqual(2, _hero.TierTalents(TalentTiers.Level1).Count());
            Assert.AreEqual(1, _hero.TierTalents(TalentTiers.Level4).Count());
        }

        [TestMethod]
        public void UsesMountTest()
        {
            Assert.IsFalse(new Hero().UsesMount);

            Hero hasMountHero = new()
            {
                DefaultMountId = "flames of war",
            };

            Assert.IsTrue(hasMountHero.UsesMount);
        }

        private void AddAbilities()
        {
            _hero.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil1", "abil1"),
                Tier = AbilityTiers.Basic,
                ParentLink = null,
            });

            _hero.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil1", "abil1")
                {
                    AbilityType = AbilityTypes.W,
                },
                Tier = AbilityTiers.Basic,
            });

            _hero.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil1", "abil1")
                {
                    AbilityType = AbilityTypes.Q,
                },
                Tier = AbilityTiers.Basic,
            });

            _hero.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil2", "abil2"),
                Tier = AbilityTiers.Basic,
            });

            _hero.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil3", "abil3"),
                Tier = AbilityTiers.Basic,
            });

            _hero.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil4", "abil4"),
                Tier = AbilityTiers.Heroic,
                ParentLink = null,
            });

            _hero.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil5", "abil5"),
                Tier = AbilityTiers.Heroic,
            });

            _hero.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil6", "abil6"),
                Tier = AbilityTiers.Trait,
            });

            _hero.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil7", "abil7"),
                Tier = AbilityTiers.Activable,
            });

            _hero.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("SubAbil1", "subAbil1"),
                Tier = AbilityTiers.Basic,
                ParentLink = new AbilityTalentId("Abil7", "abil7"),
            });

            _hero.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("SubAbil2", "subAbil2"),
                Tier = AbilityTiers.Basic,
                ParentLink = new AbilityTalentId("Abil7", "abil7"),
            });
        }

        private void AddTalents()
        {
            _hero.AddTalent(new Talent()
            {
                AbilityTalentId = new AbilityTalentId("Talent1", "tal1"),
                Name = "Talent 1",
                IconFileName = "storm_ui.png",
                Tier = TalentTiers.Level1,
            });

            _hero.AddTalent(new Talent()
            {
                AbilityTalentId = new AbilityTalentId("Talent2", "tal2"),
                Name = "Talent 2",
                IconFileName = "storm_ui.png",
                Tier = TalentTiers.Level1,
            });

            _hero.AddTalent(new Talent()
            {
                AbilityTalentId = new AbilityTalentId("Talent3", "tal3"),
                Name = "Talent 3",
                IconFileName = "storm_ui.png",
                Tier = TalentTiers.Level4,
            });
        }
    }
}
