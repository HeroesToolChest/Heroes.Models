namespace Heroes.Models
{
    /// <summary>
    /// Contains the information for tooltip descriptions.
    /// </summary>
    public class TooltipDescription
    {
        private readonly Localization _scaleLocale = Localization.ENUS;

        /// <summary>
        /// Initializes a new instance of the <see cref="TooltipDescription"/> class.
        /// </summary>
        /// <param name="description">A parsed description that has yet to be validated.</param>
        /// <param name="scaleLocale">Locale for the per level string.</param>
        public TooltipDescription(string description, Localization scaleLocale = Localization.ENUS)
        {
            if (string.IsNullOrEmpty(description))
                description = string.Empty;

            RawDescription = description;
            _scaleLocale = scaleLocale;

            PlainText = DescriptionValidator.GetPlainText(description, false, false, _scaleLocale);
            PlainTextWithNewlines = DescriptionValidator.GetPlainText(description, true, false, _scaleLocale);
            PlainTextWithScaling = DescriptionValidator.GetPlainText(description, false, true, _scaleLocale);
            PlainTextWithScalingWithNewlines = DescriptionValidator.GetPlainText(description, true, true, _scaleLocale);

            ColoredText = DescriptionValidator.GetColoredText(description, false, _scaleLocale);
            ColoredTextWithScaling = DescriptionValidator.GetColoredText(description, true, _scaleLocale);
        }

        /// <summary>
        /// Gets the raw parsed description.
        /// </summary>
        public string RawDescription { get; }

        /// <summary>
        /// Gets the description with text only.
        /// No scaling info or color tags.
        /// Newlines are replaced with spaces.
        /// </summary>
        public string PlainText { get; }

        /// <summary>
        /// Gets the description with text only.
        /// No scaling info or color tags.
        /// </summary>
        public string PlainTextWithNewlines { get; }

        /// <summary>
        /// Gets the description with text only.
        /// No color tags.
        /// Newlines are replaced with spaces.
        /// </summary>
        public string PlainTextWithScaling { get; }

        /// <summary>
        /// Gets the description with text only.
        /// No color tags.
        /// </summary>
        public string PlainTextWithScalingWithNewlines { get; }

        /// <summary>
        /// Gets the description with colored tags and new lines.
        /// No scaling info.
        /// </summary>
        public string ColoredText { get; }

        /// <summary>
        /// Gets the description with colored tags, newlines, and scaling info.
        /// </summary>
        public string ColoredTextWithScaling { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return PlainTextWithScaling;
        }
    }
}
