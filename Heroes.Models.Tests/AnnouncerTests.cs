using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Heroes.Models.Tests;

[TestClass]
[SuppressMessage("Maintainability", "CA1508:Avoid dead conditional code", Justification = "Test")]
public class AnnouncerTests
{
    [DataTestMethod]
    [DataRow("ann1")]
    [DataRow("ann2")]
    [DataRow("ANN2")]
    public void EqualsTest(string id)
    {
        Announcer announcer = new Announcer()
        {
            Id = id,
        };

        Assert.AreEqual(announcer, announcer);
    }

    [TestMethod]
    public void EqualsMethodTests()
    {
        Announcer announcer = new Announcer()
        {
            Id = "ann1",
        };

        Assert.IsFalse(announcer.Equals((int?)null));
        Assert.IsFalse(announcer.Equals(5));

        Assert.IsTrue(announcer.Equals(obj: announcer));
    }

    [DataTestMethod]
    [DataRow("ann1")]
    [DataRow("ann2")]
    public void NotEqualsTest(string id)
    {
        Announcer announcer = new Announcer()
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
        Announcer announcer = new Announcer()
        {
            Id = "announcer",
        };

        Banner banner = new Banner()
        {
            Id = "banner",
        };

        Banner bannerSameId = new Banner()
        {
            Id = "announcer",
        };

        Assert.AreNotEqual(new List<string>() { "asdf" }, announcer);
        Assert.AreNotEqual(banner, announcer);
        Assert.AreNotEqual(bannerSameId, announcer);
    }

    [DataTestMethod]
    [DataRow("ann1", "ann1")]
    [DataRow("ann1", "Ann1")]
    [DataRow("ann1", "ANN1")]
    [DataRow("ANN1", "ANN1")]
    [DataRow("ANN1", "ann1")]
    public void OperatorEqualTest(string id, string id2)
    {
        Announcer announcer = new Announcer()
        {
            Id = id,
        };

        Announcer announcer2 = new Announcer()
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

    [DataTestMethod]
    [DataRow("ann1", "ann2")]
    [DataRow("ann1", "Ann12")]
    [DataRow("ann1", "ANNouncer1")]
    [DataRow("ANNouncer", "ANN1")]
    [DataRow("ANN1", "")]
    public void OperatorNotEqualTest(string id, string id2)
    {
        Announcer announcer = new Announcer()
        {
            Id = id,
        };

        Announcer announcer2 = new Announcer()
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
