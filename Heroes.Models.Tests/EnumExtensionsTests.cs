using System;
using System.ComponentModel;
using Xunit;

namespace Heroes.Models.Tests
{
    public enum Levels
    {
        [Description("Level 1")]
        Level1,
        Level2,
        [Description("Level 3")]
        Level3,
    }

    public class EnumExtensionsTests
    {
        [Fact]
        public void GetFriendlyNameTest()
        {
            Assert.Equal("Level 1", Levels.Level1.GetFriendlyName());
            Assert.Equal("Level2", Levels.Level2.GetFriendlyName());
            Assert.Equal("Level 3", Levels.Level3.GetFriendlyName());
        }

        [Fact]
        public void ConvertFriendlyNameToEnumResultTest()
        {
            if ("Level 1".ConvertToEnum(out Levels result))
                Assert.Equal(Levels.Level1, result);

            if ("Level2".ConvertToEnum(out result))
                Assert.Equal(Levels.Level2, result);

            if ("Level 3".ConvertToEnum(out result))
                Assert.Equal(Levels.Level3, result);

            Assert.True("Level 2".ConvertToEnum(out result));
            Assert.True("Level3".ConvertToEnum(out result));
        }

        [Fact]
        public void ConvertFriendlyNameToEnumTest()
        {
            Assert.Equal(Levels.Level1, "Level 1".ConvertToEnum<Levels>());
            Assert.Equal(Levels.Level2, "Level 2".ConvertToEnum<Levels>());
            Assert.Equal(Levels.Level2, "Level2".ConvertToEnum<Levels>());
            Assert.Equal(Levels.Level3, "Level 3".ConvertToEnum<Levels>());
            Assert.Equal(Levels.Level3, "Level3".ConvertToEnum<Levels>());

            Assert.Throws<ArgumentException>(() =>
            {
                "NotValid".ConvertToEnum<Levels>();
            });
        }
    }
}
