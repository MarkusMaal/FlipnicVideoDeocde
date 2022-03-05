using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flipnic_Video_Deocde
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static bool unattended = false;
        public static int progress = 0;
        public static int max = 100;
        public static string input;
        public static string output;
        public static Form1 f1;

        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                unattended = true;
                input = string.Join(" ", args);
                output = "lf\\in.png";
            }
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            f1 = new Form1();
            Application.Run(f1);
        }
    }
}
