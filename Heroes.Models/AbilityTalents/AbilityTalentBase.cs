using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("HeroesData.Parser")]
namespace Heroes.Models.AbilityTalents
{
    public abstract class AbilityTalentBase
    {
        private readonly HashSet<string> _createdUnitList = new HashSet<string>(StringComparer.Ordinal);

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
        /// Gets or sets if the abilityTalent is a quest.
        /// </summary>
        public bool IsQuest { get; set; }

        /// <summary>
        /// Gets or sets if the abilityTalent is activable through a hotkey.
        /// </summary>
        public bool IsActive { get; set; }

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
        /// Gets a collection of created units.
        /// </summary>
        internal IEnumerable<string> CreatedUnits => _createdUnitList;

        public override bool Equals(object? obj)
        {
            if (!(obj is AbilityTalentBase item))
                return false;

            return item.AbilityTalentId.Id.Equals(AbilityTalentId.Id);
        }

        public override int GetHashCode()
        {
            return $"{AbilityTalentId.Id + Name + IconFileName + AbilityTalentId.AbilityType}".ToUpper().GetHashCode();
        }

        /// <summary>
        /// Adds a value. Replaces if object already exists in collection.
        /// </summary>
        /// <param name="value"></param>
        internal void AddCreatedUnit(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Argument cannot be null or empty", nameof(value));
            }

            _createdUnitList.Add(value);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal bool ContainsCreatedUnit(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Argument cannot be null or empty", nameof(value));
            }

            return _createdUnitList.Contains(value);
        }
    }
}
