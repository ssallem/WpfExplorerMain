using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExplorer
{
    internal class Starter
    {
        [STAThread]
        public static void Main(string[] args)
        {
            _ = new App().Run();
                .AddWireDataContext<WIreDataContext>()
        }
    }
}
