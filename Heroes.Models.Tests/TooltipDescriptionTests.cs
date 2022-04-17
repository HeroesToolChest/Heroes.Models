using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Heroes.Models.Tests;

[TestClass]
[SuppressMessage("Maintainability", "CA1508:Avoid dead conditional code", Justification = "Test")]
public class TooltipDescriptionTests
{
    private readonly string _testDescription = "<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500~~0.035~~</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200~~0.04~~ </c>damage per second";
    private readonly string _errorDescription = "Deal <c val=\"#TooltipNumbers\">500##ERROR##~~0.035~~</c> damage";

    private readonly string _plainText = "Deal 500 damage Deal an additional 200 damage per second";
    private readonly string _plainTextWithNewlines = "Deal 500 damage<n/>Deal an additional 200 damage per second";
    private readonly string _plainTextWithScaling = "Deal 500 (+3.5% per level) damage Deal an additional 200 (+4% per level) damage per second";
    private readonly string _plainTextWithScalingWithNewlines = "Deal 500 (+3.5% per level) damage<n/>Deal an additional 200 (+4% per level) damage per second";
    private readonly string _coloredText = "<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200 </c>damage per second";
    private readonly string _coloredTextWithScaling = "<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500 (+3.5% per level)</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200 (+4% per level) </c>damage per second";

    // locale strings
    private readonly string _localePlainText = "Deal 500 damage Deal an additional 200 damage per second";
    private readonly string _localePlainTextWithNewlines = "Deal 500 damage<n/>Deal an additional 200 damage per second";
    private readonly string _localePlainTextWithScaling = "Deal 500 (레벨 당 +3.5%) damage Deal an additional 200 (레벨 당 +4%) damage per second";
    private readonly string _localePlainTextWithScalingWithNewlines = "Deal 500 (레벨 당 +3.5%) damage<n/>Deal an additional 200 (레벨 당 +4%) damage per second";
    private readonly string _localeColoredText = "<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200 </c>damage per second";
    private readonly string _localeColoredTextWithScaling = "<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500 (레벨 당 +3.5%)</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200 (레벨 당 +4%) </c>damage per second";

    [DataTestMethod]
    [DataRow("")]
    [DataRow("<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500~~0.035~~</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200~~0.04~~ </c>damage per second")]
    public void EqualsTest(string text)
    {
        TooltipDescription tooltipDescription = new TooltipDescription(text);

        Assert.AreEqual(tooltipDescription, tooltipDescription);
    }

    [TestMethod]
    public void EqualsMethodTests()
    {
        TooltipDescription tooltipDescription = new TooltipDescription("<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500~~0.035~~</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200~~0.04~~ </c>damage per second");

        Assert.IsFalse(tooltipDescription.Equals((int?)null));
        Assert.IsFalse(tooltipDescription.Equals(5));

        Assert.IsTrue(tooltipDescription.Equals(obj: tooltipDescription));
    }

    [DataTestMethod]
    [DataRow("Deal 500 damage Deal an additional 200 damage per second")]
    [DataRow("Deal 500 damage<n/>Deal an additional 200 damage per second")]
    [DataRow("Deal 500 (+3.5% per level) damage Deal an additional 200 (+4% per level) damage per second")]
    public void NotEqualsTest(string text)
    {
        TooltipDescription tooltipDescription = new TooltipDescription("<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500~~0.035~~</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200~~0.04~~ </c>damage per second");

        Assert.AreNotEqual(tooltipDescription, new TooltipDescription(text));
    }

    [TestMethod]
    public void NotSameObjectTest()
    {
        TooltipDescription tooltipDescription = new TooltipDescription("<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500~~0.035~~</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200~~0.04~~ </c>damage per second");

        Assert.AreNotEqual(new List<string>() { "asdf" }, tooltipDescription);
    }

    [DataTestMethod]
    [DataRow(
        "<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500~~0.035~~</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200~~0.04~~ </c>damage per second",
        Localization.ENUS,
        "<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500~~0.035~~</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200~~0.04~~ </c>damage per second",
        Localization.ENUS)]

    public void OperatorEqualTest(string text, Localization localization, string text2, Localization localization2)
    {
        TooltipDescription tooltipDescription = new TooltipDescription(text, localization);

        TooltipDescription tooltipDescription2 = new TooltipDescription(text2, localization2);

#pragma warning disable SA1131 // Use readable conditions
        Assert.IsFalse(null! == tooltipDescription2);
#pragma warning restore SA1131 // Use readable conditions
        Assert.IsFalse(tooltipDescription2 == null!);

        Assert.IsTrue(null! == (Announcer)null!);
        Assert.IsTrue(tooltipDescription == tooltipDescription2);

        Assert.AreEqual(tooltipDescription.GetHashCode(), tooltipDescription2!.GetHashCode());
    }

