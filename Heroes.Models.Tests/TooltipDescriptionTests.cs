using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Heroes.Models.Tests
{
    [TestClass]
    public class TooltipDescriptionTests
    {
        private readonly string TestDescription = "<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500~~0.035~~</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200~~0.04~~ </c>damage per second";

        private readonly string PlainText = "Deal 500 damage Deal an additional 200 damage per second";
        private readonly string PlainTextWithNewlines = "Deal 500 damage<n/>Deal an additional 200 damage per second";
        private readonly string PlainTextWithScaling = "Deal 500 (+3.5% per level) damage Deal an additional 200 (+4% per level) damage per second";
        private readonly string PlainTextWithScalingWithNewlines = "Deal 500 (+3.5% per level) damage<n/>Deal an additional 200 (+4% per level) damage per second";
        private readonly string ColoredText = "<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200 </c>damage per second";
        private readonly string ColoredTextWithScaling = "<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500 (+3.5% per level)</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200 (+4% per level) </c>damage per second";

        // locale strings
        private readonly string LocalePlainText = "Deal 500 damage Deal an additional 200 damage per second";
        private readonly string LocalePlainTextWithNewlines = "Deal 500 damage<n/>Deal an additional 200 damage per second";
        private readonly string LocalePlainTextWithScaling = "Deal 500 (레벨 당 +3.5%) damage Deal an additional 200 (레벨 당 +4%) damage per second";
        private readonly string LocalePlainTextWithScalingWithNewlines = "Deal 500 (레벨 당 +3.5%) damage<n/>Deal an additional 200 (레벨 당 +4%) damage per second";
        private readonly string LocaleColoredText = "<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200 </c>damage per second";
        private readonly string LocaleColoredTextWithScaling = "<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500 (레벨 당 +3.5%)</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200 (레벨 당 +4%) </c>damage per second";

        [TestMethod]
        public void DescriptionTest()
        {
            TooltipDescription tooltipDescription = new TooltipDescription(TestDescription);

            Assert.AreEqual(PlainText, tooltipDescription.PlainText);
            Assert.AreEqual(PlainTextWithNewlines, tooltipDescription.PlainTextWithNewlines);
            Assert.AreEqual(PlainTextWithScaling, tooltipDescription.PlainTextWithScaling);
            Assert.AreEqual(PlainTextWithScalingWithNewlines, tooltipDescription.PlainTextWithScalingWithNewlines);
            Assert.AreEqual(ColoredText, tooltipDescription.ColoredText);
            Assert.AreEqual(ColoredTextWithScaling, tooltipDescription.ColoredTextWithScaling);
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
        public void DescriptionLocaleTests()
        {
            TooltipDescription tooltipDescription = new TooltipDescription(TestDescription, Localization.KOKR);

            Assert.AreEqual(LocalePlainText, tooltipDescription.PlainText);
            Assert.AreEqual(LocalePlainTextWithNewlines, tooltipDescription.PlainTextWithNewlines);
            Assert.AreEqual(LocalePlainTextWithScaling, tooltipDescription.PlainTextWithScaling);
            Assert.AreEqual(LocalePlainTextWithScalingWithNewlines, tooltipDescription.PlainTextWithScalingWithNewlines);
            Assert.AreEqual(LocaleColoredText, tooltipDescription.ColoredText);
            Assert.AreEqual(LocaleColoredTextWithScaling, tooltipDescription.ColoredTextWithScaling);
        }
    }
}
