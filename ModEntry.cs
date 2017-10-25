using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using System.Collections.Generic;
using AAModule.Modules.InfoModules;
using AAModule.Modules.KeypressEffectModules;
using AAModule.Modules.ActiveEffectModules;
using AAModule.Modules.CommandModules;
using Microsoft.Xna.Framework.Graphics;
using AAModule.Modules.HudModules;

namespace AAModule
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {
        List<IInfoModule> infoModules;
        List<IActiveEffectModule> activeEffectModules;
        List<ICommandModule> commandModules;
        List<IKeypressEffectModule> keypressEffectModules;
        List<IHudModule> hudModules;

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            infoModules = new List<IInfoModule>();
            activeEffectModules = new List<IActiveEffectModule>();
            commandModules = new List<ICommandModule>();
            keypressEffectModules = new List<IKeypressEffectModule>();
            hudModules = new List<IHudModule>();

            activeEffectModules.AddRange(new IActiveEffectModule[] {
                new SonicActiveEffect(),
                new AutoBucket()
            });

            infoModules.AddRange(new IInfoModule[] {
                new NextCatchModule(),
                new BlockInfoModule(),
            });

            keypressEffectModules.AddRange(new IKeypressEffectModule[] {
                new JogEast(),
                new JogNorth(),
                new JogSouth(),
                new JogWest()
            });

            commandModules.AddRange(new ICommandModule[] {
                new FixLighting()
            });

            hudModules.AddRange(new IHudModule[] {
            });

            foreach (IActiveEffectModule aem in activeEffectModules)
            {
                helper.ConsoleCommands.Add(aem.ActivationCommand(), "none", (x, st) => aem.Activate());
                helper.ConsoleCommands.Add(aem.DeactivationCommand(), "none", (x, st) => aem.Deactivate());
            }

            foreach (ICommandModule icm in commandModules)
            {
                helper.ConsoleCommands.Add(icm.Command(), "none", (x, st) => icm.PerformAction());
            }

            ControlEvents.KeyPressed += this.ControlEvents_KeyPress;
            GraphicsEvents.OnPostRenderHudEvent += GraphicsEvents_OnPostRenderHudEvent;
            GameEvents.EighthUpdateTick += GameEvents_EighthUpdateTick;
        }

        private void GameEvents_EighthUpdateTick(object sender, EventArgs e)
        {
            if (Context.IsWorldReady)
                foreach (IActiveEffectModule aem in activeEffectModules)
                {
                    if (aem.IsActivated())
                    {
                        aem.PerformAction();
                    }
                }
        }

        private void GraphicsEvents_OnPostRenderHudEvent(object sender, EventArgs e)
        {
            int offset = 0;
            foreach (IInfoModule iim in infoModules)
            {
                if (iim.ShouldDisplayInfoString() && !String.IsNullOrEmpty(iim.GetInfoString()))
                {
                    int height = DrawHoverTextBox(Game1.smallFont, iim.GetInfoString(), 50, 50 + offset);
                    offset += height + 5;
                }
            }

            foreach (IHudModule ihm in hudModules)
            {
                if (ihm.ShouldDrawOnHud())
                {
                    ihm.DrawOnHud();
                }
            }
        }

        /*********
        ** Private methods
        *********/
        /// <summary>The method invoked when the player presses a keyboard button.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        /// 
        private void ControlEvents_KeyPress(object sender, EventArgsKeyPressed e)
        {
            if (Context.IsWorldReady) // save is loaded
            {
                foreach (IKeypressEffectModule kpem in keypressEffectModules)
                {
                    if (e.KeyPressed == kpem.ActivationKey())
                    {
                        kpem.PerformAction();
                    }
                }
            }
        }

        private int DrawHoverTextBox(SpriteFont font, string description, int x, int y)
        {
            Vector2 stringLength = font.MeasureString(description);
            int width = (int)stringLength.X + Game1.tileSize / 2 + 40;
            int height = (int)stringLength.Y + Game1.tileSize / 3 + 5;

            if (x < 0)
                x = 0;

            if (y + height > Game1.graphics.GraphicsDevice.Viewport.Height)
                y = Game1.graphics.GraphicsDevice.Viewport.Height - height;

            StardewValley.Menus.IClickableMenu
                .drawTextureBox(Game1.spriteBatch, 
                Game1.menuTexture, 
                new Rectangle(0, 256, 60, 60), 
                x, y, 
                width, height, 
                Color.White,
                1,
                false);
            Utility.drawTextWithShadow(Game1.spriteBatch, 
                description, 
                font, 
                new Vector2(x + Game1.tileSize / 4, y + Game1.tileSize / 4), 
                Game1.textColor);

            return height;
        }
    }
}