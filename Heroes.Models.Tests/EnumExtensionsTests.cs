using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Heroes.Models.Tests
{
    public enum Levels
    {
        [System.ComponentModel.Description("Level 1")]
        Level1,
        Level2,
        [System.ComponentModel.Description("Level 3")]
        Level3,
    }

    [TestClass]
    public class EnumExtensionsTests
    {
        [TestMethod]
        public void GetFriendlyNameTest()
        {
            Assert.AreEqual("Level 1", Levels.Level1.GetFriendlyName());
            Assert.AreEqual("Level2", Levels.Level2.GetFriendlyName());
            Assert.AreEqual("Level 3", Levels.Level3.GetFriendlyName());
        }

        [TestMethod]
        public void ConvertFriendlyNameToEnumResultTest()
        {
            if ("Level 1".ConvertToEnum(out Levels result))
                Assert.AreEqual(Levels.Level1, result);

            if ("Level2".ConvertToEnum(out result))
                Assert.AreEqual(Levels.Level2, result);

            if ("Level 3".ConvertToEnum(out result))
                Assert.AreEqual(Levels.Level3, result);

            Assert.IsTrue("Level 2".ConvertToEnum(out result));
            Assert.IsTrue("Level3".ConvertToEnum(out result));
        }

        [TestMethod]
        public void ConvertFriendlyNameToEnumTest()
        {
            Assert.AreEqual(Levels.Level1, "Level 1".ConvertToEnum<Levels>());
            Assert.AreEqual(Levels.Level2, "Level 2".ConvertToEnum<Levels>());
            Assert.AreEqual(Levels.Level2, "Level2".ConvertToEnum<Levels>());
            Assert.AreEqual(Levels.Level3, "Level 3".ConvertToEnum<Levels>());
            Assert.AreEqual(Levels.Level3, "Level3".ConvertToEnum<Levels>());

            Assert.ThrowsException<ArgumentException>(() =>
            {
                "NotValid".ConvertToEnum<Levels>();
            });
        }
    }
}
