using PoeHUD.Hud.Settings;
using PoeHUD.Plugins;
using System.Windows.Forms;

namespace mineDetonator
{
    public class settings : SettingsBase
    {
        public settings()
        {
            Enable = false;
            debug = false;
            totalMines = new RangeNode<int>(5, 0, 100);
            delay = new RangeNode<int>(1, 1, 4);
            detonateKey = Keys.D;
        }

        [Menu("Total Mines to detonate", 0)]
        public RangeNode<int> totalMines { get; set; }

        [Menu("Detonate Key", 1)]
        public HotkeyNode detonateKey { get; set; }

        [Menu("Delay After Pressing Detonate", 2)]
        public RangeNode<int> delay { get; set; }

        [Menu("Debug Mode", 3)]
        public ToggleNode debug { get; set; }
    }
}
