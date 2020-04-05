using System;

namespace Heroes.Models
{
    /// <summary>
    /// Contains the information for tooltip descriptions which are automatically validated and provide multiple verbiage.
    /// </summary>
    public class TooltipDescription
    {
        private const string _errorTag = "##ERROR##";

        private readonly Localization _scaleLocale = Localization.ENUS;

        private readonly Lazy<string> _plainText;
        private readonly Lazy<string> _plainTextWithNewlines;
        private readonly Lazy<string> _plainTextWithScaling;
        private readonly Lazy<string> _plainTextWithScalingWithNewlines;
        private readonly Lazy<string> _coloredText;
        private readonly Lazy<string> _coloredTextWithScaling;

        private readonly Lazy<bool> _hasErrorTag;

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

            _plainText = new Lazy<string>(DescriptionValidator.GetPlainText(RawDescription, false, false, _scaleLocale));
            _plainTextWithNewlines = new Lazy<string>(DescriptionValidator.GetPlainText(RawDescription, true, false, _scaleLocale));
            _plainTextWithScaling = new Lazy<string>(DescriptionValidator.GetPlainText(RawDescription, false, true, _scaleLocale));
            _plainTextWithScalingWithNewlines = new Lazy<string>(DescriptionValidator.GetPlainText(RawDescription, true, true, _scaleLocale));

            _coloredText = new Lazy<string>(DescriptionValidator.GetColoredText(RawDescription, false, _scaleLocale));
            _coloredTextWithScaling = new Lazy<string>(DescriptionValidator.GetColoredText(RawDescription, true, _scaleLocale));

            _hasErrorTag = new Lazy<bool>(value: RawDescription.Contains(_errorTag, StringComparison.Ordinal));
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
        public string PlainText => _plainText.Value;

        /// <summary>
        /// <para>Gets the validated description with text only.</para>
        /// <para>Same as <see cref="PlainText"/> but contains newlines.</para>
        /// <para>
        /// Example:<br/>
        /// Fires a laser that deals 200 damage.&lt;n/&gt;Does not affect minions.
        /// </para>
        /// </summary>
        public string PlainTextWithNewlines => _plainTextWithNewlines.Value;

        /// <summary>
        /// <para>Gets the validated description with text only.</para>
        /// <para>Same as <see cref="PlainText"/> but contains the scaling info (+x% per level).</para>
        /// <para>
        /// Example:<br/>
        /// Fires a laser that deals 200 (+4% per level) damage.  Does not affect minions.
        /// </para>
        /// </summary>
        public string PlainTextWithScaling => _plainTextWithScaling.Value;

        /// <summary>
        /// <para>Gets the validated description with text only.</para>
        /// <para>Same as <see cref="PlainTextWithScaling"/> but contains the newlines.</para>
        /// <para>
        /// Example:<br/>
        /// Fires a laser that deals 200 (+4% per level) damage.&lt;n/&gt;Does not affect minions.
        /// </para>
        /// </summary>
        public string PlainTextWithScalingWithNewlines => _plainTextWithScalingWithNewlines.Value;

        /// <summary>
        /// <para>Gets the validated description with colored tags and new lines, when parsed this is what appears ingame for tooltip.</para>
        /// <para>
        /// Example:<br/>
        /// Fires a laser that deals &lt;c val=\"#TooltipNumbers\"&gt;200&lt;/c&gt; damage.&lt;n/&gt;Does not affect minions.
        /// </para>
        /// </summary>
        public string ColoredText => _coloredText.Value;

        /// <summary>
        /// <para>Gets the validated description with colored tags, newlines, and scaling info.</para>
        /// <para>Same as <see cref="ColoredText"/> but contains the scaling info (+x% per level).</para>
        /// <para>
        /// Example:<br/>
        /// Fires a laser that deals &lt;c val=\"#TooltipNumbers\"&gt;200 (+4% per level)&lt;/c&gt; damage.&lt;n/&gt;Does not affect minions.
        /// </para>
        /// </summary>
        public string ColoredTextWithScaling => _coloredTextWithScaling.Value;

        /// <summary>
        /// Gets a value indicating whether the raw description contains an error tag.
        /// </summary>
        public bool HasErrorTag => _hasErrorTag.Value;

        /// <inheritdoc/>
        public override string ToString()
        {
            return PlainTextWithScaling;
        }
    }
}
