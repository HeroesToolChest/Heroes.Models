namespace Heroes.Models
{
    public class UnitWeapon
    {
        /// <summary>
        /// Gets or sets the unique id of the weapon.
        /// </summary>
        public string WeaponNameId { get; set; }

        /// <summary>
        /// Gets or sets the name of the weapon.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the amount of damage the attack deals.
        /// </summary>
        public double Damage { get; set; }

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
        public string ParentLink { get; set; }

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

        public override bool Equals(object obj)
        {
            if (!(obj is UnitWeapon item))
                return false;

            return WeaponNameId == item.WeaponNameId;
        }

        public override int GetHashCode()
        {
            return WeaponNameId.GetHashCode();
        }

        public override string ToString()
        {
            return WeaponNameId;
        }
    }
}
