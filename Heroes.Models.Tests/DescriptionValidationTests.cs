﻿namespace Heroes.Models.Tests;

[TestClass]
public class DescriptionValidationTests
{
    private readonly string _noTagsDescription = "previous location.";
    private readonly string _normalTagsDescription1 = "Every <c val=\"#TooltipNumbers\">18</c> seconds, deals <c val=\"#TooltipNumbers\">125</c> bonus by <c val=\"#TooltipNumbers\">2</c> seconds.";
    private readonly string _normalTagsDescription2 = "<c val=\"#TooltipQuest\"> Repeatable Quest:</c> Gain<c val=\"#TooltipNumbers\">10</c>";
    private readonly string _extraTagDescription1 = "</w>previous location.";
    private readonly string _extraTagDescription2 = "previous location.</w>";
    private readonly string _extraTagDescription3 = "previous </w>location.";
    private readonly string _extraTagDescription4 = "previous <w>location.";
    private readonly string _extraTagDescription5 = "previous <w><w>location.";
    private readonly string _extraTagDescription6 = "<li/>previous location.";
    private readonly string _newLineTagDescription1 = "Max Health Bonus: <c val=\"#TooltipNumbers\">0%</c><n/>Health Per Second Bonus: <c val=\"#TooltipNumbers\">0</c>";
    private readonly string _newLineTagDescription2 = "Max Health Bonus: <c val=\"#TooltipNumbers\">0%</c><n/><n/>Health Per Second Bonus: <c val=\"#TooltipNumbers\">0</c>";
    private readonly string _selfCloseTagDescription1 = "<img path=\"sdf\"/>previous location.";
    private readonly string _selfCloseTagDescription2 = "previous<img path=\"sdf\"/>";
    private readonly string _selfCloseTagDescription3 = "previous<img path=\"sdf\"/><c val=\"#TooltipQuest\"> Repeatable Quest:</c>";
    private readonly string _selfCloseTagDescription4 = "previous<c val=\"#TooltipQuest\"> Repeatable Quest:</c><img path=\"sdf\"/>";
    private readonly string _duplicateTagsDescription1 = "<c val=\"#TooltipQuest\"> Repeatable Quest:</c> Gain<c val=\"#TooltipNumbers\">10</c></c>";
    private readonly string _duplicateTagsDescription2 = "<c val=\"#TooltipQuest\"> Repeatable Quest:</c></c> Gain<c val=\"#TooltipNumbers\">10</c></c>";
    private readonly string _spaceTagNormalDescription1 = "Temps de recharge : 20 secondes";
    private readonly string _spaceTagNormalDescription2 = "À distance";
    private readonly string _spaceTagNormalDescription3 = "À distance";
    private readonly string _spaceTagDescription1 = "Temps de recharge :<sp/>20 secondes";
    private readonly string _spaceTagDescription2 = "À distance<sp/>";
    private readonly string _spaceTagDescription3 = "<sp/>À distance";

    // Convert newline tags </n> to <n/>
    private readonly string _convertNewLineTagDescription1 = "Max Health Bonus: <c val=\"#TooltipNumbers\">0%</c></n>Health Per Second Bonus: <c val=\"#TooltipNumbers\">0</c>";
    private readonly string _convertNewLineTagDescription1Corrected = "Max Health Bonus: <c val=\"#TooltipNumbers\">0%</c><n/>Health Per Second Bonus: <c val=\"#TooltipNumbers\">0</c>";
    private readonly string _convertNewLineTagDescription2 = "Max Health Bonus: <c val=\"#TooltipNumbers\">0%</c></n></n>Health Per Second Bonus: <c val=\"#TooltipNumbers\">0</c>";
    private readonly string _convertNewLineTagDescription2Corrected = "Max Health Bonus: <c val=\"#TooltipNumbers\">0%</c><n/><n/>Health Per Second Bonus: <c val=\"#TooltipNumbers\">0</c>";
    private readonly string _convertNewLineTagDescription3 = "Max Health Bonus: <c val=\"#TooltipNumbers\">0%</c></n></n>Health Per Second Bonus: <c val=\"#TooltipNumbers\">0</c></n>";
    private readonly string _convertNewLineTagDescription3Corrected = "Max Health Bonus: <c val=\"#TooltipNumbers\">0%</c><n/><n/>Health Per Second Bonus: <c val=\"#TooltipNumbers\">0</c><n/>";

