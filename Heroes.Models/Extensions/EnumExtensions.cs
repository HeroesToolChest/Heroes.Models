using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("HeroesData")]
[assembly: InternalsVisibleTo("Heroes.Models.Tests")]

namespace Heroes.Models.Extensions;

/// <summary>
/// Static class for enum extension.
/// </summary>
internal static class EnumExtensions
{
    /// <summary>
    /// Returns the friendly name of the enum.
    /// </summary>
    /// <typeparam name="T">The type of the enumeration.</typeparam>
    /// <param name="enumerationValue">An enumeration value.</param>
    /// <returns>The value of the <see cref="DescriptionAttribute"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="enumerationValue"/> is not of <typeparamref name="T"/> type or is <see langword="null"/>.</exception>
    public static string GetFriendlyName<T>(this T enumerationValue)
        where T : Enum
    {
        Type type = enumerationValue.GetType();
        if (!type.GetTypeInfo().IsEnum)
        {
            throw new ArgumentException("Must be of Enum type", nameof(enumerationValue));
        }

        // Tries to find a DescriptionAttribute for a potential friendly name for the enum
        string enumString = enumerationValue.ToString();
        if (enumString is null)
            throw new ArgumentException("Cannot be null", nameof(enumerationValue));

        MemberInfo[] memberInfo = type.GetMember(enumString);
        if (memberInfo != null && memberInfo.Length > 0)
        {
            object[] attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return ((DescriptionAttribute)attributes[0]).Description;
            }
        }

        return enumString;
    }

    /// <summary>
    /// Convert the string to an enumeration type.
    /// </summary>
    /// <typeparam name="T">The enumeration type to be converted to.</typeparam>
    /// <param name="value">The string to be converted.</param>
    /// <returns>The <typeparamref name="T"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="value"/> is <see langword="null"/> or whitespace.</exception>
    public static T ConvertToEnum<T>(this string value)
        where T : struct, Enum
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));

        value = new string(value.Where(c => !char.IsWhiteSpace(c)).ToArray());

        if (Enum.TryParse(value, true, out T replayParseResultEnum))
            return replayParseResultEnum;
        else
            throw new ArgumentException($"parameter {value} not found");
    }

    /// <summary>
    /// Convert the string to an enumeration type.
    /// </summary>
    /// <typeparam name="T">The enumeration type to be converted to.</typeparam>
    /// <param name="value">The string to be converted.</param>
    /// <param name="result">When this method returns, contains the <typeparamref name="T"/>.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="value"/> is <see langword="null"/> or whitespace.</exception>
    public static bool TryConvertToEnum<T>(this string value, out T result)
        where T : struct, Enum
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));

        value = new string(value.Where(c => !char.IsWhiteSpace(c)).ToArray());

        if (Enum.TryParse(value, true, out result))
            return true;
        else
            return false;
    }
}
