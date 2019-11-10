using System;
using System.Collections.Generic;

namespace Heroes.Models.AbilityTalents
{
    /// <summary>
    /// Contains the information for talent data.
    /// </summary>
    public class Talent : AbilityTalentBase
    {
        private readonly HashSet<string> _abilityTalentLinkIdList = new HashSet<string>(StringComparer.Ordinal);
        private readonly HashSet<string> _prerequisiteTalentIdList = new HashSet<string>(StringComparer.Ordinal);

        /// <summary>
        /// Initializes a new instance of the <see cref="Talent"/> class.
        /// </summary>
        public Talent() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Talent"/> class.
        /// </summary>
        /// <param name="talentBase"></param>
        public Talent(AbilityTalentBase talentBase)
        {
            Name = talentBase.Name;
            IconFileName = talentBase.IconFileName;
            Tooltip = talentBase.Tooltip;
        }

        /// <summary>
        /// Gets or sets the tier of the talent.
        /// </summary>
        public TalentTier Tier { get; set; }

        /// <summary>
        /// Gets or sets the column number, also known as the sort index number.
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Gets a collection of ability and talent ids that the talent affects or upgrades.
        /// </summary>
        public IEnumerable<string> AbilityTalentLinkIds => _abilityTalentLinkIdList;

        /// <summary>
        /// Gets the amount of abilityTalentLinkIds.
        /// </summary>
        public int AbilityTalentLinkIdsCount => _abilityTalentLinkIdList.Count;

        /// <summary>
        /// Gets a collection of prerequisite talent ids.
        /// </summary>
        public IEnumerable<string> PrerequisiteTalentIds => _prerequisiteTalentIdList;

        /// <summary>
        /// Gets the amount of prerequisiteTalentIds.
        /// </summary>
        public int PrerequisiteTalentIdCount => _prerequisiteTalentIdList.Count;

        /// <summary>
        /// Determines if both objects are equal.
        /// </summary>
        /// <param name="talent1"></param>
        /// <param name="talent2"></param>
        /// <returns></returns>
        public static bool operator ==(Talent? talent1, Talent? talent2)
        {
            if (talent1 is null)
            {
                return talent2 is null;
            }

            return talent1.Equals(talent2);
        }

        /// <summary>
        /// Determines if both objects are not equal.
        /// </summary>
        /// <param name="talent1"></param>
        /// <param name="talent2"></param>
        /// <returns></returns>
        public static bool operator !=(Talent? talent1, Talent? talent2)
        {
            if (talent1 is null)
            {
                return !(talent2 is null);
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

            _abilityTalentLinkIdList.Add(value);
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

            return _abilityTalentLinkIdList.Remove(value);
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

            return _abilityTalentLinkIdList.Contains(value);
        }

        /// <summary>
        /// Removes all elements from the collection.
        /// </summary>
        public void ClearAbilityTalentLinkIds()
        {
            _abilityTalentLinkIdList.Clear();
        }

        /// <summary>
        /// Adds a prerequisite talent id.
        /// </summary>
        /// <param name="value"></param>
        public void AddPrerequisiteTalentId(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Argument cannot be null or empty.", nameof(value));
            }

            _prerequisiteTalentIdList.Add(value);
        }

        /// <summary>
        /// Removes a prerequisite talent id.
        /// </summary>
        /// <param name="value"></param>
        public bool RemovePrerequisiteTalentId(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Argument cannot be null or empty.", nameof(value));
            }

            return _prerequisiteTalentIdList.Remove(value);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsPrerequisiteTalentId(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Argument cannot be null or empty.", nameof(value));
            }

            return _prerequisiteTalentIdList.Contains(value);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (AbilityTalentId is null)
                return $"{Tier.GetFriendlyName()}";
            else
                return $"{Tier.GetFriendlyName()} | {AbilityTalentId.Id}";
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
