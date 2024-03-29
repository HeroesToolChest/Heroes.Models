﻿namespace Heroes.Models.Tests;

[TestClass]
[SuppressMessage("Maintainability", "CA1508:Avoid dead conditional code", Justification = "Test")]
public class AnnouncerTests
{
    [TestMethod]
    [DataRow("ann1")]
    [DataRow("ann2")]
    [DataRow("ANN2")]
    public void EqualsTest(string id)
    {
        Announcer announcer = new()
        {
            Id = id,
        };

        Assert.AreEqual(announcer, announcer);
    }

    [TestMethod]
    public void EqualsMethodTests()
    {
        Announcer announcer = new()
        {
            Id = "ann1",
        };

        Assert.IsFalse(announcer.Equals((int?)null));
        Assert.IsFalse(announcer.Equals(5));

        Assert.IsTrue(announcer.Equals(obj: announcer));
    }

    [TestMethod]
    [DataRow("ann1")]
    [DataRow("ann2")]
    public void NotEqualsTest(string id)
    {
        Announcer announcer = new()
        {
            Id = "announcer",
        };

        Assert.AreNotEqual(announcer, new Announcer()
        {
            Id = id,
        });
    }

    [TestMethod]
    public void NotSameObjectTest()
    {
        Announcer announcer = new()
        {
            Id = "announcer",
        };

        Banner banner = new()
        {
            Id = "banner",
        };

        Banner bannerSameId = new()
        {
            Id = "announcer",
        };

        Assert.AreNotEqual(new List<string>() { "asdf" }, announcer);
        Assert.AreNotEqual(banner, announcer);
        Assert.AreNotEqual(bannerSameId, announcer);
    }

    [TestMethod]
    [DataRow("ann1", "ann1")]
    [DataRow("ann1", "Ann1")]
    [DataRow("ann1", "ANN1")]
    [DataRow("ANN1", "ANN1")]
    [DataRow("ANN1", "ann1")]
    public void OperatorEqualTest(string id, string id2)
    {
        Announcer announcer = new()
        {
            Id = id,
        };

        Announcer announcer2 = new()
        {
            Id = id2,
        };

#pragma warning disable SA1131 // Use readable conditions
        Assert.IsFalse(null! == announcer2);
#pragma warning restore SA1131 // Use readable conditions
        Assert.IsFalse(announcer2 == null!);

        Assert.IsTrue(null! == (Announcer)null!);
        Assert.IsTrue(announcer == announcer2);

        Assert.AreEqual(announcer.GetHashCode(), announcer2!.GetHashCode());
    }

    [TestMethod]
    [DataRow("ann1", "ann2")]
    [DataRow("ann1", "Ann12")]
    [DataRow("ann1", "ANNouncer1")]
    [DataRow("ANNouncer", "ANN1")]
    [DataRow("ANN1", "")]
    public void OperatorNotEqualTest(string id, string id2)
    {
        Announcer announcer = new()
        {
            Id = id,
        };

        Announcer announcer2 = new()
        {
            Id = id2,
        };

#pragma warning disable SA1131 // Use readable conditions
        Assert.IsTrue(null! != announcer2);
#pragma warning restore SA1131 // Use readable conditions
        Assert.IsTrue(announcer2 != null!);

        Assert.IsFalse(null! != (Announcer)null!);
        Assert.IsTrue(announcer != announcer2);

        Assert.AreNotEqual(announcer.GetHashCode(), announcer2!.GetHashCode());
    }
}
