namespace SmokeTests.Shared {
    public static class Locators {
        private static readonly ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());

        //MainWindowPO
        public static ConditionBase inputIdLocator =>
            cf.ByAutomationId("inputId");

        public static ConditionBase mainTitleBarLocator =>
            cf.ByControlType(ControlType.TitleBar);

        public static ConditionBase mainPanel =>
            cf.ByName("panelName");

        public static ConditionBase sidePanel =>
            cf.ByClassName("sidePanel");

        //SharedPO
        public static ConditionBase popUpWindowLocator =>
            cf.ByAutomationId("popUp");

        public static ConditionBase nextButtonLocator =>
            cf.ByAutomationId("nextButton");

        public static ConditionBase errorWindowLocator =>
            cf.ByAutomationId("errorWindow");

        //OtherLocators
        public static ConditionBase searchBySubstring =>
            new PropertyCondition(AutomationObjectIds.NameProperty, "textToSearch", PropertyConditionFlags.MatchSubstring);

        public static ConditionBase multipleConditions =>
            cf.ByName("name")
            .And(cf.ByControlType(ControlType.Pane))
            .And(cf.ByLocalizedControlType("pane"));
    }
}