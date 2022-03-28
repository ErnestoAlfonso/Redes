using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyect_de_Redes_version_1._0
{
    class LoadAndSaveScripts
    {
        //pasar para un nuevo array las instrucciones q estan entre dos indices dados
        private static string[] CopyTo(string[] source, int start, int end)
        {
            string[] result = new string[end - start +1];
            for (int i = start; i < end+1; i++)
            {
                result[i - start] = source[i];
            }
            return result;
        }

        //diccionario q agrupa las instrucciones por cada tiempo
        public static Dictionary<int,string[]> Load(string root)
        {
            Dictionary<int, string[]> timeInstruccions = new Dictionary<int, string[]>();
            string[] lines = File.ReadAllLines(root);
            int count = 0;
            int time = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (i == lines.Length - 1 || lines[i][0] != lines[i + 1][0])
                {
                    timeInstruccions.Add(time*10, CopyTo(lines, i - count, i));
                    count = 0;
                    time++;
                }
                else
                    count++;
            }
            return timeInstruccions;
        }




    }
}
