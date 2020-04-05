using System;
using System.Collections.Generic;

namespace Heroes.Models
{
    /// <summary>
    /// Contains the information related to unit weapon.
    /// </summary>
    public class UnitWeapon
    {
        private readonly HashSet<WeaponAttributeFactor> _weaponAttributeFactorList = new HashSet<WeaponAttributeFactor>();

        /// <summary>
        /// Gets or sets the unique id of the weapon.
        /// </summary>
        public string WeaponNameId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the weapon.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the amount of damage the attack deals.
        /// </summary>
        public double Damage { get; set; }

        /// <summary>
        /// Gets the collection of attribute factors.
        /// </summary>
        public IEnumerable<WeaponAttributeFactor> AttributeFactors => _weaponAttributeFactorList;

        /// <summary>
        /// Gets or sets the time between attacks.
        /// </summary>
        public double Period { get; set; }

        /// <summary>
        /// Gets or sets the distance of the attack.
        /// </summary>
        public double Range { get; set; }

        /// <summary>
        /// Gets or sets the damage scaling per level.
        /// </summary>
        public double DamageScaling { get; set; }

        /// <summary>
        /// Gets or sets the unit that is associated with this weapon.
        /// </summary>
        public string? ParentLink { get; set; }

        /// <summary>
        /// Gets the attacks per second.
        /// </summary>
        /// <returns></returns>
        public double GetAttacksPerSecond()
        {
            if (Period == 0)
                return 0;

            return 1 / Period;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (!(obj is UnitWeapon item))
                return false;

            return WeaponNameId.Equals(item.WeaponNameId, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(WeaponNameId);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return WeaponNameId;
        }

        /// <summary>
        /// Adds a <see cref="WeaponAttributeFactor"/>. Replaces if object already exists in collection.
        /// </summary>
        /// <param name="weaponAttributeFactor">A <see cref="WeaponAttributeFactor"/>.</param>
        public void AddAttributeFactor(WeaponAttributeFactor weaponAttributeFactor)
        {
            if (weaponAttributeFactor == null)
            {
                throw new ArgumentNullException(nameof(weaponAttributeFactor));
            }

            if (_weaponAttributeFactorList.Contains(weaponAttributeFactor))
                _weaponAttributeFactorList.Remove(weaponAttributeFactor);

            _weaponAttributeFactorList.Add(weaponAttributeFactor);
        }

        /// <summary>
        /// Determines whether the <see cref="WeaponAttributeFactor"/> exists.
        /// </summary>
        /// <param name="weaponAttributeFactor">A <see cref="WeaponAttributeFactor"/>.</param>
        /// <returns></returns>
        public bool ContainsAttributeFactor(WeaponAttributeFactor weaponAttributeFactor)
        {
            if (weaponAttributeFactor == null)
            {
                throw new ArgumentNullException(nameof(weaponAttributeFactor));
            }

            return _weaponAttributeFactorList.Contains(weaponAttributeFactor);
        }
    }
}
