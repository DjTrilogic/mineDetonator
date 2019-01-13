using PoeHUD.Models;
using PoeHUD.Plugins;
using PoeHUD.Poe;
using PoeHUD.Poe.Components;
using System;
using System.Threading;

namespace mineDetonator
{
    public class Core : BaseSettingsPlugin<settings>
    {
        private DateTime lasttime = new DateTime();
        private bool isEnabled = true;

        public Core() { PluginName = "Mine Detonator"; }

        public override void Render()
        {
            if (Settings.toggleKey.PressedOnce())
            {

                isEnabled = !isEnabled;
                var message = $"Auto-Detonator {(isEnabled ? "Enabled" : "Disabled")}";
                LogMessage(message, 2);
            }

            if (!isEnabled)
            {
                return;
            }

            var deployedObjectsCount = GameController.Game.IngameState.Data.LocalPlayer.GetComponent<Actor>().DeployedObjectsCount;

            if (Settings.debug.Value)
                LogMessage("Total Current Deployed Objects:" + deployedObjectsCount, 1);

            if (deployedObjectsCount >= Settings.totalMines.Value && (DateTime.Now - lasttime).TotalMilliseconds > Settings.delay.Value)
            {
                if (Settings.debug.Value)
                    LogMessage("Detonating Mine Now.", 1);

                Keyboard.KeyPress(Settings.detonateKey.Value);
                lasttime = DateTime.Now;
            }
        }
    }
}
