using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAModule.Modules.ActiveEffectModules
{
    class SonicActiveEffect : IActiveEffectModule
    {
        bool isActive = false;
        int oldSkinColor = -1;

        public void Activate()
        {
            isActive = true;
            oldSkinColor = Game1.player.skinColor;
            Game1.player.changeSkinColor(16);
            Game1.player.addedSpeed = 25;
        }

        public string ActivationCommand()
        {
            return "Sonic";
        }

        public void Deactivate()
        {
            isActive = false;
            Game1.player.changeSkinColor(oldSkinColor);
        }

        public string DeactivationCommand()
        {
            return "Unsonic";
        }

        public bool IsActivated()
        {
            return isActive;
        }

        public void PerformAction()
        {
            Game1.player.addedSpeed = 25;
        }
    }
}
