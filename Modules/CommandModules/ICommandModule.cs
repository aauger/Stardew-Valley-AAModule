using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAModule.Modules.CommandModules
{
    interface ICommandModule
    {
        string Command();
        void PerformAction();
    }
}
