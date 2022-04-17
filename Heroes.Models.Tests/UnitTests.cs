using Heroes.Models.AbilityTalents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Models.Tests;

[TestClass]
public class UnitTests
{
    private readonly Unit _unit = new Unit();
    private readonly Unit _nullUnit = new Unit();

    public UnitTests()
    {
        AddAbilities();
        AddWeapons();
        AddArmor();
    }

    [TestMethod]
    public void GetPrimaryAbilitiesTests()
    {
        IList<Ability> basicAbilities = _unit.PrimaryAbilities(AbilityTiers.Basic).ToList();
        Assert.AreEqual(3, basicAbilities.Count);

        IList<Ability> heroicAbilities = _unit.PrimaryAbilities(AbilityTiers.Heroic).ToList();
        Assert.AreEqual(2, heroicAbilities.Count);

        IList<Ability> hearthAbilities = _unit.PrimaryAbilities(AbilityTiers.Hearth).ToList();
        Assert.AreEqual(0, hearthAbilities.Count);

        IList<Ability> allPrimaryAbilities = _unit.PrimaryAbilities().ToList();
        Assert.AreEqual(7, allPrimaryAbilities.Count);

        Assert.IsNotNull(_nullUnit.PrimaryAbilities(AbilityTiers.Mount));
    }

    [TestMethod]
    public void GetSubAbilitiesTests()
    {
        IList<Ability> basicAbilities = _unit.SubAbilities(AbilityTiers.Basic).ToList();
        Assert.AreEqual(2, basicAbilities.Count);

        IList<Ability> mountAbilities = _unit.SubAbilities(AbilityTiers.Mount).ToList();
        Assert.AreEqual(0, mountAbilities.Count);

        Assert.IsNotNull(_nullUnit.SubAbilities(AbilityTiers.Mount));
    }

    [TestMethod]
    public void GetParentLinkedAbilitiesTests()
    {
        ILookup<AbilityTalentId, Ability> parentLinkedAbilities = _unit.ParentLinkedAbilities();
        Assert.AreEqual(1, parentLinkedAbilities.Count);
        Assert.IsTrue(parentLinkedAbilities.Contains(new AbilityTalentId("Abil7", "abil7")));
        Assert.AreEqual(2, parentLinkedAbilities[new AbilityTalentId("Abil7", "abil7")].Count());

        Assert.IsNotNull(_nullUnit.ParentLinkedAbilities());
    }

    [TestMethod]
    public void GetParentLinkedWeaponsTests()
    {
        ILookup<string, UnitWeapon> parentLinkedWeapons = _unit.ParentLinkedWeapons();
        Assert.AreEqual(1, parentLinkedWeapons.Count);
        Assert.IsTrue(parentLinkedWeapons.Contains("Weapon2"));
        Assert.AreEqual(2, parentLinkedWeapons["Weapon2"].Count());

        Assert.IsNotNull(_nullUnit.ParentLinkedWeapons());
    }

    [TestMethod]
    public void IsMapUniqueTests()
    {
        Assert.IsFalse(_unit.IsMapUnique);

        _unit.MapName = "map";
        Assert.IsTrue(_unit.IsMapUnique);
    }

    [TestMethod]
    public void UnitWeaponExistsTest()
    {
        Assert.IsTrue(_unit.Weapons.Contains(new UnitWeapon()
        {
            WeaponNameId = "Weapon1",
            ParentLink = string.Empty,
        }));
    }

    [TestMethod]
    public void UnitArmorExistsTest()
    {
        Assert.IsTrue(_unit.Armor.Contains(new UnitArmor()
        {
            Type = "Structure",
            AbilityArmor = 5,
            SplashArmor = 15,
        }));
    }

    private void AddAbilities()
    {
        _unit.AddAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId("Abil1", "abil1"),
            Tier = AbilityTiers.Basic,
            ParentLink = null,
        });

        _unit.AddAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId("Abil2", "abil1"),
            Tier = AbilityTiers.Basic,
        });

        _unit.AddAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId("Abil3", "abil1"),
            Tier = AbilityTiers.Basic,
        });

        _unit.AddAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId("Abil4", "abil1"),
            Tier = AbilityTiers.Heroic,
        });

        _unit.AddAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId("Abil5", "abil1"),
            Tier = AbilityTiers.Heroic,
        });

        _unit.AddAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId("Abil6", "abil1"),
            Tier = AbilityTiers.Trait,
        });

        _unit.AddAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId("Abil7", "abil1"),
            Tier = AbilityTiers.Activable,
            ParentLink = null,
        });

        _unit.AddAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId("SubAbil1", "subAbil1"),
            Tier = AbilityTiers.Basic,
            ParentLink = new AbilityTalentId("Abil7", "abil7"),
        });

        _unit.AddAbility(new Ability()
        {
            AbilityTalentId = new AbilityTalentId("SubAbil2", "subAbil2"),
            Tier = AbilityTiers.Basic,
            ParentLink = new AbilityTalentId("Abil7", "abil7"),
        });
    }

    private void AddWeapons()
    {
        _unit.Weapons.Add(new UnitWeapon()
        {
            WeaponNameId = "Weapon1",
            ParentLink = string.Empty,
        });

        _unit.Weapons.Add(new UnitWeapon()
        {
            WeaponNameId = "Weapon2",
            ParentLink = string.Empty,
        });

        _unit.Weapons.Add(new UnitWeapon()
        {
            WeaponNameId = "Weapon3",
            ParentLink = "Weapon2",
        });

        _unit.Weapons.Add(new UnitWeapon()
        {
            WeaponNameId = "Weapon4",
            ParentLink = "Weapon2",
        });

        _unit.Weapons.Add(new UnitWeapon()
        {
            WeaponNameId = "Weapon4",
            ParentLink = "Weapon2",
        });
    }

    private void AddArmor()
    {
        _unit.Armor.Add(new UnitArmor()
        {
            Type = "Minion",
            AbilityArmor = 5,
            BasicArmor = 10,
            SplashArmor = 15,
        });
        _unit.Armor.Add(new UnitArmor()
        {
            Type = "Heroic",
            AbilityArmor = 5,
        });
        _unit.Armor.Add(new UnitArmor()
        {
            Type = "Structure",
            AbilityArmor = 5,
            SplashArmor = 15,
        });
        _unit.Armor.Add(new UnitArmor()
        {
            Type = "Structure",
            AbilityArmor = 5,
            SplashArmor = 15,
        });
    }
}
