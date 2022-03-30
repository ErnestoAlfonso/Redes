using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.IO;


namespace Proyect_de_Redes_version_1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            //StreamWriter sw = File.AppendText(@"D:\Universidad\Proyecto de Redes");
            //sw.WriteLine("laskshdu");
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\Pablo Alonso\Documents\script.txt");
            List<Instruction> insts = Parser.ReadFile(file);
            Console.WriteLine(insts.Count);
            Console.ReadLine();

        }
    }
}
