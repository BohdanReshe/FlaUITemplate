namespace SmokeTests.Shared {
    public class SharedPO : App {
        private readonly Window _window;
        private readonly Utils utils;

        public SharedPO(Window window) {
            _window = window;
            utils = new Utils();
        }

        public AutomationElement popUpWindow =>
            _window.Parent.FindFirstDescendant(Locators.popUpWindowLocator)!;

        public Button nextButton =>
            _window.FindFirstDescendant(Locators.tabWindowId)?
            .FindFirstDescendant(Locators.titleBarId)?
            .FindFirstDescendant(Locators.nameText)?
            .AsButton()!;

        public AutomationElement errorWindow =>
            _window.FindFirstDescendant(Locators.errorWindowLocator)!;
    }
}