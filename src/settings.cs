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
            detonateKey = Keys.D;
        }

        [Menu("Total Mines to detonate", 0)]
        public RangeNode<int> totalMines { get; set; }

        [Menu("Detonate Key", 1)]
        public HotkeyNode detonateKey { get; set; }

        [Menu("Debug Mode", 2)]
        public ToggleNode debug { get; set; }
    }
}
