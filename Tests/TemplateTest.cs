namespace SmokeTests {
    [TextFixture]
    public class TemplateTest : App {
        [Test]
        public void TemplateTest1() {
            OpenApp();
            var window = appInstance!.GetMainWindow(automation!)!;
            var sharedPO = new SharedPO(window);
            var utils = new Utils();

            utils.WaitUntilElementIsEnabledAndClickable(() => mainWindowPO.titleBarOfTab);
            utils.WaitUntilElementIsEnabledAndClickable(() => sharedPO.nextButton);
            utils.MoveToAndClick(sharedPO.nextButton.GetClickablePoint());

            Assert.Pass();
        }
    }
}