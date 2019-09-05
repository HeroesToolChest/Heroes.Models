using System;
using System.Collections.Generic;

namespace Heroes.Models
{
    public class EmoticonPack : ExtractableBase<EmoticonPack>, IExtractable
    {
        private readonly HashSet<string> EmoticonIdList = new HashSet<string>();

        /// <summary>
        /// Gets or sets the description text.
        /// </summary>
        public TooltipDescription? Description { get; set; }

        /// <summary>
        /// Gets or sets the sort name used for sorting the emoticon packs.
        /// </summary>
        public string? SortName { get; set; }

        /// <summary>
        /// Gets or sets the release date.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the type of collection category.
        /// </summary>
        public string? CollectionCategory { get; set; }

        /// <summary>
        /// Gets or sets the event name associated with this emoticon pack.
        /// </summary>
        public string? EventName { get; set; }

        /// <summary>
        /// Gets a collection of emoticons ids in this emoticon pack.
        /// </summary>
        public IEnumerable<string> EmoticonIds => EmoticonIdList;

        /// <summary>
        /// Adds an emoticon id value. Replaces if value already exists in collection.
        /// </summary>
        /// <param name="value"></param>
        public void AddEmoticonId(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            EmoticonIdList.Add(value);
        }

        /// <summary>
        /// Determines whether the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsEmoticonId(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return EmoticonIdList.Contains(value);
        }
    }
}
