using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopBlazorWAKicker
{
    internal class pathCheck
    {
        internal static bool Check(string root, string target)
        {
            return target.ToLower().StartsWith(root.ToLower());
        }
    }
}
