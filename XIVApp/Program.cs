using System;
using System.Reactive.Disposables;
using System.Windows.Forms;

namespace XIVApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new Form1();

            using (new CompositeDisposable())
            {
                Application.Run(form);
            }            
        }
    }
}
