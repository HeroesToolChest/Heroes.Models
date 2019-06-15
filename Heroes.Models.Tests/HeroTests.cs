using Heroes.Models.AbilityTalents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Models.Tests
{
    [TestClass]
    public class HeroTests
    {
        private readonly Hero Hero = new Hero();
        private readonly Hero NullHero = new Hero();

        public HeroTests()
        {
            AddAbilities();
            AddTalents();
        }

        [TestMethod]
        public void GetAbilityTests()
        {
            List<Ability> abil = Hero.GetAbilities("Abil3").ToList();
            Assert.AreEqual(AbilityTier.Basic, abil[0].Tier);
            Assert.AreEqual(string.Empty, abil[0].ParentLink);

            Assert.IsNull(Hero.GetAbilities(string.Empty));
            Assert.IsNull(Hero.GetAbilities(null));
            Assert.AreEqual(0, Hero.GetAbilities("Asdf").ToList().Count);

            Assert.AreEqual(0, NullHero.GetAbilities("Asdf").ToList().Count);

            Assert.AreEqual(3, Hero.GetAbilities("Abil1").ToList().Count);
        }

        [TestMethod]
        public void GetTalentTests()
        {
            Talent talent = Hero.GetTalent("Talent2");
            Assert.AreEqual("Talent 2", talent.Name);
            Assert.AreEqual("storm_ui.png", talent.IconFileName);

            talent = Hero.GetTalent(null);
            Assert.AreEqual("No Pick", talent.Name);

            talent = Hero.GetTalent("asdf");
            Assert.AreEqual("asdf", talent.Name);

            Assert.IsNotNull(NullHero.GetTalent("asdf"));
        }

        [TestMethod]
        public void GetTierTalentsTests()
        {
            Assert.AreEqual(2, Hero.TierTalents(TalentTier.Level1).Count());
            Assert.AreEqual(1, Hero.TierTalents(TalentTier.Level4).Count());
        }

        private void AddAbilities()
        {
            Hero.AddAbility(new Ability()
            {
                ReferenceId = "Abil1",
                Tier = AbilityTier.Basic,
                ParentLink = string.Empty,
            });

            Hero.AddAbility(new Ability()
            {
                ReferenceId = "Abil1",
                Tier = AbilityTier.Basic,
                ParentLink = string.Empty,
                AbilityType = AbilityType.W,
            });

            Hero.AddAbility(new Ability()
            {
                ReferenceId = "Abil1",
                Tier = AbilityTier.Basic,
                ParentLink = string.Empty,
                AbilityType = AbilityType.Q,
            });

            Hero.AddAbility(new Ability()
            {
                ReferenceId = "Abil2",
                Tier = AbilityTier.Basic,
                ParentLink = string.Empty,
            });

            Hero.AddAbility(new Ability()
            {
                ReferenceId = "Abil3",
                Tier = AbilityTier.Basic,
                ParentLink = string.Empty,
            });

            Hero.AddAbility(new Ability()
            {
                ReferenceId = "Abil4",
                Tier = AbilityTier.Heroic,
                ParentLink = string.Empty,
            });

            Hero.AddAbility(new Ability()
            {
                ReferenceId = "Abil5",
                Tier = AbilityTier.Heroic,
                ParentLink = string.Empty,
            });

            Hero.AddAbility(new Ability()
            {
                ReferenceId = "Abil6",
                Tier = AbilityTier.Trait,
                ParentLink = string.Empty,
            });

            Hero.AddAbility(new Ability()
            {
                ReferenceId = "Abil7",
                Tier = AbilityTier.Activable,
                ParentLink = string.Empty,
            });

            Hero.AddAbility(new Ability()
            {
                ReferenceId = "SubAbil1",
                Tier = AbilityTier.Basic,
                ParentLink = "Abil7",
            });

            Hero.AddAbility(new Ability()
            {
                ReferenceId = "SubAbil2",
                Tier = AbilityTier.Basic,
                ParentLink = "Abil7",
            });
        }

        private void AddTalents()
        {
            Hero.AddTalent(new Talent()
            {
                ReferenceId = "Talent1",
                Name = "Talent 1",
                IconFileName = "storm_ui.png",
                Tier = TalentTier.Level1,
            });

            Hero.AddTalent(new Talent()
            {
                ReferenceId = "Talent2",
                Name = "Talent 2",
                IconFileName = "storm_ui.png",
                Tier = TalentTier.Level1,
            });

            Hero.AddTalent(new Talent()
            {
                ReferenceId = "Talent3",
                Name = "Talent 3",
                IconFileName = "storm_ui.png",
                Tier = TalentTier.Level4,
            });
        }
    }
}
