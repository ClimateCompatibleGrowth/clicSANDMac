using System;
using Eto.Forms;
using clicSANDLib;

namespace clicSANDMac
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new Application(Eto.Platforms.Mac64).Run(new FormModelRunner());
        }
    }
}
