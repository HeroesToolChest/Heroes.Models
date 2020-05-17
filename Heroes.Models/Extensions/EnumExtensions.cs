using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Heroes.Models.Extensions
{
    /// <summary>
    /// Static class for enum extension.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Returns the friendly name of the enum.
        /// </summary>
        /// <typeparam name="T">The type of the enumeration.</typeparam>
        /// <param name="enumerationValue">An enumeration value.</param>
        /// <returns>the value of the <see cref="DescriptionAttribute"/>.</returns>
        public static string GetFriendlyName<T>(this T enumerationValue)
            where T : Enum
        {
            Type type = enumerationValue.GetType();
            if (!type.GetTypeInfo().IsEnum)
            {
                throw new ArgumentException("Must be of Enum type", nameof(enumerationValue));
            }

            // Tries to find a DescriptionAttribute for a potential friendly name for the enum
            string? enumString = enumerationValue.ToString();
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
        /// <returns>the <typeparamref name="T"/>.</returns>
        public static T ConvertToEnum<T>(this string value)
            where T : struct, Enum
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

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
        /// <returns>true if the value was found; otherwise false.</returns>
        public static bool TryConvertToEnum<T>(this string value, out T result)
            where T : struct, Enum
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            value = new string(value.Where(c => !char.IsWhiteSpace(c)).ToArray());

            if (Enum.TryParse(value, true, out result))
                return true;
            else
                return false;
        }
    }
}
