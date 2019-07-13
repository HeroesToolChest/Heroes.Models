using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Heroes.Models
{
    public class DescriptionValidator
    {
        private readonly int SmallSize = 51;
        private readonly int LargeSize = 501;
        private readonly Localization Localization = Localization.ENUS;
        private readonly string GameString;
        private readonly Stack<string> TextStack = new Stack<string>(101);

        private int Iterator = 0;

        private DescriptionValidator(string gameString, Localization scaleLocale = Localization.ENUS)
        {
            if (string.IsNullOrEmpty(gameString))
                gameString = string.Empty;

            Localization = scaleLocale;
            GameString = RemovedStartingRogueTags(gameString);
        }

        /// <summary>
        /// Takes a game string and removes unmatched and nested tags.
        /// </summary>
        /// <param name="gameString">The game string text.</param>
        /// <returns></returns>
        public static string Validate(string gameString)
        {
            return new DescriptionValidator(gameString).Validate();
        }

        /// <summary>
        /// Takes a game string and removes unmatched and nested tags.
        /// </summary>
        /// <param name="gameString">The game string text.</param>
        /// <param name="scaleLocale">Locale for the per level string.</param>
        /// <returns></returns>
        public static string Validate(string gameString, Localization scaleLocale)
        {
            return new DescriptionValidator(gameString, scaleLocale).Validate();
        }

        /// <summary>
        /// Returns a plain text string without any tags.
        /// </summary>
        /// <param name="gameString">The game string text.</param>
        /// <param name="includeNewLineTags">If true, includes the newline tags.</param>
        /// <param name="includeScaling">If true, includes the scaling info.</param>
        /// <param name="scaleLocale">Locale for the per level string.</param>
        /// <returns></returns>
        public static string GetPlainText(string gameString, bool includeNewLineTags, bool includeScaling, Localization scaleLocale = Localization.ENUS)
        {
            return new DescriptionValidator(gameString, scaleLocale).ParsePlainText(includeNewLineTags, includeScaling);
        }

        /// <summary>
        /// Returns the string with all tags.
        /// </summary>
        /// <param name="gameString">The game string text.</param>
        /// <param name="includeScaling">If true, includes the scaling info.</param>
        /// <param name="scaleLocale">Locale for the per level string.</param>
        /// <returns></returns>
        public static string GetColoredText(string gameString, bool includeScaling, Localization scaleLocale = Localization.ENUS)
        {
            return new DescriptionValidator(gameString, scaleLocale).ParseColoredText(includeScaling);
        }

        private static string ReplaceWhitespace(string input, string replacement)
        {
            return Regex.Replace(input, @"\s+", replacement);
        }

        private string Validate()
        {
            ValidateGameString(string.Empty);

            StringBuilder sb = new StringBuilder(LargeSize);

            if (TextStack.Count < 1)
                return string.Empty;

            string endTag = string.Empty;
            string firstItem = TextStack.Peek();

            // remove unmatched start tag
            if (firstItem.StartsWith("<") && firstItem.EndsWith(">") && !firstItem.EndsWith("/>") && !firstItem.StartsWith("</"))
                TextStack.Pop();

            // remove empty elements
            while (TextStack.Count > 0)
            {
                string item = TextStack.Pop();

                if (item.StartsWith("</") && item.EndsWith(">") && !item.EndsWith("/>")) // end tag
                {
                    endTag = item;
                    continue;
                }
                else if (item.StartsWith("<") && item.EndsWith(">") && !item.EndsWith("/>")) // check if start tag
                {
                    if (string.IsNullOrEmpty(endTag))
                    {
                        sb.Insert(0, item);
                        continue;
                    }
                    else // dont save, empty tag
                    {
                        endTag = string.Empty;
                        continue;
                    }
                }
                else if (!string.IsNullOrEmpty(endTag))
                {
                    sb.Insert(0, endTag);
                    endTag = string.Empty;
                }

                sb.Insert(0, item);
            }

            return sb.ToString();
        }

        // modifies game string, remove unmatched tags, nested tags
        private void ValidateGameString(string startTag)
        {
            StringBuilder sb = new StringBuilder(LargeSize);
            for (; Iterator < GameString.Length; Iterator++)
            {
                if (GameString[Iterator] == '<' && GameString[Iterator + 1] != ' ')
                {
                    if (sb.Length > 0)
                    {
                        TextStack.Push(sb.ToString());
                        sb = new StringBuilder(LargeSize);
                    }

                    if (TryParseTag(out string tag, out bool isStartTag))
                    {
                        if (isStartTag)
                        {
                            Iterator++;

                            // nested
                            if (!string.IsNullOrEmpty(startTag))
                                TextStack.Push(CreateEndTag(startTag));

                            TextStack.Push(tag);
                            ValidateGameString(tag);

                            if (!string.IsNullOrEmpty(startTag))
                                TextStack.Push(startTag);

                            continue;
                        }
                        else if (tag == "<n/>" || tag == "</n>") // line breakers
                        {
                            tag = "<n/>";

                            // nested
                            if (!string.IsNullOrEmpty(startTag))
                            {
                                TextStack.Push(CreateEndTag(startTag));
                                TextStack.Push(tag);
                                TextStack.Push(startTag);
                            }
                            else
                            {
                                TextStack.Push(tag);
                            }

                            continue;
                        }
                        else // end tag
                        {
                            if (MatchElement(startTag, tag))
                            {
                                if (TextStack.Peek() != startTag)
                                    TextStack.Push(tag);
                                else
                                    TextStack.Pop();
                                return;
                            }
                            else if (tag.Length > 4 && tag.EndsWith("/>")) // self close tag
                            {
                                TextStack.Push(tag);
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }

                if (Iterator >= GameString.Length)
                    break;

                sb.Append(GameString[Iterator]);
            }

            if (sb.Length > 0)
            {
                if (TextStack.Count > 0 && TextStack.Peek() == startTag)
                    TextStack.Pop();

                TextStack.Push(sb.ToString());
            }
        }

        // removes all tags
        private string ParsePlainText(bool includeNewlineTags, bool includeScaling)
        {
            StringBuilder sb = new StringBuilder(LargeSize);
            for (; Iterator < GameString.Length; Iterator++)
            {
                if (GameString[Iterator] == '<')
                {
                    if (sb.Length > 0)
                    {
                        TextStack.Push(sb.ToString());
                        sb = new StringBuilder(LargeSize);
                    }

                    if (TryParseTag(out string tag, out _))
                    {
                        if (tag == "<n/>")
                        {
                            if (includeNewlineTags)
                                TextStack.Push(tag);
                            else
                                TextStack.Push(" ");
                        }

                        continue;
                    }
                }
                else if (GameString[Iterator] == '~' && Iterator + 1 < GameString.Length && GameString[Iterator + 1] == '~')
                {
                    TextStack.Push(sb.ToString());
                    sb = new StringBuilder(LargeSize);

                    if (ParseScalingTag(out string scaleText, includeScaling))
                    {
                        TextStack.Push(scaleText);
                    }

                    continue;
                }

                if (Iterator >= GameString.Length)
                    break;

                sb.Append(GameString[Iterator]);
            }

            if (sb.Length > 0)
                TextStack.Push(sb.ToString());

            sb = new StringBuilder(LargeSize);

            while (TextStack.Count > 0)
            {
                sb.Insert(0, TextStack.Pop());
            }

            return sb.ToString().Trim();
        }

        // keeps colored tags and new lines
        private string ParseColoredText(bool includeScaling)
        {
            StringBuilder sb = new StringBuilder(SmallSize);
            for (; Iterator < GameString.Length; Iterator++)
            {
                if (GameString[Iterator] == '<')
                {
                    if (sb.Length > 0)
                    {
                        TextStack.Push(sb.ToString());
                        sb = new StringBuilder(SmallSize);
                    }

                    if (TryParseTag(out string tag, out _))
                    {
                        TextStack.Push(tag);

                        continue;
                    }
                }
                else if (GameString[Iterator] == '~' && Iterator + 1 < GameString.Length && GameString[Iterator + 1] == '~')
                {
                    TextStack.Push(sb.ToString());
                    sb = new StringBuilder(SmallSize);

                    if (ParseScalingTag(out string scaleText, includeScaling))
                    {
                        TextStack.Push(scaleText);
                    }

                    continue;
                }

                if (Iterator >= GameString.Length)
                    break;

                sb.Append(GameString[Iterator]);
            }

            if (sb.Length > 0)
                TextStack.Push(sb.ToString());

            sb = new StringBuilder(SmallSize);

            while (TextStack.Count > 0)
            {
                sb.Insert(0, TextStack.Pop());
            }

            return sb.ToString().Trim();
        }

        // checks if the end tag matches the start tag
        private bool MatchElement(ReadOnlySpan<char> startTag, ReadOnlySpan<char> endTag)
        {
            if (startTag.IsEmpty)
                return false;

            ReadOnlySpan<char> endTagSpan = endTag.TrimEnd('>').TrimStart('<').TrimStart('/');
            ReadOnlySpan<char> firstPart;

            int spaceIndex = startTag.IndexOf(' ');

            if (spaceIndex > -1)
                firstPart = startTag.Slice(0, spaceIndex).TrimStart('<');
            else
                firstPart = startTag.TrimStart('<');

            return firstPart.SequenceEqual(endTagSpan);
        }

        // get whole tag, determine if it's a start tag
        private bool TryParseTag(out string tag, out bool isStartTag)
        {
            StringBuilder sb = new StringBuilder(SmallSize);
            for (; Iterator < GameString.Length; Iterator++)
            {
                sb.Append(GameString[Iterator]);
                if (GameString[Iterator] == '>')
                {
                    string[] parts = sb.ToString().Split(new char[] { ' ' }, 2);
                    if (parts.Length > 1)
                        tag = $"{parts[0].ToLower()} {parts[1]}";
                    else if (parts.Length == 1)
                        tag = parts[0].ToLower();
                    else
                        tag = sb.ToString();

                    // check if its a start tag
                    if (tag[1] != '/' && tag[tag.Length - 2] != '/')
                        isStartTag = true;
                    else
                        isStartTag = false;

                    tag = ReplaceWhitespace(tag, " ");
                    return true;
                }
            }

            isStartTag = false;
            tag = sb.ToString().ToLower();
            tag = ReplaceWhitespace(tag, " ");

            return false;
        }

        private string CreateEndTag(ReadOnlySpan<char> startTag)
        {
            startTag = startTag.TrimStart('<');
            int spaceDelimeter = startTag.IndexOf(' ');

            if (spaceDelimeter > 0)
            {
                ReadOnlySpan<char> firstPart = startTag.Slice(0, spaceDelimeter);
                return "</" + firstPart.ToString().ToLower() + ">";
            }
            else
            {
                return "</" + startTag.ToString().ToLower();
            }
        }

        /// <summary>
        /// Parse the scaling tag, removes the tag or replaces it.
        /// </summary>
        /// <param name="scaleText"></param>
        /// <param name="replace">If true, replace the tag, else return an empty string.</param>
        private bool ParseScalingTag(out string scaleText, bool replace)
        {
            int tagCount = 0;
            StringBuilder sb = new StringBuilder(SmallSize);

            for (; Iterator < GameString.Length; Iterator++)
            {
                if (GameString[Iterator] == '~')
                    tagCount++;
                else
                    sb.Append(GameString[Iterator]);

                if (tagCount == 4)
                {
                    if (replace)
                    {
                        scaleText = $" ({GetPerLevelLocale(double.Parse(sb.ToString(), CultureInfo.InvariantCulture) * 100)})";
                        return true;
                    }
                    else
                    {
                        scaleText = string.Empty;
                        return true;
                    }
                }
            }

            scaleText = string.Empty;
            return false;
        }

        private string RemovedStartingRogueTags(string gameString)
        {
            if (gameString.StartsWith("<li/>"))
                gameString = gameString.Remove(0, 5);

            return gameString;
        }

        private string GetPerLevelLocale(double value)
        {
            if (Localization == Localization.DEDE)
                return $"+{value}% pro Stufe";
            else if (Localization == Localization.ENUS)
                return $"+{value}% per level";
            else if (Localization == Localization.ESES)
                return $"+{value}% por nivel";
            else if (Localization == Localization.ESMX)
                return $"+{value}% por nivel";
            else if (Localization == Localization.FRFR)
                return $"+{value}% par niveau";
            else if (Localization == Localization.ITIT)
                return $"+{value}% per livello";
            else if (Localization == Localization.KOKR)
                return $"레벨 당 +{value}%";
            else if (Localization == Localization.PLPL)
                return $"+{value}% na poziom";
            else if (Localization == Localization.PTBR)
                return $"+{value}% por nível";
            else if (Localization == Localization.RURU)
                return $"+{value}% за уровень";
            else if (Localization == Localization.ZHCN)
                return $"每级 +{value}%";
            else if (Localization == Localization.ZHTW)
                return $"每級 +{value}%";
            else
                return $"{value}% per level";
        }
    }
}
