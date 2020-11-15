using System;
using System.Diagnostics.CodeAnalysis;

namespace Heroes.Models
{
    /// <summary>
    /// Contains the information for tooltip descriptions which are automatically validated and provide multiple verbiage.
    /// </summary>
    public class TooltipDescription : IEquatable<TooltipDescription>
    {
        /// <summary>
        /// The error tag string.
        /// </summary>
        public const string ErrorTag = "##ERROR##";

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
        /// <param name="description">A parsed description that has not been modified into a readable verbiage. Description does not have to be pre-validated.</param>
        /// <param name="scaleLocale">The <see cref="Localization"/> for the scale text.</param>
        public TooltipDescription(string? description, Localization scaleLocale = Localization.ENUS)
        {
            if (string.IsNullOrEmpty(description))
                description = string.Empty;

            ScaleLocale = scaleLocale;

            RawDescription = DescriptionValidator.Validate(description);

            _plainText = new Lazy<string>(DescriptionValidator.GetPlainText(RawDescription, false, false, ScaleLocale));
            _plainTextWithNewlines = new Lazy<string>(DescriptionValidator.GetPlainText(RawDescription, true, false, ScaleLocale));
            _plainTextWithScaling = new Lazy<string>(DescriptionValidator.GetPlainText(RawDescription, false, true, ScaleLocale));
            _plainTextWithScalingWithNewlines = new Lazy<string>(DescriptionValidator.GetPlainText(RawDescription, true, true, ScaleLocale));

            _coloredText = new Lazy<string>(DescriptionValidator.GetColoredText(RawDescription, false, ScaleLocale));
            _coloredTextWithScaling = new Lazy<string>(DescriptionValidator.GetColoredText(RawDescription, true, ScaleLocale));

            _hasErrorTag = new Lazy<bool>(value: RawDescription.Contains(ErrorTag, StringComparison.Ordinal));
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

        /// <summary>
        /// Gets the <see cref="Localization"/> used for the scale text.
        /// </summary>
        public Localization ScaleLocale { get; } = Localization.ENUS;

        /// <summary>
        /// Compares the <paramref name="left"/> value to the <paramref name="right"/> value and determines if they are equal.
        /// </summary>
        /// <param name="left">The left hand side of the operator.</param>
        /// <param name="right">The right hand side of the operator.</param>
        /// <returns><see langword="true"/> if the <paramref name="left"/> value is equal to the <paramref name="right"/> value; otherwise <see langword="false"/>.</returns>
        public static bool operator ==(TooltipDescription? left, TooltipDescription? right)
        {
            if (left is null)
                return right is null;
            return left.Equals(right);
        }

        /// <summary>
        /// Compares the <paramref name="left"/> value to the <paramref name="right"/> value and determines if they are not equal.
        /// </summary>
        /// <param name="left">The left hand side of the operator.</param>
        /// <param name="right">The right hand side of the operator.</param>
        /// <returns><see langword="true"/> if the <paramref name="left"/> value is not equal to the <paramref name="right"/> value; otherwise <see langword="false"/>.</returns>
        public static bool operator !=(TooltipDescription? left, TooltipDescription? right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            if (obj is null)
                return false;

            if (obj is not TooltipDescription tooltipDescription)
                return false;
            else
                return Equals(tooltipDescription);
        }

        /// <inheritdoc/>
        public bool Equals([AllowNull] TooltipDescription other)
        {
            if (other is null)
                return false;

            return other.RawDescription.Equals(RawDescription, StringComparison.Ordinal) && other.ScaleLocale == ScaleLocale;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(RawDescription, ScaleLocale);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return PlainTextWithScaling;
        }
    }
}
