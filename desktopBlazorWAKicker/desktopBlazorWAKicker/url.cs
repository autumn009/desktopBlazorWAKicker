using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace desktopBlazorWAKicker
{
    internal class url
    {
        internal static bool kickUrl(string url)
        {
            // from https://oita.oika.me/2017/09/17/dotnet-core-process-start-with-url/ and modefied
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                //Windowsのとき  
                ProcessStartInfo pi = new ProcessStartInfo()
                {
                    FileName = url,
                    UseShellExecute = true,
                };
                Process.Start(pi);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linuxのとき  
                Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                //Macのとき  
                Process.Start("open", url);
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
