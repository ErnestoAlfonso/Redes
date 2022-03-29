using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0.Interpreter
{
    public class Instruction
    {
        public Instruction(int time, string inst_type, string[] args)
        {
            Time = time;
            Inst_type = inst_type;
            Args = args;
        }

        public int Time { get; set; }
        public string Inst_type { get; set; }
        public string[] Args { get; set; }
    }
}
