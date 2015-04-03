using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace APIDebugger1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WideBoxInterface.WideBoxInterfaceForm main = new WideBoxInterface.WideBoxInterfaceForm();
            APIName.APIName debug = new APIName.APIName(main.WideLocal);
            main.Run(new WideInterface[] { debug });
        }
    }
}
