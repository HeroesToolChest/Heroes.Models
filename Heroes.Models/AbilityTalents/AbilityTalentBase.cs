using System;
using System.Collections.Generic;

namespace Heroes.Models.AbilityTalents
{
    public class AbilityTalentBase
    {
        private readonly HashSet<string> CreatedUnitList = new HashSet<string>();

        /// <summary>
        /// Gets or sets the real name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the abilityTalent id.
        /// </summary>
        public AbilityTalentId AbilityTalentId { get; set; }

        /// <summary>
        /// Gets or sets the icon file name.
        /// </summary>
        public string IconFileName { get; set; }

        /// <summary>
        /// Gets or sets the ability associated with this abilityTalent.
        /// </summary>
        public AbilityType AbilityType { get; set; }

        /// <summary>
        /// Gets or sets if the abilityTalent is a quest.
        /// </summary>
        public bool IsQuest { get; set; }

        /// <summary>
        /// Gets or sets if the abilityTalent is activable through a hotkey.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the value if the abilityTalent is passive.
        /// </summary>
        /// <remarks>Useful for abilities only.</remarks>
        public bool IsPassive { get; set; }

        /// <summary>
        /// Gets or sets the parent that is associated with this abilityTalent.
        /// </summary>
        /// <remarks>Useful for abilities only.</remarks>
        public AbilityTalentId ParentLink { get; set; }

        /// <summary>
        /// Gets or sets the AbilityTalentTooltip object.
        /// </summary>
        public AbilityTalentTooltip Tooltip { get; set; } = new AbilityTalentTooltip();

        /// <summary>
        /// Gets a collection of created units.
        /// </summary>
        public IEnumerable<string> CreatedUnits => CreatedUnitList;

        public override bool Equals(object obj)
        {
            if (!(obj is AbilityTalentBase item))
                return false;

            return (item.AbilityTalentId.Id + item.Name + item.IconFileName + item.AbilityType).ToUpper().Equals((AbilityTalentId.Id + Name + IconFileName + AbilityType).ToUpper());
        }

        public override int GetHashCode()
        {
            return $"{AbilityTalentId.Id + Name + IconFileName + AbilityType}".ToUpper().GetHashCode();
        }

        /// <summary>
        /// Adds a value. Replaces if object already exists in collection.
        /// </summary>
        /// <param name="value"></param>
        public void AddCreatedUnit(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Argument cannot be null or empty", nameof(value));
            }

            CreatedUnitList.Add(value);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsCreatedUnit(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Argument cannot be null or empty", nameof(value));
            }

            return CreatedUnitList.Contains(value);
        }
    }
}
