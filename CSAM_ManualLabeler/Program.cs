using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace CSAM_Manual
{
    static class Program
    {
        private static Logger logger = null;

        public const string MAIN_DATA_PATH = @"C:\CSAM_Manual";
        public const string CONFIG_PATH = @"C:\CSAM_Manual\config\";
        public const string TEMP_PATH = @"C:\CSAM_Manual\temp\";
        public const string LOG_PATH = @"C:\CSAM_Manual\logs\";
        public const string RECIPE_PATH = @"C:\CSAM_Manual\recipes\";

        private static string sProgramVersion;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                logger = LogManager.GetCurrentClassLogger();
            }
            catch
            {
                // I don't think missing the file will actually cause this error. 
                MessageBox.Show("Missing NLog.config file. This software can't run without an NLog.config file.");
                Application.Exit();
            }



            try
            {


                logger.Info("Program.cs Main - Application launch");

                sProgramVersion = string.Format("{0}.{1}.{2}",
                        Assembly.GetExecutingAssembly().GetName().Version.Major.ToString(),
                        Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString(),
                        Assembly.GetExecutingAssembly().GetName().Version.Build.ToString());


                // CreateDirectory won't create a folder if there is one already.
                Directory.CreateDirectory(MAIN_DATA_PATH);
                Directory.CreateDirectory(CONFIG_PATH);
                Directory.CreateDirectory(TEMP_PATH);
                Directory.CreateDirectory(LOG_PATH);
                Directory.CreateDirectory(RECIPE_PATH);

                string[] arguments = Environment.GetCommandLineArgs();

                if (arguments.Length == 1)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);


                    // This is necessary in order to get the main program to run on the STA thread. Which is 
                    // needed when running anything that uses OLE, etc. 
                    var thread = new Thread(() => Application.Run(new frmMain(sProgramVersion)));
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

    }
}
