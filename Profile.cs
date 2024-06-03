using System.Collections.Generic;

namespace DesktopLayoutSaver
{
    public class Profile
    {
        public string Name { get; set; } = string.Empty;
        public List<WindowInfo> Windows { get; set; } = new List<WindowInfo>();
    }
}
