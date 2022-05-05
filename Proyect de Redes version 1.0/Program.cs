using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;


namespace Proyect_de_Redes_version_1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            //ManageNetWork manage = new ManageNetWork();
            //manage.Manage();
            int bytes = 4;
            string binBytes = Convert.ToString(bytes, 2);
            for (int i = binBytes.Length; i < 8; i++)
                binBytes = "0" + binBytes;
            Console.WriteLine(binBytes);
            //StreamWriter sw = File.AppendText(@"D:\Universidad\Proyecto de Redes");
            //sw.WriteLine("laskshdu");
        }
    }
}
