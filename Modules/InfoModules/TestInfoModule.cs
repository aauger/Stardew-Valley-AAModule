using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAModule.Modules.InfoModules
{
    class TestInfoModule : IInfoModule
    {
        public string GetShowText()
        {
            return "Test";
        }

        public bool ShouldBeShowing()
        {
            return true;
        }
    }
}
