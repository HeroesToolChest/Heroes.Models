namespace Heroes.Models.AbilityTalents.Tooltip
{
    public class TooltipLife
    {
        /// <summary>
        /// Gets or sets the health text.
        /// </summary>
        public string LifeCostText { get; set; }

        /// <summary>
        /// Gets or sets if whether the life is a percentage cost.
        /// </summary>
        public bool IsLifePercentage { get; set; } = false;

        public override string ToString()
        {
            if (string.IsNullOrEmpty(LifeCostText))
                return string.Empty;
            else
                return $"Life: {LifeCostText}";
        }
    }
}
