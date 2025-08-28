using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsDesktop;

namespace WindowDesktopSwitcher.Services
{
    class AppManager
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(nint hWnd);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(nint hWnd, int nCmdShow);
        const int SW_RESTORE = 9;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsIconic(nint hWnd);

        public void FocusOrLaunch(string exePath)
        {
            try
            {
                string processName = Path.GetFileNameWithoutExtension(exePath);
                var processes = Process.GetProcessesByName(processName);
                nint handleOnCurrentDesktop = nint.Zero;

                foreach (var process in processes)
                {
                    nint handle = process.MainWindowHandle;
                    if (handle != nint.Zero && VirtualDesktop.IsCurrentVirtualDesktop(handle)) 
                    {
                        handleOnCurrentDesktop = handle;
                        break;
                    }
                }

                if (handleOnCurrentDesktop != nint.Zero)
                {
                    if (IsIconic(handleOnCurrentDesktop))
                    {
                        ShowWindow(handleOnCurrentDesktop, SW_RESTORE);
                    }
                    SetForegroundWindow(handleOnCurrentDesktop);
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
