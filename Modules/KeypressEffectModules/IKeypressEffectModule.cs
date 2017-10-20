using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAModule.Modules.KeypressEffectModules
{
    interface IKeypressEffectModule
    {
        Microsoft.Xna.Framework.Input.Keys ActivationKey();
        void PerformAction();
    }
}
