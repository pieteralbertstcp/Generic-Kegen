using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KeyGen
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

            List<string> keys = new List<string>
            {
                "31e1f3b0-549c-4994-a765-a302b649fc8c",
                "d64b8434-654e-4638-8f1a-422514e720dd",
                "9c61aeb0-ee4d-4b04-ad4c-a35857e5ac2c",
                "08311f02-37ca-46e6-9232-f3de44929c64",
                "0d72bccb-222c-4c6e-81a0-51bbd7022b22"
            };

            string windowTitle = "Adobe Shop 12";

            Application.Run(new KeyGenUI(keys).GetWindow(windowTitle));
        }
    }
}
