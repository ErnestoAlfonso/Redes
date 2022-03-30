using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    public static class Parser
    {
        private static string[] CopyTo(string[] source, int start, int end)
        {
            string[] result = new string[end - start + 1];
            for (int i = start; i < end + 1; i++)
            {
                result[i - start] = source[i];
            }
            return result;
        }

        private static Type GetInstType(string str)
        {
            return Type.GetType("Proyect_de_Redes_version_1._0."+ str.First().ToString().ToUpper() + str.Substring(1) + "_Inst");
        }

        private static Instruction ParseLine(string line)
        {
            string[] splitedLine = line.Split();

            try
            {
                return (Instruction)Activator.CreateInstance(GetInstType(splitedLine[1]), 
                    new object[] { int.Parse(splitedLine[0]), CopyTo(splitedLine, 2, splitedLine.Length-1) });
            }
            catch (Exception)
            {
                Console.WriteLine("The first element needs to be an int, followed by a commnad and its args");
                return null;
            }
        }

        public static List<Instruction> ReadFile(System.IO.StreamReader file)
        {
            List<Instruction> instructions = new List<Instruction>();

            string line = file.ReadLine();
            while (line != null)
            {
                instructions.Add(ParseLine(line));

                line = file.ReadLine();
            }

            return instructions;
        }
    }
}
