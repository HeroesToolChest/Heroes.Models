using System;

namespace Heroes.Models
{
    public class UnitArmor
    {
        /// <summary>
        /// Gets or sets the type of armor (Hero, Merc, etc...)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the physical (basic) armor.
        /// </summary>
        public int BasicArmor { get; set; }

        /// <summary>
        /// Gets or sets the Spell (ability) armor.
        /// </summary>
        public int AbilityArmor { get; set; }

        /// <summary>
        /// Gets or sets the Splash armor.
        /// </summary>
        public int SplashArmor { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is UnitArmor item))
                return false;

            return Type.Equals(item.Type, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }

        public override string ToString()
        {
            return $"Type: {Type}, Basic: {BasicArmor}, Ability: {AbilityArmor}, Splash: {SplashArmor}";
        }
    }
}
