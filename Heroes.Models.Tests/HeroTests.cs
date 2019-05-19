using Heroes.Models.AbilityTalents;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Ability abil = Hero.GetAbility("Abil3");
            Assert.AreEqual(AbilityTier.Basic, abil.Tier);
            Assert.AreEqual(string.Empty, abil.ParentLink);

            Assert.IsNull(Hero.GetAbility(string.Empty));
            Assert.IsNull(Hero.GetAbility(null));
            Assert.IsNull(Hero.GetAbility("asdf"));

            Assert.IsNull(NullHero.GetAbility("asdf"));
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

            Assert.IsNull(NullHero.GetTalent("asdf"));
        }

        [TestMethod]
        public void GetTierTalentsTests()
        {
            Assert.AreEqual(2, Hero.TierTalents(TalentTier.Level1).Count);
            Assert.AreEqual(1, Hero.TierTalents(TalentTier.Level4).Count);
        }

        private void AddAbilities()
        {
            Hero.AddAbility(new Ability()
            {
                ReferenceNameId = "Abil1",
                Tier = AbilityTier.Basic,
                ParentLink = string.Empty,
            });

            Hero.AddAbility(new Ability()
            {
                ReferenceNameId = "Abil2",
                Tier = AbilityTier.Basic,
                ParentLink = string.Empty,
            });

            Hero.AddAbility(new Ability()
            {
                ReferenceNameId = "Abil3",
                Tier = AbilityTier.Basic,
                ParentLink = string.Empty,
            });

            Hero.AddAbility(new Ability()
            {
                ReferenceNameId = "Abil4",
                Tier = AbilityTier.Heroic,
                ParentLink = string.Empty,
            });

            Hero.AddAbility(new Ability()
            {
                ReferenceNameId = "Abil5",
                Tier = AbilityTier.Heroic,
                ParentLink = string.Empty,
            });

            Hero.AddAbility(new Ability()
            {
                ReferenceNameId = "Abil6",
                Tier = AbilityTier.Trait,
                ParentLink = string.Empty,
            });

            Hero.AddAbility(new Ability()
            {
                ReferenceNameId = "Abil7",
                Tier = AbilityTier.Activable,
                ParentLink = string.Empty,
            });

            Hero.AddAbility(new Ability()
            {
                ReferenceNameId = "SubAbil1",
                Tier = AbilityTier.Basic,
                ParentLink = "Abil7",
            });

            Hero.AddAbility(new Ability()
            {
                ReferenceNameId = "SubAbil2",
                Tier = AbilityTier.Basic,
                ParentLink = "Abil7",
            });
        }

        private void AddTalents()
        {
            Hero.Talents.Add("Talent1", new Talent()
            {
                Name = "Talent 1",
                IconFileName = "storm_ui.png",
                Tier = TalentTier.Level1,
            });

            Hero.Talents.Add("Talent2", new Talent()
            {
                Name = "Talent 2",
                IconFileName = "storm_ui.png",
                Tier = TalentTier.Level1,
            });

            Hero.Talents.Add("Talent3", new Talent()
            {
                Name = "Talent 3",
                IconFileName = "storm_ui.png",
                Tier = TalentTier.Level4,
            });

            NullHero.Talents = null;
        }
    }
}
