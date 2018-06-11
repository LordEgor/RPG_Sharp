using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG_Sharp
{
    /// <summary>
    /// Главная точка входа для приложения.
    /// </summary>
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RPGForm());
        }
    }
}
