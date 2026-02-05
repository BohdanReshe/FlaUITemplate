using System.Runtime.CompilerServices;
using FlaUI.Core.Capturing;
using NUnit.Framework.Interfaces;

namespace SmokeTests.Shared {
    [TestFixture]
    public class App {
        public static Application? appInstance { get; private set; }
        public static UIA3Automation? automation { get; private set; }
        public static string sessionName { get; }

        public App() {
            automation = new UIA3Automation();
        }

        static App() {
            sessionName = "Test" + DateTime.Now.ToString("ddMMyyyyHHmmss");
        }

        [TearDown]
        public void TearDown() {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed) {
                CaptureScreenshot(TestContext.CurrentContext.Test.Name);
            }
            appInstance?.Close();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() {
            automation?.Dispose();
        }

        public void CaptureScreenshot(string name) {
            string outputFolder = TestContext.CurrentContext.WorkDirectory;
            Directory.CreateDirectory(outputFolder);
            string screenshotPath = Path.Combine(outputFolder, $"{DateTime.Now:yyyyMMddHHmmss}.png}");
            using (var screenshot = Capture.MainScreen()) {
                screenshot.ToFile(screenshotPath);
            }
            TestContext.AddTestAttachment(screenshotPath, TestContext.CurrentContext.Result.Message);
            TestContext.AddTestAttachment(screenshotPath, TestContext.CurrentContext.Result.StackTrace);
        }

        public void OpenApp() {
            var utils = new Utils();

            utils.CloseAllCurrentAppInstancesIfFound();
            appInstance = Application.Attach(utils.GetAppProcess().Id);
            
            var window = appInstance.GetMainWindow(automation!)!;

            utils.MaximaseWindowIfPossible(window);
        }
    }
}