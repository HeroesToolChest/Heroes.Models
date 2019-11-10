namespace Heroes.Models
{
    /// <summary>
    /// Specifies the basic attack type of the unit.
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// Indicates an unknown basic attack type.
        /// </summary>
        Unknown,

        /// <summary>
        /// Indicates a melee unit.
        /// </summary>
        Melee,

        /// <summary>
        /// Indicates a ranged unit.
        /// </summary>
        Ranged,
    }
}
