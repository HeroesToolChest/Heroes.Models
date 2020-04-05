using System;

namespace Heroes.Models
{
    /// <summary>
    /// Contains the information for tooltip descriptions which are automatically validated and provide multiple verbiage.
    /// </summary>
    public class TooltipDescription
    {
        private readonly Localization _scaleLocale = Localization.ENUS;

        /// <summary>
        /// Initializes a new instance of the <see cref="TooltipDescription"/> class.
        /// </summary>
        /// <param name="description">A parsed description that not modified into a readable verbiage. Description does not have to be pre-validated.</param>
        /// <param name="scaleLocale">Locale for the per level string.</param>
        public TooltipDescription(string description, Localization scaleLocale = Localization.ENUS)
        {
            if (string.IsNullOrEmpty(description))
                description = string.Empty;

            _scaleLocale = scaleLocale;

            RawDescription = DescriptionValidator.Validate(description);

            PlainText = DescriptionValidator.GetPlainText(RawDescription, false, false, _scaleLocale);
            PlainTextWithNewlines = DescriptionValidator.GetPlainText(RawDescription, true, false, _scaleLocale);
            PlainTextWithScaling = DescriptionValidator.GetPlainText(RawDescription, false, true, _scaleLocale);
            PlainTextWithScalingWithNewlines = DescriptionValidator.GetPlainText(RawDescription, true, true, _scaleLocale);

            ColoredText = DescriptionValidator.GetColoredText(RawDescription, false, _scaleLocale);
            ColoredTextWithScaling = DescriptionValidator.GetColoredText(RawDescription, true, _scaleLocale);
        }

        /// <summary>
        /// <para>Gets the raw validated description. Unmatched tags have been removed and nested tag have been modified into unnested tags.</para>
        /// <para>Contains the color tags &lt;c val=\"#TooltipNumbers\"&gt;&lt;/c&gt;, scaling data ~~x~~, and newlines &lt;n/&gt;. It can also contain error tags ##ERROR##.</para>
        /// <para>
        /// Example:<br/>
        /// Fires a laser that deals &lt;c val=\"#TooltipNumbers\"&gt;200~~0.04~~&lt;/c&gt; damage.&lt;n/&gt;Does not affect minions.
        /// </para>
        /// </summary>
        public string RawDescription { get; }

        /// <summary>
        /// <para>Gets the validated description with text only.</para>
        /// <para>No color tags, scaling info, or newlines. Newlines are replaced with a double space.</para>
        /// <para>
        /// Example:<br/>
        /// Fires a laser that deals 200 damage.  Does not affect minions.
        /// </para>
        /// </summary>
        public string PlainText { get; }

        /// <summary>
        /// <para>Gets the validated description with text only.</para>
        /// <para>Same as <see cref="PlainText"/> but contains newlines.</para>
        /// <para>
        /// Example:<br/>
        /// Fires a laser that deals 200 damage.&lt;n/&gt;Does not affect minions.
        /// </para>
        /// </summary>
        public string PlainTextWithNewlines { get; }

        /// <summary>
        /// <para>Gets the validated description with text only.</para>
        /// <para>Same as <see cref="PlainText"/> but contains the scaling info (+x% per level).</para>
        /// <para>
        /// Example:<br/>
        /// Fires a laser that deals 200 (+4% per level) damage.  Does not affect minions.
        /// </para>
        /// </summary>
        public string PlainTextWithScaling { get; }

        /// <summary>
        /// <para>Gets the validated description with text only.</para>
        /// <para>Same as <see cref="PlainTextWithScaling"/> but contains the newlines.</para>
        /// <para>
        /// Example:<br/>
        /// Fires a laser that deals 200 (+4% per level) damage.&lt;n/&gt;Does not affect minions.
        /// </para>
        /// </summary>
        public string PlainTextWithScalingWithNewlines { get; }

        /// <summary>
        /// <para>Gets the validated description with colored tags and new lines, when parsed this is what appears ingame for tooltip.</para>
        /// <para>
        /// Example:<br/>
        /// Fires a laser that deals &lt;c val=\"#TooltipNumbers\"&gt;200&lt;/c&gt; damage.&lt;n/&gt;Does not affect minions.
        /// </para>
        /// </summary>
        public string ColoredText { get; }

        /// <summary>
        /// <para>Gets the validated description with colored tags, newlines, and scaling info.</para>
        /// <para>Same as <see cref="ColoredText"/> but contains the scaling info (+x% per level).</para>
        /// <para>
        /// Example:<br/>
        /// Fires a laser that deals &lt;c val=\"#TooltipNumbers\"&gt;200 (+4% per level)&lt;/c&gt; damage.&lt;n/&gt;Does not affect minions.
        /// </para>
        /// </summary>
        public string ColoredTextWithScaling { get; }

        /// <summary>
        /// Gets a value indicating whether the raw description contains an error tag.
        /// </summary>
        public bool HasErrorTag => RawDescription.Contains("##ERROR##", StringComparison.Ordinal);

        /// <inheritdoc/>
        public override string ToString()
        {
            return PlainTextWithScaling;
        }
    }
}
