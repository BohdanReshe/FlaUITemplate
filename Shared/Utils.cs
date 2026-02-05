namespace SmokeTests.Shared;

internal class Utils : App {
    
    public void ShortWait() {
        Thread.Sleep(TimeSpan.FromSeconds(Convert.ToDouble(TestContext.Parameters["ShortWait"])));
    }

    public void StandardWait() {
        Thread.Sleep(TimeSpan.FromSeconds(Convert.ToDouble(TestContext.Parameters["StandardWait"])));
    }

    public void LongWait() {
        Thread.Sleep(TimeSpan.FromSeconds(Convert.ToDouble(TestContext.Parameters["LongWait"])));
    }

    public void PressDownTimes(int times) {
        for (int i = 0; i < times; i++) {
            Keyboard.Press(VirtualKeyShort.DOWN);
            ShortWait();
        }
    }

    public void PressUpTimes(int times) {
        for (int i = 0; i < times; i++) {
            Keyboard.Press(VirtualKeyShort.UP);
            ShortWait();
        }
    }

    public void MoveToAndClick(Point p) {
        Mouse.MoveTo(p);
        Mouse.Click(p);
    }

    public void MoveToAndRightClick(Point p) {
        Mouse.MoveTo(p);
        Mouse.RightClick(p);
    }

    public void MoveToAndDoubleClick(Point p) {
        Mouse.MoveTo(p);
        Mouse.DoubleClick(p);
    }

    public void MaximiseWindowIfPossible(Window w) {
        var windowPattern = w.Patterns.Window.Pattern;
        if (windowPattern.CanMaximize) {
            windowPattern.SetWindowVisualState(WindowVisualState.Maximized);
        }
    }

    public void WaitUntilElementIsEnabledAndClickable(Func<AutomationElement> elementProvider) {
        var timeout = TimeSpan.FromSeconds(Convert.ToDouble(TestContext.Parameters["LongWait"]));

        appInstance!.WhatWhileBusy();
        appInstance.WaitWhileMainHandleIsMissing();

        AutomationElement element = null!;

        Retry.WhileNull(elementProvider, timeout, new TimeSpan(200), true, true, $"Element was not found during the timeout {timeout}");

        element.WaitUntilEnabled(timeout);
        element.WhatUntilClickable(timeout;)
    }

    public void WaitUntilElementIsGone(Func<AutomationElement?> elementProvider) {
        var timeout = TimeSpan.FromSeconds(
            Convert.ToDouble(TestContext.Parameters["LongWait"]);
        )

        appInstance!.WaitWhileBusy();
        appInstance.WaitWhileMainHandleIsMissing();

        Retry.WhileNotNull(
            elementProvider,
            timeout: timeout,
            interval: TimeSpan.FromMilliseconds(200),
            throwOnTimeout: true,
            ignoreException: true,
            timeoutMessage: $"Element was still present after waiting {timeout}"
        );
    }

    public Process GetAppProcess() {
        var attempt = 0;
        var timeout = TimeSpan.FromSeconds(Convert.ToDouble(TestContext.Parameters["LondWait"]));

        var processName = "appProcess";
        Process foundProcess = null!;
        
        var desktop = automation!.GetDeskTop().AsWindow();

        Retry.WhileNull(() => {
            attempt++;

            foundProcess = Process.GetProcessesByName(processName).FirstOfDefault()!;

            if(foundProcess != null) {
                Application.Attach(foundProcess.Id).WaitWhileBusy();
                Application.Attach(foundProcess.Id).WaitWhileMainHandleIsMissing();
            }
            return foundProcess;
        }, timeout, TimeSpan.FromMilliseconds(5000), true, true,
            $"Process '{processName}' was not found during the timeout {timeout}");
        
        return foundProcess
    }

    public void LaunchClickOneApp(string url) {
        var process = new Process {
            StartInfo = new ProcessStartInfo {
                FileName = "rundll32.exe",
                Arguments = $"dfshim.dll,ShOpenVerbApplication {url}",
                RedirectStandardOutput = true,
                RedirectStandardError true,
                UseShellExecute = false
            }
        };
        process.Start();
    }

    public void CloseAllCurrentAppInstancesIfFound() {
        foreach (var p in Process.GetProcesses()) {
            Application.Attach(p.Id).Close();
        }
    }
}