    // Case tags
    private readonly string _upperCaseTagDescription1 = "<C val=\"#TooltipQuest\"> Repeatable Quest:</C> Gain<C val=\"#TooltipNumbers\">10</c>";
    private readonly string _upperCaseTagDescription1Corrected = "<c val=\"#TooltipQuest\"> Repeatable Quest:</c> Gain<c val=\"#TooltipNumbers\">10</c>";

    // space in tags
    private readonly string _extraSpacesTagDescription1 = "<c  val=\"#TooltipQuest\"> Repeatable Quest:</c> Gain<c val=\"#TooltipNumbers\">10</c>";
    private readonly string _extraSpacesTagDescription2 = "<c     val=\"#TooltipQuest\"> Repeatable Quest:</c> Gain<c val=\"#TooltipNumbers\">10</c>";

    // Empty text tags
    private readonly string _emptyTagsDescription1 = "<c val=\"#TooltipQuest\"></c><c val=\"#TooltipNumbers\"></c>";
    private readonly string _emptyTagsDescription1Corrected = string.Empty;
    private readonly string _emptyTagsDescription2 = "test1<c val=\"#TooltipQuest\">test2</c>test3 <c val=\"#TooltipNumbers\"></c>";
    private readonly string _emptyTagsDescription2Corrected = "test1<c val=\"#TooltipQuest\">test2</c>test3 ";
    private readonly string _emptyTagsDescription3 = "<c val=\"#TooltipQuest\"></C>test1<c val=\"#TooltipQuest\">test2</c>test3 <c val=\"#TooltipNumbers\"></c>";
    private readonly string _emptyTagsDescription3Corrected = "test1<c val=\"#TooltipQuest\">test2</c>test3 ";

    // nested tags
    private readonly string _nestedTagDescription1 = "<c val=\"FF8000\">Gain <c val=\"#TooltipNumbers\">30%</c> points</c>";
    private readonly string _nestedTagDescription1Corrected = "<c val=\"FF8000\">Gain </c><c val=\"#TooltipNumbers\">30%</c><c val=\"FF8000\"> points</c>";
    private readonly string _nestedTagDescription2 = "<c val=\"FF8000\">Gain <c val=\"#TooltipNumbers\">30%</c> points <c val=\"#TooltipNumbers\">30%</c> charges</c>";
    private readonly string _nestedTagDescription2Corrected = "<c val=\"FF8000\">Gain </c><c val=\"#TooltipNumbers\">30%</c><c val=\"FF8000\"> points </c><c val=\"#TooltipNumbers\">30%</c><c val=\"FF8000\"> charges</c>";
    private readonly string _nestedTagDescription3 = "<c val=\"FF8000\"><c val=\"#TooltipNumbers\"></c></c>";
    private readonly string _nestedTagDescription3Corrected = string.Empty;
    private readonly string _nestedTagDescription4 = "<c val=\"FF8000\">45%<c val=\"#TooltipNumbers\"></c></c>";
    private readonly string _nestedTagDescription4Corrected = "<c val=\"FF8000\">45%</c>";

    // nested new line
    private readonly string _nestedNewLineTagDescription1 = "Max Health Bonus: <c val=\"#TooltipNumbers\">0%<n/>5%</c>Health <c val=\"#TooltipNumbers\">0</c>"; // new line between c tags
    private readonly string _nestedNewLineTagDescription1Corrected = "Max Health Bonus: <c val=\"#TooltipNumbers\">0%</c><n/><c val=\"#TooltipNumbers\">5%</c>Health <c val=\"#TooltipNumbers\">0</c>";
    private readonly string _nestedNewLineTagDescription2 = "Max Health Bonus: <c val=\"#TooltipNumbers\">0%<n/></c>Health <c val=\"#TooltipNumbers\">0</c>";
    private readonly string _nestedNewLineTagDescription2Corrected = "Max Health Bonus: <c val=\"#TooltipNumbers\">0%</c><n/>Health <c val=\"#TooltipNumbers\">0</c>";

