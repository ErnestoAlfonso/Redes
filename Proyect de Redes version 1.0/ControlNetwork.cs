using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    class ControlNetwork
    {

        public static void ManageNetwork()
        {
            int time = 0;
            Parser parser = new Parser();
            Queue<Instruction> instructions = parser.ReadFile();
            Queue<Instruction> sendsInstructions = new Queue<Instruction>();
            bool end = false;
            while (!end)
            {
                while (instructions.Count > 0 && instructions.Peek().Time == time)
                {
                    Instruction currentInstruction = instructions.Dequeue();
                    if(currentInstruction.Inst_type)
                    currentInstruction.Execute();
                }




            }



        }





    }
}
