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
    class JogWest : IKeypressEffectModule
    {
        public Keys ActivationKey()
        {
            return Keys.NumPad4;
        }

        public void PerformAction()
        {
            Vector2 curr = Game1.player.Position;
            Game1.player.Position = new Vector2(curr.X - 30, curr.Y);
        }
    }
}
