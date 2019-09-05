using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Heroes.Models
{
    public class DescriptionValidator
    {
        private readonly int _smallSize = 51;
        private readonly int _largeSize = 501;
        private readonly Localization _localization = Localization.ENUS;
        private readonly string _gameString;
        private readonly Stack<string> _textStack = new Stack<string>(101);

        private int _iterator = 0;

        private DescriptionValidator(string gameString, Localization scaleLocale = Localization.ENUS)
        {
            if (string.IsNullOrEmpty(gameString))
                gameString = string.Empty;

            _localization = scaleLocale;
            _gameString = RemovedStartingRogueTags(gameString);
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

            StringBuilder sb = new StringBuilder(_largeSize);

            if (_textStack.Count < 1)
                return string.Empty;

            string endTag = string.Empty;
            string firstItem = _textStack.Peek();

            // remove unmatched start tag
            if (firstItem.StartsWith("<") && firstItem.EndsWith(">") && !firstItem.EndsWith("/>") && !firstItem.StartsWith("</"))
                _textStack.Pop();

            // remove empty elements
            while (_textStack.Count > 0)
            {
                string item = _textStack.Pop();

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
            StringBuilder sb = new StringBuilder(_largeSize);
            for (; _iterator < _gameString.Length; _iterator++)
            {
                if (_gameString[_iterator] == '<' && _gameString[_iterator + 1] != ' ')
                {
                    if (sb.Length > 0)
                    {
                        _textStack.Push(sb.ToString());
                        sb = new StringBuilder(_largeSize);
                    }

                    if (TryParseTag(out string tag, out bool isStartTag))
                    {
                        if (isStartTag)
                        {
                            _iterator++;

                            // nested
                            if (!string.IsNullOrEmpty(startTag))
                                _textStack.Push(CreateEndTag(startTag));

                            _textStack.Push(tag);
                            ValidateGameString(tag);

                            if (!string.IsNullOrEmpty(startTag))
                                _textStack.Push(startTag);

                            continue;
                        }
                        else if (tag == "<n/>" || tag == "</n>") // line breakers
                        {
                            tag = "<n/>";

                            // nested
                            if (!string.IsNullOrEmpty(startTag))
                            {
                                _textStack.Push(CreateEndTag(startTag));
                                _textStack.Push(tag);
                                _textStack.Push(startTag);
                            }
                            else
                            {
                                _textStack.Push(tag);
                            }

                            continue;
                        }
                        else // end tag
                        {
                            if (MatchElement(startTag, tag))
                            {
                                if (_textStack.Peek() != startTag)
                                    _textStack.Push(tag);
                                else
                                    _textStack.Pop();
                                return;
                            }
                            else if (tag.Length > 4 && tag.EndsWith("/>")) // self close tag
                            {
                                _textStack.Push(tag);
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }

                if (_iterator >= _gameString.Length)
                    break;

                sb.Append(_gameString[_iterator]);
            }

            if (sb.Length > 0)
            {
                if (_textStack.Count > 0 && _textStack.Peek() == startTag)
                    _textStack.Pop();

                _textStack.Push(sb.ToString());
            }
        }

        // removes all tags
        private string ParsePlainText(bool includeNewlineTags, bool includeScaling)
        {
            StringBuilder sb = new StringBuilder(_largeSize);
            for (; _iterator < _gameString.Length; _iterator++)
            {
                if (_gameString[_iterator] == '<')
                {
                    if (sb.Length > 0)
                    {
                        _textStack.Push(sb.ToString());
                        sb = new StringBuilder(_largeSize);
                    }

                    if (TryParseTag(out string tag, out _))
                    {
                        if (tag == "<n/>")
                        {
                            if (includeNewlineTags)
                                _textStack.Push(tag);
                            else
                                _textStack.Push(" ");
                        }

                        continue;
                    }
                }
                else if (_gameString[_iterator] == '~' && _iterator + 1 < _gameString.Length && _gameString[_iterator + 1] == '~')
                {
                    _textStack.Push(sb.ToString());
                    sb = new StringBuilder(_largeSize);

                    if (ParseScalingTag(out string scaleText, includeScaling))
                    {
                        _textStack.Push(scaleText);
                    }

                    continue;
                }

                if (_iterator >= _gameString.Length)
                    break;

                sb.Append(_gameString[_iterator]);
            }

            if (sb.Length > 0)
                _textStack.Push(sb.ToString());

            sb = new StringBuilder(_largeSize);

            while (_textStack.Count > 0)
            {
                sb.Insert(0, _textStack.Pop());
            }

            return sb.ToString().Trim();
        }

        // keeps colored tags and new lines
        private string ParseColoredText(bool includeScaling)
        {
            StringBuilder sb = new StringBuilder(_smallSize);
            for (; _iterator < _gameString.Length; _iterator++)
            {
                if (_gameString[_iterator] == '<')
                {
                    if (sb.Length > 0)
                    {
                        _textStack.Push(sb.ToString());
                        sb = new StringBuilder(_smallSize);
                    }

                    if (TryParseTag(out string tag, out _))
                    {
                        _textStack.Push(tag);

                        continue;
                    }
                }
                else if (_gameString[_iterator] == '~' && _iterator + 1 < _gameString.Length && _gameString[_iterator + 1] == '~')
                {
                    _textStack.Push(sb.ToString());
                    sb = new StringBuilder(_smallSize);

                    if (ParseScalingTag(out string scaleText, includeScaling))
                    {
                        _textStack.Push(scaleText);
                    }

                    continue;
                }

                if (_iterator >= _gameString.Length)
                    break;

                sb.Append(_gameString[_iterator]);
            }

            if (sb.Length > 0)
                _textStack.Push(sb.ToString());

            sb = new StringBuilder(_smallSize);

            while (_textStack.Count > 0)
            {
                sb.Insert(0, _textStack.Pop());
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
            StringBuilder sb = new StringBuilder(_smallSize);
            for (; _iterator < _gameString.Length; _iterator++)
            {
                sb.Append(_gameString[_iterator]);
                if (_gameString[_iterator] == '>')
                {
                    string[] parts = sb.ToString().Split(new char[] { ' ' }, 2);
                    if (parts.Length > 1)
                        tag = $"{parts[0].ToLower()} {parts[1]}";
                    else if (parts.Length == 1)
                        tag = parts[0].ToLower();
                    else
                        tag = sb.ToString();

                    // check if its a start tag
                    if (tag[1] != '/' && tag[^2] != '/')
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
            StringBuilder sb = new StringBuilder(_smallSize);

            for (; _iterator < _gameString.Length; _iterator++)
            {
                if (_gameString[_iterator] == '~')
                    tagCount++;
                else
                    sb.Append(_gameString[_iterator]);

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
            if (_localization == Localization.DEDE)
                return $"+{value:0.##}% pro Stufe";
            else if (_localization == Localization.ENUS)
                return $"+{value:0.##}% per level";
            else if (_localization == Localization.ESES)
                return $"+{value:0.##}% por nivel";
            else if (_localization == Localization.ESMX)
                return $"+{value:0.##}% por nivel";
            else if (_localization == Localization.FRFR)
                return $"+{value:0.##}% par niveau";
            else if (_localization == Localization.ITIT)
                return $"+{value:0.##}% per livello";
            else if (_localization == Localization.KOKR)
                return $"레벨 당 +{value:0.##}%";
            else if (_localization == Localization.PLPL)
                return $"+{value:0.##}% na poziom";
            else if (_localization == Localization.PTBR)
                return $"+{value:0.##}% por nível";
            else if (_localization == Localization.RURU)
                return $"+{value:0.##}% за уровень";
            else if (_localization == Localization.ZHCN)
                return $"每级 +{value:0.##}%";
            else if (_localization == Localization.ZHTW)
                return $"每級 +{value:0.##}%";
            else
                return $"{value:0.##}% per level";
        }
    }
}
