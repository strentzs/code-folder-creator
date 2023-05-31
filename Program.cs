#nullable disable
using System;
using System.Windows.Forms;

namespace MyProject
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CreateDirectoryDialog());
        }
    }
}