    [DataTestMethod]
    [DataRow(
        "<img path=\"QuestIcon\"/>DEAL <c val=\"#TooltipNumbers\">500~~0.035~~</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200~~0.04~~ </c>damage per second",
        Localization.ENUS,
        "<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500~~0.035~~</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200~~0.04~~ </c>damage per second",
        Localization.ENUS)]
    [DataRow(
        "<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500~~0.035~~</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200~~0.04~~ </c>damage per second",
        Localization.ENUS,
        "<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500~~0.035~~</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200~~0.04~~ </c>damage per second",
        Localization.KOKR)]
    [DataRow(
        "<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500~~0.035~~</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200~~0.04~~ </c>damage per second",
        Localization.ENUS,
        "Deal 500 damage Deal an additional 200 damage per second",
        Localization.ENUS)]
    public void OperatorNotEqualTest(string text, Localization localization, string text2, Localization localization2)
    {
        TooltipDescription tooltipDescription = new TooltipDescription(text, localization);

        TooltipDescription tooltipDescription2 = new TooltipDescription(text2, localization2);

#pragma warning disable SA1131 // Use readable conditions
        Assert.IsTrue(null! != tooltipDescription2);
#pragma warning restore SA1131 // Use readable conditions
        Assert.IsTrue(tooltipDescription2 != null!);

        Assert.IsFalse(null! != (Announcer)null!);
        Assert.IsTrue(tooltipDescription != tooltipDescription2);

        Assert.AreNotEqual(tooltipDescription.GetHashCode(), tooltipDescription2!.GetHashCode());
    }

    [TestMethod]
    public void DescriptionTest()
    {
        TooltipDescription tooltipDescription = new TooltipDescription(_testDescription);

        Assert.AreEqual(_plainText, tooltipDescription.PlainText);
        Assert.AreEqual(_plainTextWithNewlines, tooltipDescription.PlainTextWithNewlines);
        Assert.AreEqual(_plainTextWithScaling, tooltipDescription.PlainTextWithScaling);
        Assert.AreEqual(_plainTextWithScalingWithNewlines, tooltipDescription.PlainTextWithScalingWithNewlines);
        Assert.AreEqual(_coloredText, tooltipDescription.ColoredText);
        Assert.AreEqual(_coloredTextWithScaling, tooltipDescription.ColoredTextWithScaling);
    }

    [TestMethod]
    public void DescriptionEmptyTest()
    {
        TooltipDescription tooltipDescription = new TooltipDescription(string.Empty);

        Assert.IsTrue(string.IsNullOrEmpty(tooltipDescription.RawDescription));
        Assert.IsTrue(string.IsNullOrEmpty(tooltipDescription.PlainText));
        Assert.IsTrue(string.IsNullOrEmpty(tooltipDescription.PlainTextWithNewlines));
        Assert.IsTrue(string.IsNullOrEmpty(tooltipDescription.PlainTextWithScaling));
        Assert.IsTrue(string.IsNullOrEmpty(tooltipDescription.PlainTextWithScalingWithNewlines));
        Assert.IsTrue(string.IsNullOrEmpty(tooltipDescription.ColoredText));
        Assert.IsTrue(string.IsNullOrEmpty(tooltipDescription.ColoredTextWithScaling));
    }

    [TestMethod]
    public void DescriptionLocaleTest()
    {
        TooltipDescription tooltipDescription = new TooltipDescription(_testDescription, Localization.KOKR);

        Assert.AreEqual(_localePlainText, tooltipDescription.PlainText);
        Assert.AreEqual(_localePlainTextWithNewlines, tooltipDescription.PlainTextWithNewlines);
        Assert.AreEqual(_localePlainTextWithScaling, tooltipDescription.PlainTextWithScaling);
        Assert.AreEqual(_localePlainTextWithScalingWithNewlines, tooltipDescription.PlainTextWithScalingWithNewlines);
        Assert.AreEqual(_localeColoredText, tooltipDescription.ColoredText);
        Assert.AreEqual(_localeColoredTextWithScaling, tooltipDescription.ColoredTextWithScaling);
    }

    [TestMethod]
    public void DescriptionErrorTagTest()
    {
        TooltipDescription tooltipDescription = new TooltipDescription(_errorDescription, Localization.ENUS);

        Assert.IsTrue(tooltipDescription.HasErrorTag);
    }
}
