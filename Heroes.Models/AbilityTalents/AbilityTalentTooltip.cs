using Heroes.Models.AbilityTalents.Tooltip;
using System;

namespace Heroes.Models.AbilityTalents
{
    public class AbilityTalentTooltip
    {
        /// <summary>
        /// Gets or sets the Energy properties.
        /// </summary>
        public TooltipEnergy Energy { get; set; } = new TooltipEnergy();

        /// <summary>
        /// Gets or sets the Life properties.
        /// </summary>
        public TooltipLife Life { get; set; } = new TooltipLife();

        /// <summary>
        /// Gets or sets the Cooldown properties.
        /// </summary>
        public TooltipCooldown Cooldown { get; set; } = new TooltipCooldown();

        /// <summary>
        /// Gets or sets the Charges properties.
        /// </summary>
        public TooltipCharges Charges { get; set; } = new TooltipCharges();

        /// <summary>
        /// Gets or sets the short tooltip.
        /// </summary>
        public TooltipDescription ShortTooltip { get; set; }

        /// <summary>
        /// Gets or sets the full tooltip.
        /// </summary>
        public TooltipDescription FullTooltip { get; set; }

        /// <summary>
        /// Returns a string of the ability/talent's cooldown, mana/life cost, and custom string.
        /// </summary>
        /// <returns></returns>
        public string GetTalentSubInfo()
        {
            string text = string.Empty;

            if (!string.IsNullOrEmpty(Energy.EnergyText))
            {
                text += $"{Energy.EnergyType.ToString()}: {Energy.EnergyText}";
            }

            if (!string.IsNullOrEmpty(Life.LifeCostText))
            {
                if (!string.IsNullOrEmpty(text))
                    text += Environment.NewLine;

                text += $"Health: {Life.LifeCostText}";
            }

            if (!string.IsNullOrEmpty(Cooldown.CooldownText))
            {
                if (!string.IsNullOrEmpty(text))
                    text += Environment.NewLine;

                text += $"Cooldown: {Cooldown.CooldownText}";
            }

            return text;
        }

        public override string ToString()
        {
            return ShortTooltip?.PlainTextWithScaling;
        }
    }
}
