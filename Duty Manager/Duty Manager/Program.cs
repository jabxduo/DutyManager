using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Duty_Manager
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

            List<Lodger> lodgers;
            lodgers = LodgerParser.LoadLodgers();
            foreach (Lodger lodger in lodgers)
            {
                Console.WriteLine(lodger.Name + ": " + lodger.IsKitchen + ": " + lodger.FloorNumber);
            }
            List<Duty> duties;
            duties = DutyParser.LoadDuties();
            foreach (Duty d in duties)
            {
                Console.WriteLine(d.DutyId + ": " + d.FloorNumber + ": " + d.Description);
            }

            Application.Run(new Form1());
        }
    }
}
