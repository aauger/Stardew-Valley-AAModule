using Microsoft.Xna.Framework;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAModule.Modules.InfoModules
{
    class BlockInfoModule : IInfoModule
    {
        StardewValley.Object obj;

        public BlockInfoModule()
        {
            obj = null;
        }

        public string GetInfoString()
        {
            return obj.name + "|" + obj.type + "|" + obj.category;
        }

        public bool ShouldDisplayInfoString()
        {
            Vector2 cursorTile = Game1.currentCursorTile;
            Game1.currentLocation.Objects.TryGetValue(cursorTile, out obj);

            return obj != null;
        }
    }
}
