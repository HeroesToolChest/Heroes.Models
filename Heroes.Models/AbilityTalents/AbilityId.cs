﻿namespace Heroes.Models.AbilityTalents
{
    public class AbilityId
    {
        /// <summary>
        /// Contructs an abilityTalentId.
        /// </summary>
        /// <param name="referenceId">The ability id.</param>
        /// <param name="buttonId">The button id.</param>
        public AbilityId(string referenceId, string buttonId)
        {
            ReferenceId = referenceId;
            ButtonId = buttonId;
        }

        /// <summary>
        /// Gets the unique id. This is equalivant to <see cref="ToString"/>.
        /// </summary>
        public string Id => ToString();

        /// <summary>
        /// Gets the reference id. This is usually the ability id.
        /// </summary>
        public string ReferenceId { get; }

        /// <summary>
        /// Gets the button id.
        /// </summary>
        public string ButtonId { get; }

        public static bool operator ==(AbilityId abilityTalentId1, AbilityId abilityTalentId2)
        {
            if (abilityTalentId1 is null)
            {
                return abilityTalentId2 is null;
            }

            return abilityTalentId1.Equals(abilityTalentId2);
        }

        public static bool operator !=(AbilityId abilityTalentId1, AbilityId abilityTalentId2)
        {
            if (abilityTalentId1 is null)
            {
                return abilityTalentId2 is null;
            }

            return !abilityTalentId1.Equals(abilityTalentId2);
        }

        public override string ToString()
        {
            return $"{ReferenceId}|{ButtonId}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is AbilityId item))
                return false;

            return item.Id.ToUpper().Equals(Id.ToUpper());
        }

        public override int GetHashCode()
        {
            return ToString().ToUpper().GetHashCode();
        }
    }
}