    // real descriptions
    private readonly string _diabloBlackSoulstone = "<img path=\"@UI/StormTalentInTextQuestIcon\" alignment=\"uppermiddle\" color=\"B48E4C\" width=\"20\" height=\"22\"/><c val=\"#TooltipQuest\">Repeatable Quest:</c> Gain <c val=\"#TooltipNumbers\">10</c> Souls per Hero killed and <c val=\"#TooltipNumbers\">1</c> Soul per Minion, up to <c val=\"#TooltipNumbers\">100</c>. For each Soul, gain <c val=\"#TooltipNumbers\">0.4%</w></c> maximum Health. If Diablo has <c val=\"#TooltipNumbers\">100</c> Souls upon dying, he will resurrect in <c val=\"#TooltipNumbers\">5</c> seconds but lose <c val=\"#TooltipNumbers\">100</c> Souls.";
    private readonly string _diabloBlackSoulstoneCorrected = "<img path=\"@UI/StormTalentInTextQuestIcon\" alignment=\"uppermiddle\" color=\"B48E4C\" width=\"20\" height=\"22\"/><c val=\"#TooltipQuest\">Repeatable Quest:</c> Gain <c val=\"#TooltipNumbers\">10</c> Souls per Hero killed and <c val=\"#TooltipNumbers\">1</c> Soul per Minion, up to <c val=\"#TooltipNumbers\">100</c>. For each Soul, gain <c val=\"#TooltipNumbers\">0.4%</c> maximum Health. If Diablo has <c val=\"#TooltipNumbers\">100</c> Souls upon dying, he will resurrect in <c val=\"#TooltipNumbers\">5</c> seconds but lose <c val=\"#TooltipNumbers\">100</c> Souls.";
    private readonly string _dvaMechSelfDestruct = "Eject from the Mech, setting it to self-destruct after <c val=\"#TooltipNumbers\">4</c> seconds. Deals <c val=\"#TooltipNumbers\">400</c> to <c val=\"#TooltipNumbers\">1200</c> damage in a large area, depending on distance from center. Only deals <c val=\"#TooltipNumbers\">50%</c> damage against Structures.</n></n><c val=\"FF8000\">Gain <c val=\"#TooltipNumbers\">1%</c> Charge for every <c val=\"#TooltipNumbers\">2</c> seconds spent Basic Attacking, and <c val=\"#TooltipNumbers\">30%</c> Charge per <c val=\"#TooltipNumbers\">100%</c> of Mech Health lost.</c>";
    private readonly string _dvaMechSelfDestructCorrected = "Eject from the Mech, setting it to self-destruct after <c val=\"#TooltipNumbers\">4</c> seconds. Deals <c val=\"#TooltipNumbers\">400</c> to <c val=\"#TooltipNumbers\">1200</c> damage in a large area, depending on distance from center. Only deals <c val=\"#TooltipNumbers\">50%</c> damage against Structures.<n/><n/><c val=\"FF8000\">Gain </c><c val=\"#TooltipNumbers\">1%</c><c val=\"FF8000\"> Charge for every </c><c val=\"#TooltipNumbers\">2</c><c val=\"FF8000\"> seconds spent Basic Attacking, and </c><c val=\"#TooltipNumbers\">30%</c><c val=\"FF8000\"> Charge per </c><c val=\"#TooltipNumbers\">100%</c><c val=\"FF8000\"> of Mech Health lost.</c>";
    private readonly string _valeeraCheapShot = "Deal <c val=\"#TooltipNumbers\">30</c> damage to an enemy, Stun them for <c val=\"#TooltipNumbers\">0.75</c> seconds, and Blind them for <c val=\"#TooltipNumbers\">2</c> seconds once Cheap Shot's Stun expires.<n/><n/><c val=\"#GlowColorRed\">Awards 1 Combo Point.</c><n/><n/><c val=\"#ColorViolet\">Unstealth: Blade Flurry<n/></c>Deal damage in an area around Valeera.";
    private readonly string _valeeraCheapShotCorrected = "Deal <c val=\"#TooltipNumbers\">30</c> damage to an enemy, Stun them for <c val=\"#TooltipNumbers\">0.75</c> seconds, and Blind them for <c val=\"#TooltipNumbers\">2</c> seconds once Cheap Shot's Stun expires.<n/><n/><c val=\"#GlowColorRed\">Awards 1 Combo Point.</c><n/><n/><c val=\"#ColorViolet\">Unstealth: Blade Flurry</c><n/>Deal damage in an area around Valeera.";
    private readonly string _crusaderPunish = "Step forward dealing <c val=\"#TooltipNumbers\">113</c> damage and Slowing enemies by <c val=\"#TooltipNumbers\">60%</c> decaying over <c val=\"#TooltipNumbers\">2</c> seconds.";
    private readonly string _crusaderPunishSame = "Step forward dealing <c val=\"#TooltipNumbers\">113</c> damage and Slowing enemies by <c val=\"#TooltipNumbers\">60%</c> decaying over <c val=\"#TooltipNumbers\">2</c> seconds.";

