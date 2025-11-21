using DataGridView.Services;
using DataGridViewProject.Forms;

namespace DataGridViewProject
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(new StudentService(new InMemoryStorage())));
        }
    }
}