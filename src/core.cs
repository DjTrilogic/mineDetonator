using PoeHUD.Models;
using PoeHUD.Plugins;
using PoeHUD.Poe;
using PoeHUD.Poe.Components;
using System.Threading;

namespace mineDetonator
{
    public class Core : BaseSettingsPlugin<settings>
    {
        public Core() { PluginName = "Mine Detonator"; }

        public override void Render()
        {
            if (GameController.Game.IngameState.Data.LocalPlayer.GetComponent<Actor>().Minions.Count >= Settings.totalMines.Value)
            {
                if (Settings.debug.Value)
                    LogMessage("Detonating Mine...", 1);
                Keyboard.KeyPress(Settings.detonateKey.Value);
            }
        }
    }
}
