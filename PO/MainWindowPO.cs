namespace SmokeTests.Shared {
    public class MainWindowPO {
        private readonly Window _window;
        private readonly Utils utils;

        public MainWindowPO(Window window) {
            _window = window;
            utils = new Utils();
        }

        public AutomationElement titleBarOfTab =>
            _window.FindFirstDescendant(Locators.mainTitleBarLocator!)
            .FindFirstDescendant(Locators.titleBarId)!;

        public AutomationElement inputId =>
            _window.FindFirstDescendant(Locators.inputIdLocator!);

        public AutomationElement mainTitleBar =>
            _window.FindFirstDescendant(Locators.mainTitleBarLocator!);
        
        public AutomationElement mainPanel =>
            _window.FindFirstDescendant(Locators.mainPanelLocator!);

        public AutomationElement sidePanel =>
            _window.FindFirstDescendant(Locators.sidePanelLocator!);

    }
}