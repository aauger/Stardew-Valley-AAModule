using Microsoft.Xna.Framework;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAModule.Modules.ActiveEffectModules
{
    class AutoBucket : IActiveEffectModule
    {
        bool isActivated = true;

        public void Activate()
        {
            isActivated = true;
        }

        public string ActivationCommand()
        {
            return "Autobucket";
        }

        public void Deactivate()
        {
            isActivated = false;
        }

        public string DeactivationCommand()
        {
            return "Unautobucket";
        }

        public bool IsActivated()
        {
            return isActivated;
        }

        public void PerformAction()
        {
            Vector2 cursorTile = Game1.currentCursorTile;
            bool isCrop = StardewValley.Game1.currentLocation.isCropAtTile((int)cursorTile.X, (int)cursorTile.Y);

            if (isCrop &&
                Math.Abs(Game1.player.getTileX() - cursorTile.X) <= 1 &&
                Math.Abs(Game1.player.getTileY() - cursorTile.Y) <= 1)
            {
                Item[] matches = Game1.player.items.Where(x => x != null && 
                                        x.Name.Contains("Can")).ToArray();

                if (matches.Length == 0)
                    return;

                int index = Game1.player.getIndexOfInventoryItem(matches[0]);
                if(index > 0)
                    Game1.player.CurrentToolIndex = index;
            }
        }
    }
}
