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
            #region prueba
            //Stopwatch clock = new Stopwatch();
            //clock.Start();
            //int count = 0;
            //while (clock.IsRunning)
            //{
            //    if (clock.ElapsedMilliseconds % 10 == 0 && clock.ElapsedMilliseconds == time[count])
            //    {
            //        a.Send(info);
            //        Console.WriteLine(b._Port.Receive + " " + clock.ElapsedMilliseconds);
            //        a.CountTime++;
            //        count++;


            //    if (a.CountTime >= info.Length)
            //        break;
            //}
            //clock.Stop();
            #endregion
            Dictionary<int, string[]> timeInstrucctions = LoadAndSaveScripts.Load(@"D:\Universidad\Proyect de Redes version 1.0\Scripts.txt");
            //notar q siempre se tiene que especificar la direcccion del txt si se cambia de lugar
            //for (int j = 0; j < 30; j+=10)
            //{
            //    for (int i = 0; i < timeInstrucctions[j].Length; i++)
            //    {
            //        Console.WriteLine(timeInstrucctions[j][i]);
            //    }

            //}

        }
    }
}
