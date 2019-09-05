namespace Heroes.Models.AbilityTalents.Tooltip
{
    public class TooltipLife
    {
        /// <summary>
        /// Gets or sets the health text.
        /// </summary>
        public TooltipDescription? LifeCostTooltip { get; set; }

        /// <summary>
        /// Gets or sets the life value.
        /// </summary>
        public double? LifeValue { get; set; }

        public override string? ToString()
        {
            return LifeCostTooltip?.RawDescription;
        }
    }
}
