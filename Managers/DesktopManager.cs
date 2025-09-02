using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsDesktop;


namespace WindowDesktopSwitcher.Managers
{
    class DesktopManager
    {
        public void SwitchDesktops(int desktopNumber)
        {
            try
            {
                int targetIndex = desktopNumber - 1;
                if (targetIndex < 0) return;

                var desktops = VirtualDesktop.GetDesktops();
                int currentDesktopCount = desktops.Length;

                if (desktopNumber > currentDesktopCount)
                {
                    int desktopsToCreate = desktopNumber - currentDesktopCount;
                    for (int i = 0; i < desktopsToCreate; i++)
                    {
                        VirtualDesktop.Create();
                    }
                }
                var finalDesktops = VirtualDesktop.GetDesktops();
                if (targetIndex < finalDesktops.Length)
                {
                    desktops[targetIndex].Switch();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SwitchToDesktop: {ex.Message}");
            }
        }
    }
}
