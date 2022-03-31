using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHeap;

namespace Proyect_de_Redes_version_1._0
{
    internal class Parser
    {
        private System.IO.StreamReader _file;
        public Parser()
        {
            _file = new System.IO.StreamReader("../Static/Input/script.txt");
        }

        private static string[] CopyTo(string[] source, int start, int end)
        {
            string[] result = new string[end - start + 1];
            for (int i = start; i < end + 1; i++)
            {
                result[i - start] = source[i];
            }
            return result;
        }

        private Instruction ParseLine(string line)
        {
            string[] splitedLine = line.Split();
            int priority = 0;
            try
            {
                if (splitedLine[1] == "create") priority = 1;
                else if (splitedLine[1] == "connect") priority = 2;
                else if (splitedLine[1] == "disconnect") priority = 3;
                else if (splitedLine[1] == "send") priority = 40;     
                return new Instruction(int.Parse(splitedLine[0]), splitedLine[1], CopyTo(splitedLine, 2, splitedLine.Length - 1), priority);
           
            }
            catch (Exception)
            {
                Console.WriteLine("The first element needs to be an int, followed by a commnad and its args");
                return null;
            }
        }

        public Heap<Instruction> ReadFile()
        {
            Heap<Instruction> instructions = new Heap<Instruction>(true);
            string line = _file.ReadLine();
            while (line != null)
            {
                instructions.Insert(ParseLine(line));
            }

            return instructions;
        }
    }
}
