using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAModule.Modules.ActiveEffectModules
{
    interface IActiveEffectModule
    {
        bool IsActivated();
        void Activate();
        void Deactivate();
        string ActivationCommand();
        string DeactivationCommand();
        void PerformAction();
    }
}
