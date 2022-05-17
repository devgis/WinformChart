using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebChartForms
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //int count = 10;
            XProps xprops = new XProps();
            Application.Run(new DesignForm(xprops));
            string aaa = xprops.ToJson();

            ///xprops


            XProps xpropsReult = XProps.CopyXProps(xprops);
            EditForm A = new EditForm(xprops, xpropsReult);
            A.Show();
            string bbb = xpropsReult.ToJson();
            //Application.Run();
        }
    }
}