    // plain text
    private readonly string _plainText1 = "Gain 30% points"; // NestedTagDescription1
    private readonly string _plainText2 = "Max Health Bonus: 0% Health 0"; // NestedNewLineTagDescription2Corrected
    private readonly string _plainText3 = "Deal 30 damage to an enemy, Stun them for 0.75 seconds, and Blind them for 2 seconds once Cheap Shot's Stun expires.  Awards 1 Combo Point.  Unstealth: Blade Flurry Deal damage in an area around Valeera."; // ValeeraCheapShotCorrected
    private readonly string _plainText4 = "<c val=\"#TooltipNumbers\">100~~0.04~~</c> damage per second<n/>";
    private readonly string _plainText4Corrected = "100 damage per second";
    private readonly string _plainText5 = "<c val=\"#TooltipNumbers\">100~~0.04~~</c> damage per second ~~0.05~~";
    private readonly string _plainText5Corrected = "100 damage per second";

    // plain text with newlines
    private readonly string _plainTextNewline1 = "Max Health Bonus: 0%<n/>5%Health 0"; // NestedNewLineTagDescription1Corrected
    private readonly string _plainTextNewline2 = "Deal 30 damage to an enemy, Stun them for 0.75 seconds, and Blind them for 2 seconds once Cheap Shot's Stun expires.<n/><n/>Awards 1 Combo Point.<n/><n/>Unstealth: Blade Flurry<n/>Deal damage in an area around Valeera."; // ValeeraCheapShotCorrected
    private readonly string _plainTextNewline3 = "<c val=\"#TooltipNumbers\">100~~0.04~~</c><n/> damage per second ~~0.05~~";
    private readonly string _plainTextNewline3Corrected = "100<n/> damage per second";

    // plain text with scaling
    private readonly string _plainTextScaling1 = "<c val=\"#TooltipNumbers\">120~~0.04~~</c><n/> damage per second";
    private readonly string _plainTextScaling1Corrected = "120 (+4% per level)  damage per second";
    private readonly string _plainTextScaling2 = "<c val=\"#TooltipNumbers\">120~~0.05~~</c> damage per second ~~0.035~~<n/>";
    private readonly string _plainTextScaling2Corrected = "120 (+5% per level) damage per second  (+3.5% per level)";

