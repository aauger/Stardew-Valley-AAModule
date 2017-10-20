using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAModule.Modules.InfoModules
{
    interface IInfoModule
    {
        bool ShouldBeShowing();
        string GetShowText();
    }
}
