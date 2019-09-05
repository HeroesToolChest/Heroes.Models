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
            List<Ability> abil = _hero.GetAbilities(new AbilityTalentId("Abil3", "Abil3")).ToList();
            Assert.AreEqual(AbilityTier.Basic, abil[0].Tier);
            Assert.IsNull(abil[0].ParentLink);

            Assert.AreEqual(0, _hero.GetAbilities(new AbilityTalentId("Asdf", "Asdf")).ToList().Count);

            Assert.AreEqual(0, _nullHero.GetAbilities(new AbilityTalentId("Asdf", "Asdf")).ToList().Count);

            Assert.AreEqual(3, _hero.GetAbilities(new AbilityTalentId("Abil1", "Abil1")).ToList().Count);
        }

        [TestMethod]
        public void GetTalentTests()
        {
            Talent talent = _hero.GetTalent("Talent2");
            Assert.AreEqual("Talent 2", talent.Name);
            Assert.AreEqual("storm_ui.png", talent.IconFileName);

            talent = _hero.GetTalent(string.Empty);
            Assert.AreEqual("No Pick", talent.Name);

            talent = _hero.GetTalent("asdf");
            Assert.AreEqual("asdf", talent.Name);

            Assert.IsNotNull(_nullHero.GetTalent("asdf"));
        }

        [TestMethod]
        public void GetTierTalentsTests()
        {
            Assert.AreEqual(2, _hero.TierTalents(TalentTier.Level1).Count());
            Assert.AreEqual(1, _hero.TierTalents(TalentTier.Level4).Count());
        }

        private void AddAbilities()
        {
            _hero.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil1", "abil1"),
                Tier = AbilityTier.Basic,
                ParentLink = null,
            });

            _hero.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil1", "abil1"),
                Tier = AbilityTier.Basic,
                AbilityType = AbilityType.W,
            });

            _hero.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil1", "abil1"),
                Tier = AbilityTier.Basic,
                AbilityType = AbilityType.Q,
            });

            _hero.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil2", "abil2"),
                Tier = AbilityTier.Basic,
            });

            _hero.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil3", "abil3"),
                Tier = AbilityTier.Basic,
            });

            _hero.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil4", "abil4"),
                Tier = AbilityTier.Heroic,
                ParentLink = null,
            });

            _hero.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil5", "abil5"),
                Tier = AbilityTier.Heroic,
            });

            _hero.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil6", "abil6"),
                Tier = AbilityTier.Trait,
            });

            _hero.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil7", "abil7"),
                Tier = AbilityTier.Activable,
            });

            _hero.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("SubAbil1", "subAbil1"),
                Tier = AbilityTier.Basic,
                ParentLink = new AbilityTalentId("Abil7", "abil7"),
            });

            _hero.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("SubAbil2", "subAbil2"),
                Tier = AbilityTier.Basic,
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
                Tier = TalentTier.Level1,
            });

            _hero.AddTalent(new Talent()
            {
                AbilityTalentId = new AbilityTalentId("Talent2", "tal2"),
                Name = "Talent 2",
                IconFileName = "storm_ui.png",
                Tier = TalentTier.Level1,
            });

            _hero.AddTalent(new Talent()
            {
                AbilityTalentId = new AbilityTalentId("Talent3", "tal3"),
                Name = "Talent 3",
                IconFileName = "storm_ui.png",
                Tier = TalentTier.Level4,
            });
        }
    }
}