    // plain text with scaling newlines
    private readonly string _plainTextScalingNewline1 = "<c val=\"#TooltipNumbers\">120~~0.04~~</c><n/> damage per second";
    private readonly string _plainTextScalingNewline1Corrected = "120 (+4% per level)<n/> damage per second";
    private readonly string _plainTextScalingNewline2 = "<c val=\"#TooltipNumbers\">120~~0.05~~</c> damage per <n/> second ~~0.035~~";
    private readonly string _plainTextScalingNewline2Corrected = "120 (+5% per level) damage per <n/> second  (+3.5% per level)";

    // colored text
    private readonly string _coloredText1 = "<c val=\"#TooltipNumbers\">100~~0.04~~</c><n/> damage per second<n/>";
    private readonly string _coloredText1Corrected = "<c val=\"#TooltipNumbers\">100</c><n/> damage per second<n/>";
    private readonly string _coloredText2 = "<c val=\"#TooltipNumbers\">100~~0.04~~</c> damage per second ~~0.05~~";
    private readonly string _coloredText2Corrected = "<c val=\"#TooltipNumbers\">100</c> damage per second";

    // colored text with scaling
    private readonly string _coloredTextScaling1 = "<c val=\"#TooltipNumbers\">100~~0.04~~</c><n/> damage per second<n/>";
    private readonly string _coloredTextScaling1Corrected = "<c val=\"#TooltipNumbers\">100 (+4% per level)</c><n/> damage per second<n/>";
    private readonly string _coloredTextScaling2 = "<c val=\"#TooltipNumbers\">100~~0.04~~</c> damage per second ~~0.05~~";
    private readonly string _coloredTextScaling2Corrected = "<c val=\"#TooltipNumbers\">100 (+4% per level)</c> damage per second  (+5% per level)";

    // text with error tag
    private readonly string _errorText1 = "<c val=\"#TooltipNumbers\">100##ERROR##~~0.04~~</c> damage per second<n/>";
    private readonly string _errorText1Corrected = "<c val=\"#TooltipNumbers\">100 (+4% per level)</c> damage per second<n/>";
    private readonly string _errorText2 = "<c val=\"FF8000\">Gain <c val=\"#TooltipNumbers\">30##ERROR##%</c> points</c>";
    private readonly string _errorText2Corrected = "Gain 30% points";
    private readonly string _errorText3 = "100##ERROR##<n/> damage per second<n/>";
    private readonly string _errorText3Corrected = "100<n/> damage per second<n/>";

    [TestMethod]
    public void ValidateTest()
    {
        Assert.AreEqual(_noTagsDescription, DescriptionValidator.Validate(_noTagsDescription)); // no changes
        Assert.AreEqual(_normalTagsDescription1, DescriptionValidator.Validate(_normalTagsDescription1)); // no changes
        Assert.AreEqual(_normalTagsDescription2, DescriptionValidator.Validate(_normalTagsDescription2)); // no changes
        Assert.AreEqual(_noTagsDescription, DescriptionValidator.Validate(_extraTagDescription1));
        Assert.AreEqual(_noTagsDescription, DescriptionValidator.Validate(_extraTagDescription2));
        Assert.AreEqual(_noTagsDescription, DescriptionValidator.Validate(_extraTagDescription3));
        Assert.AreEqual(_noTagsDescription, DescriptionValidator.Validate(_extraTagDescription4));
        Assert.AreEqual(_noTagsDescription, DescriptionValidator.Validate(_extraTagDescription5));
        Assert.AreEqual(_noTagsDescription, DescriptionValidator.Validate(_extraTagDescription6));
        Assert.AreEqual(_newLineTagDescription1, DescriptionValidator.Validate(_newLineTagDescription1)); // no changes
        Assert.AreEqual(_newLineTagDescription2, DescriptionValidator.Validate(_newLineTagDescription2)); // no changes
        Assert.AreEqual(_selfCloseTagDescription1, DescriptionValidator.Validate(_selfCloseTagDescription1)); // no changes
        Assert.AreEqual(_selfCloseTagDescription2, DescriptionValidator.Validate(_selfCloseTagDescription2)); // no changes
        Assert.AreEqual(_selfCloseTagDescription3, DescriptionValidator.Validate(_selfCloseTagDescription3)); // no changes
        Assert.AreEqual(_selfCloseTagDescription4, DescriptionValidator.Validate(_selfCloseTagDescription4)); // no changes
        Assert.AreEqual(_normalTagsDescription2, DescriptionValidator.Validate(_duplicateTagsDescription1));
        Assert.AreEqual(_normalTagsDescription2, DescriptionValidator.Validate(_duplicateTagsDescription2));
        Assert.AreEqual(_spaceTagDescription1, DescriptionValidator.Validate(_spaceTagDescription1)); // no changes
        Assert.AreEqual(_spaceTagDescription2, DescriptionValidator.Validate(_spaceTagDescription2)); // no changes
    }

