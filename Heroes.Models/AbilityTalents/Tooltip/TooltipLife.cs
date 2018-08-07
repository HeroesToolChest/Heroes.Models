namespace Heroes.Models.AbilityTalents.Tooltip
{
    public class TooltipLife
    {
        /// <summary>
        /// Gets or sets the health text.
        /// </summary>
        public TooltipDescription LifeCostText { get; set; }

        public override string ToString()
        {
            return LifeCostText.RawDescription;
        }
    }
}
