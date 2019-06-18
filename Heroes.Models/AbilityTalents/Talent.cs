using System;
using System.Collections.Generic;

namespace Heroes.Models.AbilityTalents
{
    public class Talent : AbilityTalentBase
    {
        private readonly HashSet<string> AbilityTalentLinkIdList = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public Talent() { }

        public Talent(AbilityTalentBase talentBase)
        {
            Name = talentBase.Name;
            IconFileName = talentBase.IconFileName;
            Tooltip = talentBase.Tooltip;
        }

        /// <summary>
        /// Gets the talent id.
        /// </summary>
        public string TalentId { get; set; }

        /// <summary>
        /// Gets the button id.
        /// </summary>
        public string ButtonId { get; set; }

        /// <summary>
        /// Gets or sets the tier of the talent.
        /// </summary>
        public TalentTier Tier { get; set; }

        /// <summary>
        /// Gets or sets the column number, also known as the sort index number.
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Gets the ability and talents that the talent affects or upgrades.
        /// </summary>
        public IEnumerable<string> AbilityTalentLinkIds => AbilityTalentLinkIdList;

        /// <summary>
        /// Gets the amount of abilityTalentLinkIds.
        /// </summary>
        public int AbilityTalentLinkIdsCount => AbilityTalentLinkIdList.Count;

        public static bool operator ==(Talent talent1, Talent talent2)
        {
            if (talent1 is null)
            {
                return talent2 is null;
            }

            return talent1.Equals(talent2);
        }

        public static bool operator !=(Talent talent1, Talent talent2)
        {
            if (talent1 is null)
            {
                return talent2 is null;
            }

            return !talent1.Equals(talent2);
        }

        /// <summary>
        /// Adds an abilityTalentLinkId.
        /// </summary>
        /// <param name="value"></param>
        public void AddAbilityTalentLinkId(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Argument cannot be null or empty.", nameof(value));
            }

            AbilityTalentLinkIdList.Add(value);
        }

        /// <summary>
        /// Removes an abilityTalentLinkId.
        /// </summary>
        /// <param name="value"></param>
        public bool RemoveAbilityTalentLinkId(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Argument cannot be null or empty.", nameof(value));
            }

            return AbilityTalentLinkIdList.Remove(value);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsAbilityTalentLinkId(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Argument cannot be null or empty.", nameof(value));
            }

            return AbilityTalentLinkIdList.Contains(value);
        }

        /// <summary>
        /// Removes all elements from the collection.
        /// </summary>
        public void ClearAbilityTalentLinkIds()
        {
            AbilityTalentLinkIdList.Clear();
        }

        public override string ToString() => $"{Tier.GetFriendlyName()} | {TalentId} | {ButtonId}";

        public override bool Equals(object obj)
        {
            if (!(obj is Talent item))
                return false;

            return $"{item.TalentId + item.ButtonId + item.IconFileName + item.AbilityType}".ToUpper().Equals($"{TalentId + ButtonId + IconFileName + AbilityType}".ToUpper());
        }

        public override int GetHashCode()
        {
            return $"{TalentId + ButtonId + IconFileName + AbilityType}".ToUpper().GetHashCode();
        }
    }
}