    [TestMethod]
    public void ValidateConvertedNewlineTagsTest()
    {
        Assert.AreEqual(_convertNewLineTagDescription1Corrected, DescriptionValidator.Validate(_convertNewLineTagDescription1));
        Assert.AreEqual(_convertNewLineTagDescription2Corrected, DescriptionValidator.Validate(_convertNewLineTagDescription2));
        Assert.AreEqual(_convertNewLineTagDescription3Corrected, DescriptionValidator.Validate(_convertNewLineTagDescription3));
    }

    [TestMethod]
    public void ValidateCaseTagsTest()
    {
        Assert.AreEqual(_upperCaseTagDescription1Corrected, DescriptionValidator.Validate(_upperCaseTagDescription1));
    }

    [TestMethod]
    public void ValidateExtraSpaceInTagsTest()
    {
        Assert.AreEqual(_normalTagsDescription2, DescriptionValidator.Validate(_extraSpacesTagDescription1));
        Assert.AreEqual(_normalTagsDescription2, DescriptionValidator.Validate(_extraSpacesTagDescription2));
    }

    [TestMethod]
    public void ValidateEmptyTagsTest()
    {
        Assert.AreEqual(_emptyTagsDescription1Corrected, DescriptionValidator.Validate(_emptyTagsDescription1));
        Assert.AreEqual(_emptyTagsDescription2Corrected, DescriptionValidator.Validate(_emptyTagsDescription2));
        Assert.AreEqual(_emptyTagsDescription3Corrected, DescriptionValidator.Validate(_emptyTagsDescription3));
    }

    [TestMethod]
    public void ValidateNestedTagsTest()
    {
        Assert.AreEqual(_nestedTagDescription1Corrected, DescriptionValidator.Validate(_nestedTagDescription1));
        Assert.AreEqual(_nestedTagDescription2Corrected, DescriptionValidator.Validate(_nestedTagDescription2));
        Assert.AreEqual(_nestedTagDescription3Corrected, DescriptionValidator.Validate(_nestedTagDescription3));
        Assert.AreEqual(_nestedTagDescription4Corrected, DescriptionValidator.Validate(_nestedTagDescription4));
    }

    [TestMethod]
    public void ValidateNestedNewLineTagsTest()
    {
        Assert.AreEqual(_nestedNewLineTagDescription1Corrected, DescriptionValidator.Validate(_nestedNewLineTagDescription1));
        Assert.AreEqual(_nestedNewLineTagDescription2Corrected, DescriptionValidator.Validate(_nestedNewLineTagDescription2));
    }

    [TestMethod]
    public void ValidateRealDescriptionTest()
    {
        Assert.AreEqual(_diabloBlackSoulstoneCorrected, DescriptionValidator.Validate(_diabloBlackSoulstone));
        Assert.AreEqual(_dvaMechSelfDestructCorrected, DescriptionValidator.Validate(_dvaMechSelfDestruct));
        Assert.AreEqual(_valeeraCheapShotCorrected, DescriptionValidator.Validate(_valeeraCheapShot));
        Assert.AreEqual(_crusaderPunishSame, DescriptionValidator.Validate(_crusaderPunish));
    }

