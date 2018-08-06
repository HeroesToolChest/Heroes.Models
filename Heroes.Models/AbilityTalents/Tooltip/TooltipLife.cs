namespace Heroes.Models.AbilityTalents.Tooltip
{
    public class TooltipLife
    {
        /// <summary>
        /// Gets or sets the health text.
        /// </summary>
        public string LifeCostText { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(LifeCostText))
                return string.Empty;
            else
                return $"Life: {LifeCostText}";
        }
    }
}
