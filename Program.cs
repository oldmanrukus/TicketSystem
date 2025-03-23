using System;
using System.Windows.Forms;

namespace TicketingSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Ensure the database and required tables exist.
            DataAccess.EnsureDatabaseSetup();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm login = new LoginForm();
            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm(login.CurrentUser));
            }
        }
    }
}
