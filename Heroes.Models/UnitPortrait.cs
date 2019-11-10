namespace Heroes.Models
{
    /// <summary>
    /// Contains the properties for a unit's portrait.
    /// </summary>
    public class UnitPortrait
    {
        /// <summary>
        /// Gets or sets the target info panel file name.
        /// </summary>
        public string TargetInfoPanelFileName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the minimap icon file name.
        /// </summary>
        public string MiniMapIconFileName { get; set; } = string.Empty;
    }
}