    [TestMethod]
    public void ValidatePlainTextTest()
    {
        Assert.AreEqual(_plainText1, DescriptionValidator.GetPlainText(_nestedTagDescription1, false, false));
        Assert.AreEqual(_plainText2, DescriptionValidator.GetPlainText(_nestedNewLineTagDescription2Corrected, false, false));
        Assert.AreEqual(_plainText3, DescriptionValidator.GetPlainText(_valeeraCheapShotCorrected, false, false));
        Assert.AreEqual(_plainText4Corrected, DescriptionValidator.GetPlainText(_plainText4, false, false));
        Assert.AreEqual(_plainText5Corrected, DescriptionValidator.GetPlainText(_plainText5, false, false));
    }

    [TestMethod]
    public void ValidatePlainTextNewlineTest()
    {
        Assert.AreEqual(_plainTextNewline1, DescriptionValidator.GetPlainText(_nestedNewLineTagDescription1Corrected, true, false));
        Assert.AreEqual(_plainTextNewline2, DescriptionValidator.GetPlainText(_valeeraCheapShotCorrected, true, false));
        Assert.AreEqual(_plainTextNewline3Corrected, DescriptionValidator.GetPlainText(_plainTextNewline3, true, false));
    }

    [TestMethod]
    public void ValidatePlainTextScalingTest()
    {
        Assert.AreEqual(_plainTextScaling1Corrected, DescriptionValidator.GetPlainText(_plainTextScaling1, false, true));
        Assert.AreEqual(_plainTextScaling2Corrected, DescriptionValidator.GetPlainText(_plainTextScaling2, false, true));
    }

    [TestMethod]
    public void ValidatePlainTextScalingNewlineTest()
    {
        Assert.AreEqual(_plainTextScalingNewline1Corrected, DescriptionValidator.GetPlainText(_plainTextScalingNewline1, true, true));
        Assert.AreEqual(_plainTextScalingNewline2Corrected, DescriptionValidator.GetPlainText(_plainTextScalingNewline2, true, true));
    }

    [TestMethod]
    public void ValidateColoredTextTest()
    {
        Assert.AreEqual(_coloredText1Corrected, DescriptionValidator.GetColoredText(_coloredText1, false));
        Assert.AreEqual(_coloredText2Corrected, DescriptionValidator.GetColoredText(_coloredText2, false));
    }

    [TestMethod]
    public void ValidateColoredTextScalingTest()
    {
        Assert.AreEqual(_coloredTextScaling1Corrected, DescriptionValidator.GetColoredText(_coloredTextScaling1, true));
        Assert.AreEqual(_coloredTextScaling2Corrected, DescriptionValidator.GetColoredText(_coloredTextScaling2, true));
    }

    [TestMethod]
    public void ValidateErrorTextTest()
    {
        Assert.AreEqual(_errorText1Corrected, DescriptionValidator.GetColoredText(_errorText1, true));
        Assert.AreEqual(_errorText2Corrected, DescriptionValidator.GetPlainText(_errorText2, false, false));
        Assert.AreEqual(_errorText3Corrected, DescriptionValidator.GetPlainText(_errorText3, true, false));
    }

    [TestMethod]
    public void ValidateSpaceTagsTest()
    {
        Assert.AreEqual(_spaceTagDescription1, DescriptionValidator.GetColoredText(_spaceTagDescription1, true));
        Assert.AreEqual(_spaceTagDescription2, DescriptionValidator.GetColoredText(_spaceTagDescription2, true));
        Assert.AreEqual(_spaceTagDescription3, DescriptionValidator.GetColoredText(_spaceTagDescription3, true));
        Assert.AreEqual(_spaceTagNormalDescription1, DescriptionValidator.GetPlainText(_spaceTagDescription1, false, true));
        Assert.AreEqual(_spaceTagNormalDescription2, DescriptionValidator.GetPlainText(_spaceTagDescription2, true, true));
        Assert.AreEqual(_spaceTagNormalDescription3, DescriptionValidator.GetPlainText(_spaceTagDescription3, true, true));
    }
}
