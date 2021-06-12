using System;
using Eto.Forms;
using clicSANDLib;

namespace clicSANDMac.Gtk
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new Application(Eto.Platforms.Gtk).Run(new FormModelRunner());
        }
    }
}
