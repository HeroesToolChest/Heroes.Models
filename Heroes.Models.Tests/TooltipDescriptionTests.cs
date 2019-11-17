using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Heroes.Models.Tests
{
    [TestClass]
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
}
