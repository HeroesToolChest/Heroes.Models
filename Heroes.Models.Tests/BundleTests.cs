namespace Heroes.Models.Tests;

[TestClass]
public class BundleTests
{
    [TestMethod]
    public void GetSkinIdsByHeroIdTest()
    {
        Bundle bundle = new();

        bundle.AddHeroSkin("hero1", "heroSkinId1");
        bundle.AddHeroSkin("hero1", "heroSkinId2");
        bundle.AddHeroSkin("hero1", "heroSkinId3");
        bundle.AddHeroSkin("hero2", "heroSkinId1");
        bundle.AddHeroSkin("hero2", "heroSkinId2");

        List<string> heroSkinIds = bundle.GetSkinIdsByHeroId("hero1").ToList();
        Assert.AreEqual("heroSkinId2", heroSkinIds[1]);

        Assert.ThrowsException<KeyNotFoundException>(() => bundle.GetSkinIdsByHeroId("hero4"));
    }

    [TestMethod]
    public void TryGetSkinIdsByHeroIdTest()
    {
        Bundle bundle = new();

        bundle.AddHeroSkin("hero1", "heroSkinId1");
        bundle.AddHeroSkin("hero1", "heroSkinId2");
        bundle.AddHeroSkin("hero1", "heroSkinId3");
        bundle.AddHeroSkin("hero2", "heroSkinId1");
        bundle.AddHeroSkin("hero2", "heroSkinId2");

        Assert.IsTrue(bundle.TryGetSkinIdsByHeroId("hero1", out IEnumerable<string>? values));
        List<string> heroSkinIds = values!.ToList();
        Assert.AreEqual("heroSkinId2", heroSkinIds[1]);

        Assert.IsFalse(bundle.TryGetSkinIdsByHeroId("hero5", out IEnumerable<string>? _));
    }
}
