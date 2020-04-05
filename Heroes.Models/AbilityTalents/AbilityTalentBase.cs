using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("HeroesData.Parser")]
namespace Heroes.Models.AbilityTalents
{
    /// <summary>
    /// Abtract class that contains informations related to both abilites and talents.
    /// </summary>
    public abstract class AbilityTalentBase
    {
        /// <summary>
        /// Gets or sets the real name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the abilityTalent id.
        /// </summary>
        public AbilityTalentId AbilityTalentId { get; set; } = new AbilityTalentId(string.Empty, string.Empty);

        /// <summary>
        /// Gets or sets the icon file name.
        /// </summary>
        public string IconFileName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether the abilityTalent is a quest.
        /// </summary>
        public bool IsQuest { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the abilityTalent is activable through a hotkey.
        /// </summary>
        public bool IsActive { get; set; } = false;

        /// <summary>
        /// Gets or sets the parent that is associated with this abilityTalent.
        /// </summary>
        /// <remarks>Useful for abilities only.</remarks>
        public AbilityTalentId? ParentLink { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="AbilityTalentTooltip"/> object.
        /// </summary>
        public AbilityTalentTooltip Tooltip { get; set; } = new AbilityTalentTooltip();

        /// <summary>
        /// Gets a unique collection of created units.
        /// </summary>
        internal HashSet<string> CreatedUnits { get; } = new HashSet<string>(StringComparer.Ordinal);

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (!(obj is AbilityTalentBase item))
                return false;

            return item.AbilityTalentId.Id.Equals(AbilityTalentId.Id);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return $"{AbilityTalentId.Id + Name + IconFileName + AbilityTalentId.AbilityType}".ToUpper(CultureInfo.InvariantCulture).GetHashCode();
        }
    }
}
