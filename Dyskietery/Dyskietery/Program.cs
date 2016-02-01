using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Dyskietery
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var ex = e.Exception;
            string s = String.Empty;
            s += "Message: " + ex.Message;
            s += Environment.NewLine;
            s += Environment.NewLine;
            s += "Source: " + ex.Source;
            s += Environment.NewLine;
            s += Environment.NewLine;
            s += "TargetSite: " + ex.TargetSite;
            s += Environment.NewLine;
            s += Environment.NewLine;
            s += "Stack: " + ex.StackTrace;

            MessageBox.Show(s, "Unhandled Thread Exception");
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = (e.ExceptionObject as Exception);
            string s = String.Empty;
            s += "Message: " + ex.Message;
            s += Environment.NewLine;
            s += Environment.NewLine;
            s += "Source: " + ex.Source;
            s += Environment.NewLine;
            s += Environment.NewLine;
            s += "TargetSite: " + ex.TargetSite;
            s += Environment.NewLine;
            s += Environment.NewLine;
            s += "Stack: " + ex.StackTrace;

            MessageBox.Show(s, "Unhandled UI Exception");

        }
    }
}
