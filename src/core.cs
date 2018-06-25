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

        public Core() { PluginName = "Mine Detonator"; }

        public override void Render()
        {
            var deployedObjectsCount = GameController.Game.IngameState.Data.LocalPlayer.GetComponent<Actor>().DeployedObjectsCount;

            if (Settings.debug.Value)
                LogMessage("Total Current Deployed Objects:" + deployedObjectsCount, 1);

            if (deployedObjectsCount >= Settings.totalMines.Value && (DateTime.Now - lasttime).TotalSeconds > Settings.delay.Value)
            {
                if (Settings.debug.Value)
                    LogMessage("Detonating Mine Now.", 1);

                Keyboard.KeyPress(Settings.detonateKey.Value);
                lasttime = DateTime.Now;
            }
        }
    }
}
