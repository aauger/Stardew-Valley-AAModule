using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AAModule.Modules.InfoModules
{
    class NextCatchModule : IInfoModule
    {
        Dictionary<int, string> fishNames = new Dictionary<int, string>()
        {
            {-1 , "Nothing" },
            {129, "Anchovy" },
            {142, "Carp"},
            {143, "Catfish"},
            {702, "Chub"},
            {372, "Clam"},
            {718, "Cockle"},
            {717, "Crab"},
            {716, "Crayfish"},
            {159, "Crimsonfish"},
            {704, "Dorado"},
            {148, "Eel"},
            {156, "Ghostfish"},
            {775, "Glacierfish"},
            {153, "Green Algae"},
            {708, "Halibut"},
            {147, "Herring"},
            {161, "Ice Pip"},
            {136, "Largemouth Bass"},
            {162, "Lava Eel"},
            {163, "Legend"},
            {707, "Lingcod"},
            {715, "Lobster"},
            {719, "Mussel"},
            {682, "Mutant Carp"},
            {149, "Octopus"},
            {723, "Oyster"},
            {141, "Perch"},
            {722, "Periwinkle"},
            {144, "Pike"},
            {128, "Pufferfish"},
            {138, "Rainbow Trout"},
            {146, "Red Mullet"},
            {150, "Red Snapper"},
            {139, "Salmon"},
            {164, "Sandfish"},
            {131, "Sardine"},
            {165, "Scorpion Carp"},
            {154, "Sea Cucumber"},
            {152, "Seaweed"},
            {706, "Shad"},
            {720, "Shrimp"},
            {796, "Slimejack"},
            {137, "Smallmouth Bass"},
            {721, "Snail"},
            {151, "Squid"},
            {158, "Stonefish"},
            {698, "Sturgeon"},
            {145, "Sunfish"},
            {155, "Super Cucumber"},
            {699, "Tiger Trout"},
            {701, "Tilapia"},
            {130, "Tuna"},
            {795, "Void Salmon"},
            {140, "Walleye"},
            {157, "White Algae"},
            {734, "Woodskip"}
        };

        public string GetShowText()
        {
            StardewValley.Menus.BobberBar bb = 
                Game1.activeClickableMenu as StardewValley.Menus.BobberBar;
            BindingFlags bf = BindingFlags.NonPublic | BindingFlags.Instance;
            FieldInfo field = typeof(StardewValley.Menus.BobberBar).GetField("whichFish", bf);
            int fishKey = (int)field.GetValue(bb);

            if (fishNames.ContainsKey(fishKey))
                return "On hook: " + fishNames[(int)field.GetValue(bb)];
            else
                return "On hook: " + fishKey;
        }

        public bool ShouldBeShowing()
        {
            return ((Game1.activeClickableMenu as StardewValley.Menus.BobberBar) != null);
        }
    }
}
