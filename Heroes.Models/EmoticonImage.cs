﻿namespace Heroes.Models
{
    public class EmoticonImage
    {
        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the index of the image in the texture sheet.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Get or sets the width of the image.
        /// </summary>
        public int Width { get; set; }
    }
}