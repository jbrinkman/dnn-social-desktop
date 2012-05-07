using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DotNetNuke.Social.Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UserContext = new Models.UserContext();
            CredentialRepository = new Repositories.CredentialRepository();

            UserContext.Credentials = CredentialRepository.Default;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static DotNetNuke.Social.Repositories.CredentialRepository CredentialRepository;
        public static Models.UserContext UserContext;
    }
}
