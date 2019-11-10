﻿namespace Heroes.Models
{
    /// <summary>
    /// Represents the base class for type value pairs data.
    /// </summary>
    public abstract class TypeValue
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public double Value { get; set; }
    }
}
