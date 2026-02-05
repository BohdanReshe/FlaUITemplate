namespace SmokeTests.Shared;

public class TestSessionName {
    public string sessionName { get; }

    public TestSessionName() {
        sessionName = "Test" + DateTime.Now.ToString("ddMMyyyyHHmmss");
    }
}