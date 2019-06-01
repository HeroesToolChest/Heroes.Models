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
        /// Gets or sets the unique reference name id.
        /// </summary>
        public string ReferenceNameId { get; set; }

        /// <summary>
        /// Gets or sets the unique tooltip name id for the full tooltip.
        /// </summary>
        public string FullTooltipNameId { get; set; }

        /// <summary>
        /// Gets or sets the unique tooltip name id for the short tooltip.
        /// </summary>
        public string ShortTooltipNameId { get; set; }

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
        /// Gets or sets the value if the ability is passive.
        /// </summary>
        public bool IsPassive { get; set; }

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

            return ReferenceNameId.Equals(item.ReferenceNameId, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return ReferenceNameId.GetHashCode();
        }

        /// <summary>
        /// Adds a value. Replaces if object already exists in collection.
        /// </summary>
        /// <param name="value"></param>
        public void AddCreatedUnit(string value)
        {
            CreatedUnitList.Add(value);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsCreatedUnit(string value)
        {
            return CreatedUnitList.Contains(value);
        }
    }
}
