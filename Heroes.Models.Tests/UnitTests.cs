﻿using Heroes.Models.AbilityTalents;
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
            AddArmor();
        }

        [TestMethod]
        public void GetPrimaryAbilitiesTests()
        {
            IList<Ability> basicAbilities = Unit.PrimaryAbilities(AbilityTier.Basic).ToList();
            Assert.AreEqual(3, basicAbilities.Count);

            IList<Ability> heroicAbilities = Unit.PrimaryAbilities(AbilityTier.Heroic).ToList();
            Assert.AreEqual(2, heroicAbilities.Count);

            IList<Ability> hearthAbilities = Unit.PrimaryAbilities(AbilityTier.Hearth).ToList();
            Assert.AreEqual(0, hearthAbilities.Count);

            IList<Ability> allPrimaryAbilities = Unit.PrimaryAbilities().ToList();
            Assert.AreEqual(7, allPrimaryAbilities.Count);

            Assert.IsNotNull(NullUnit.PrimaryAbilities(AbilityTier.Mount));
        }

        [TestMethod]
        public void GetSubAbilitiesTests()
        {
            IList<Ability> basicAbilities = Unit.SubAbilities(AbilityTier.Basic).ToList();
            Assert.AreEqual(2, basicAbilities.Count);

            IList<Ability> mountAbilities = Unit.SubAbilities(AbilityTier.Mount).ToList();
            Assert.AreEqual(0, mountAbilities.Count);

            Assert.IsNotNull(NullUnit.SubAbilities(AbilityTier.Mount));
        }

        [TestMethod]
        public void GetParentLinkedAbilitiesTests()
        {
            ILookup<AbilityTalentId, Ability> parentLinkedAbilities = Unit.ParentLinkedAbilities();
            Assert.AreEqual(1, parentLinkedAbilities.Count);
            Assert.IsTrue(parentLinkedAbilities.Contains(new AbilityTalentId("Abil7", "abil7")));
            Assert.AreEqual(2, parentLinkedAbilities[new AbilityTalentId("Abil7", "abil7")].Count());

            Assert.IsNotNull(NullUnit.ParentLinkedAbilities());
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
            Assert.IsTrue(Unit.ContainsUnitWeapon(new UnitWeapon()
            {
                WeaponNameId = "Weapon1",
                ParentLink = string.Empty,
            }));
        }

        [TestMethod]
        public void UnitArmorExistsTest()
        {
            Assert.IsTrue(Unit.ContainsUnitArmor(new UnitArmor()
            {
                Type = "Structure",
                AbilityArmor = 5,
                SplashArmor = 15,
            }));
        }

        private void AddAbilities()
        {
            Unit.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil1", "abil1"),
                Tier = AbilityTier.Basic,
                ParentLink = null,
            });

            Unit.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil2", "abil1"),
                Tier = AbilityTier.Basic,
            });

            Unit.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil3", "abil1"),
                Tier = AbilityTier.Basic,
            });

            Unit.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil4", "abil1"),
                Tier = AbilityTier.Heroic,
            });

            Unit.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil5", "abil1"),
                Tier = AbilityTier.Heroic,
            });

            Unit.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil6", "abil1"),
                Tier = AbilityTier.Trait,
            });

            Unit.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("Abil7", "abil1"),
                Tier = AbilityTier.Activable,
                ParentLink = null,
            });

            Unit.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("SubAbil1", "subAbil1"),
                Tier = AbilityTier.Basic,
                ParentLink = new AbilityTalentId("Abil7", "abil7"),
            });

            Unit.AddAbility(new Ability()
            {
                AbilityTalentId = new AbilityTalentId("SubAbil2", "subAbil2"),
                Tier = AbilityTier.Basic,
                ParentLink = new AbilityTalentId("Abil7", "abil7"),
            });
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

        private void AddArmor()
        {
            Unit.AddUnitArmor(new UnitArmor()
            {
                Type = "Minion",
                AbilityArmor = 5,
                BasicArmor = 10,
                SplashArmor = 15,
            });
            Unit.AddUnitArmor(new UnitArmor()
            {
                Type = "Heroic",
                AbilityArmor = 5,
            });
            Unit.AddUnitArmor(new UnitArmor()
            {
                Type = "Structure",
                AbilityArmor = 5,
                SplashArmor = 15,
            });
            Unit.AddUnitArmor(new UnitArmor()
            {
                Type = "Structure",
                AbilityArmor = 5,
                SplashArmor = 15,
            });
        }
    }
}
