using Heroes.Models.AbilityTalents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Models.Tests
{
    [TestClass]
    public class UnitTests
    {
        private readonly Unit Unit = new Unit();
        private readonly Unit NullUnit = new Unit();

        public UnitTests()
        {
            AddAbilities();
            AddWeapons();
        }

        [TestMethod]
        public void GetPrimaryAbilitiesTests()
        {
            IList<Ability> basicAbilities = Unit.PrimaryAbilities(AbilityTier.Basic);
            Assert.AreEqual(3, basicAbilities.Count);

            IList<Ability> heroicAbilities = Unit.PrimaryAbilities(AbilityTier.Heroic);
            Assert.AreEqual(2, heroicAbilities.Count);

            IList<Ability> hearthAbilities = Unit.PrimaryAbilities(AbilityTier.Hearth);
            Assert.AreEqual(0, hearthAbilities.Count);

            Assert.IsNull(NullUnit.PrimaryAbilities(AbilityTier.Mount));
        }

        [TestMethod]
        public void GetSubAbilitiesTests()
        {
            IList<Ability> basicAbilities = Unit.SubAbilities(AbilityTier.Basic);
            Assert.AreEqual(2, basicAbilities.Count);

            IList<Ability> mountAbilities = Unit.SubAbilities(AbilityTier.Mount);
            Assert.AreEqual(0, mountAbilities.Count);

            Assert.IsNull(NullUnit.SubAbilities(AbilityTier.Mount));
        }

        [TestMethod]
        public void GetParentLinkedAbilitiesTests()
        {
            ILookup<string, Ability> parentLinkedAbilities = Unit.ParentLinkedAbilities();
            Assert.AreEqual(1, parentLinkedAbilities.Count);
            Assert.IsTrue(parentLinkedAbilities.Contains("Abil7"));
            Assert.AreEqual(2, parentLinkedAbilities["Abil7"].Count());

            Assert.IsNull(NullUnit.ParentLinkedAbilities());
        }

        [TestMethod]
        public void GetParentLinkedWeaponsTests()
        {
            ILookup<string, UnitWeapon> parentLinkedWeapons = Unit.ParentLinkedWeapons();
            Assert.AreEqual(1, parentLinkedWeapons.Count);
            Assert.IsTrue(parentLinkedWeapons.Contains("Weapon2"));
            Assert.AreEqual(2, parentLinkedWeapons["Weapon2"].Count());

            Assert.IsNotNull(NullUnit.ParentLinkedWeapons());
        }

        [TestMethod]
        public void IsMapUniqueTests()
        {
            Assert.IsFalse(Unit.IsMapUnique);

            Unit.MapName = "map";
            Assert.IsTrue(Unit.IsMapUnique);
        }

        [TestMethod]
        public void UnitWeaponExistsTest()
        {
            Assert.IsTrue(Unit.UnitWeaponExists(new UnitWeapon()
            {
                WeaponNameId = "Weapon1",
                ParentLink = string.Empty,
            }));
        }

        private void AddAbilities()
        {
            Unit.Abilities.Add("Abil1", new Ability()
            {
                Tier = AbilityTier.Basic,
                ParentLink = string.Empty,
            });

            Unit.Abilities.Add("Abil2", new Ability()
            {
                Tier = AbilityTier.Basic,
                ParentLink = string.Empty,
            });

            Unit.Abilities.Add("Abil3", new Ability()
            {
                Tier = AbilityTier.Basic,
                ParentLink = string.Empty,
            });

            Unit.Abilities.Add("Abil4", new Ability()
            {
                Tier = AbilityTier.Heroic,
                ParentLink = string.Empty,
            });

            Unit.Abilities.Add("Abil5", new Ability()
            {
                Tier = AbilityTier.Heroic,
                ParentLink = string.Empty,
            });

            Unit.Abilities.Add("Abil6", new Ability()
            {
                Tier = AbilityTier.Trait,
                ParentLink = string.Empty,
            });

            Unit.Abilities.Add("Abil7", new Ability()
            {
                Tier = AbilityTier.Activable,
                ParentLink = string.Empty,
            });

            Unit.Abilities.Add("SubAbil1", new Ability()
            {
                Tier = AbilityTier.Basic,
                ParentLink = "Abil7",
            });

            Unit.Abilities.Add("SubAbil2", new Ability()
            {
                Tier = AbilityTier.Basic,
                ParentLink = "Abil7",
            });

            NullUnit.Abilities = null;
        }

        private void AddWeapons()
        {
            Unit.AddUnitWeapon(new UnitWeapon()
            {
                WeaponNameId = "Weapon1",
                ParentLink = string.Empty,
            });

            Unit.AddUnitWeapon(new UnitWeapon()
            {
                WeaponNameId = "Weapon2",
                ParentLink = string.Empty,
            });

            Unit.AddUnitWeapon(new UnitWeapon()
            {
                WeaponNameId = "Weapon3",
                ParentLink = "Weapon2",
            });

            Unit.AddUnitWeapon(new UnitWeapon()
            {
                WeaponNameId = "Weapon4",
                ParentLink = "Weapon2",
            });

            Unit.AddUnitWeapon(new UnitWeapon()
            {
                WeaponNameId = "Weapon4",
                ParentLink = "Weapon2",
            });
        }
    }
}
