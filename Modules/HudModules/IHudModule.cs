using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAModule.Modules.HudModules
{
    interface IHudModule
    {
        bool ShouldDrawOnHud();
        void DrawOnHud();
    }
}
