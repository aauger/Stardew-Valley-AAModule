using Microsoft.Xna.Framework;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAModule.Modules.CommandModules
{
    class FixLighting : ICommandModule
    {
        public string Command()
        {
            return "FixLighting";
        }

        public void PerformAction()
        {
            Game1.ambientLight = Color.White;
            Game1.outdoorLight = Color.White;
        }
    }
}
