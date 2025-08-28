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
            int targetIndex = desktopNumber - 1;
            if (targetIndex < 0) return;

            var desktops = VirtualDesktop.GetDesktops();
            if (targetIndex < desktops.Length)
            {
                desktops[targetIndex].Switch();
            }
        }
    }
}
