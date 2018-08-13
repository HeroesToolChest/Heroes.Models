using Xunit;

namespace Heroes.Models.Tests
{
    public class TooltipDescriptionTests
    {
        private readonly string TestDescription = "<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500~~0.035~~</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200~~0.04~~ </c>damage per second";

        private readonly string PlainText = "Deal 500 damage Deal an additional 200 damage per second";
        private readonly string PlainTextWithNewlines = "Deal 500 damage<n/>Deal an additional 200 damage per second";
        private readonly string PlainTextWithScaling = "Deal 500 (+3.5% per level) damage Deal an additional 200 (+4% per level) damage per second";
        private readonly string PlainTextWithScalingWithNewlines = "Deal 500 (+3.5% per level) damage<n/>Deal an additional 200 (+4% per level) damage per second";
        private readonly string ColoredText = "<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200 </c>damage per second";
        private readonly string ColoredTextWithScaling = "<img path=\"QuestIcon\"/>Deal <c val=\"#TooltipNumbers\">500 (+3.5% per level)</c> damage<n/>Deal an additional <c val=\"#TooltipNumbers\">200 (+4% per level) </c>damage per second";

        [Fact]
        public void DescriptionTest()
        {
            TooltipDescription tooltipDescription = new TooltipDescription(TestDescription);

            Assert.Equal(PlainText, tooltipDescription.PlainText);
            Assert.Equal(PlainTextWithNewlines, tooltipDescription.PlainTextWithNewlines);
            Assert.Equal(PlainTextWithScaling, tooltipDescription.PlainTextWithScaling);
            Assert.Equal(PlainTextWithScalingWithNewlines, tooltipDescription.PlainTextWithScalingWithNewlines);
            Assert.Equal(ColoredText, tooltipDescription.ColoredText);
            Assert.Equal(ColoredTextWithScaling, tooltipDescription.ColoredTextWithScaling);
        }

        [Fact]
        public void DescriptionEmptyTest()
        {
            TooltipDescription tooltipDescription = new TooltipDescription(string.Empty);

            Assert.Empty(tooltipDescription.RawDescription);
            Assert.Empty(tooltipDescription.PlainText);
            Assert.Empty(tooltipDescription.PlainTextWithNewlines);
            Assert.Empty(tooltipDescription.PlainTextWithScaling);
            Assert.Empty(tooltipDescription.PlainTextWithScalingWithNewlines);
            Assert.Empty(tooltipDescription.ColoredText);
            Assert.Empty(tooltipDescription.ColoredTextWithScaling);
        }

        [Fact]
        public void DescriptionNullTest()
        {
            TooltipDescription tooltipDescription = new TooltipDescription(null);

            Assert.Empty(tooltipDescription.RawDescription);
            Assert.Empty(tooltipDescription.PlainText);
            Assert.Empty(tooltipDescription.PlainTextWithNewlines);
            Assert.Empty(tooltipDescription.PlainTextWithScaling);
            Assert.Empty(tooltipDescription.PlainTextWithScalingWithNewlines);
            Assert.Empty(tooltipDescription.ColoredText);
            Assert.Empty(tooltipDescription.ColoredTextWithScaling);
        }
    }
}
