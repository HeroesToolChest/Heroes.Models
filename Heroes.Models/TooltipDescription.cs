namespace Heroes.Models
{
    public class TooltipDescription
    {
        /// <summary>
        /// Contructor.
        /// </summary>
        /// <param name="description">A parsed description that has yet to be validated.</param>
        public TooltipDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
                description = string.Empty;

            RawDescription = description;

            PlainText = DescriptionValidator.GetPlainText(description, false, false);
            PlainTextWithNewlines = DescriptionValidator.GetPlainText(description, true, false);
            PlainTextWithScaling = DescriptionValidator.GetPlainText(description, false, true);
            PlainTextWithScalingWithNewlines = DescriptionValidator.GetPlainText(description, true, true);

            ColoredText = DescriptionValidator.GetColoredText(description, false);
            ColoredTextWithScaling = DescriptionValidator.GetColoredText(description, true);
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
