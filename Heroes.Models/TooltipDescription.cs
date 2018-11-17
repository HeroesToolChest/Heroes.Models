namespace Heroes.Models
{
    public class TooltipDescription
    {
        private readonly Localization ScaleLocale = Localization.ENUS;

        /// <summary>
        /// Contructor.
        /// </summary>
        /// <param name="description">A parsed description that has yet to be validated.</param>
        /// <param name="scaleLocale">Locale for the per level string.</param>
        public TooltipDescription(string description, Localization scaleLocale = Localization.ENUS)
        {
            if (string.IsNullOrEmpty(description))
                description = string.Empty;

            RawDescription = description;
            ScaleLocale = scaleLocale;

            PlainText = DescriptionValidator.GetPlainText(description, false, false, ScaleLocale);
            PlainTextWithNewlines = DescriptionValidator.GetPlainText(description, true, false, ScaleLocale);
            PlainTextWithScaling = DescriptionValidator.GetPlainText(description, false, true, ScaleLocale);
            PlainTextWithScalingWithNewlines = DescriptionValidator.GetPlainText(description, true, true, ScaleLocale);

            ColoredText = DescriptionValidator.GetColoredText(description, false, ScaleLocale);
            ColoredTextWithScaling = DescriptionValidator.GetColoredText(description, true, ScaleLocale);
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

        public override string ToString()
        {
            return PlainTextWithScaling;
        }
    }
}
