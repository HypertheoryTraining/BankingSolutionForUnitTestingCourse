using BankingDomain;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingKiosk
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*  //_account = new BankAccount(
            //    new CutoffBonusCalculator(new StandardCutoffClock(new SystemTime())),
            //    new WindowsFormsFedNotifier()
            //    ); */

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var container = new Container();
            container.Options.EnableAutoVerification = false;
            container.Register<ICalculateBankAccountBonuses, CutoffBonusCalculator>();
            container.Register<ISystemTime, SystemTime>();
            container.Register<IProvideTheCutoffClock, StandardCutoffClock>();
            container.Register<INotifyTheFeds, WindowsFormsFedNotifier>();
            container.Register<BankAccount>();
            container.Register<Form1>();
           
            var form = container.GetInstance<Form1>();
            
            Application.Run(form);
        }
    }
}
