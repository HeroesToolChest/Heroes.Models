﻿namespace Heroes.Models.Tests;

[SuppressMessage("Naming", "CA1712:Do not prefix enum values with type name", Justification = "For tests.")]
[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:Enumeration items should be documented", Justification = "For tests.")]
public enum Level
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
        Assert.AreEqual("Level 1", Level.Level1.GetFriendlyName());
        Assert.AreEqual("Level2", Level.Level2.GetFriendlyName());
        Assert.AreEqual("Level 3", Level.Level3.GetFriendlyName());
    }

    [TestMethod]
    public void ConvertFriendlyNameToEnumResultTest()
    {
        if ("Level 1".TryConvertToEnum(out Level result))
            Assert.AreEqual(Level.Level1, result);

        if ("Level2".TryConvertToEnum(out result))
            Assert.AreEqual(Level.Level2, result);

        if ("Level 3".TryConvertToEnum(out result))
            Assert.AreEqual(Level.Level3, result);

        Assert.IsTrue("Level 2".TryConvertToEnum(out Level _));
        Assert.IsTrue("Level3".TryConvertToEnum(out Level _));
    }

    [TestMethod]
    public void ConvertFriendlyNameToEnumTest()
    {
        Assert.AreEqual(Level.Level1, "Level 1".ConvertToEnum<Level>());
        Assert.AreEqual(Level.Level2, "Level 2".ConvertToEnum<Level>());
        Assert.AreEqual(Level.Level2, "Level2".ConvertToEnum<Level>());
        Assert.AreEqual(Level.Level3, "Level  3".ConvertToEnum<Level>());
        Assert.AreEqual(Level.Level3, "Level3".ConvertToEnum<Level>());

        Assert.ThrowsException<ArgumentException>(() =>
        {
            "NotValid".ConvertToEnum<Level>();
        });
    }
}
