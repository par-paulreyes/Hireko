using Hireko.Forms;
using Hireko.Database;

namespace Hireko
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            DatabaseInitializer initializer = new DatabaseInitializer();
            initializer.InitializeDatabase();

            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm()); //Ito unang magrurun
        }
    }
}
