using System;
using Eto.Forms;
using clicSANDLib;

namespace clicSANDMac.Wpf
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new Application(Eto.Platforms.Wpf).Run(new FormModelRunner());
        }
    }
}
