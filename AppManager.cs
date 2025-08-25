using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowDesktopSwitcher
{
    class AppManager
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        const int SW_RESTORE = 9;

        public void FocusOrLaunch(string exePath)
        {
            try
            {
                string processName = Path.GetFileNameWithoutExtension(exePath);
                var process = Process.GetProcessesByName(processName).FirstOrDefault();

                if (process != null)
                {
                    IntPtr handle = process.MainWindowHandle;
                    if (handle != IntPtr.Zero)
                    {
                        ShowWindow(handle, SW_RESTORE);
                        SetForegroundWindow(handle);
                    }
                }
                else
                {
                    Process.Start(exePath);
                }
            }
            catch ( Exception ex)
            {
                MessageBox.Show($"Error handling application '{exePath}':\n{ex.Message}", "App Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
