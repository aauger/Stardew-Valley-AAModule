using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using StardewValley;

namespace AAModule.Modules.KeypressEffectModules
{
    class JogNorth : IKeypressEffectModule
    {
        public Keys ActivationKey()
        {
            return Keys.NumPad8;
        }

        public void PerformAction()
        {
            Vector2 curr = Game1.player.Position;
            Game1.player.Position = new Vector2(curr.X, curr.Y - 30);
        }
    }
}
