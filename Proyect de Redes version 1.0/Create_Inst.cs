using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    public class Create_Inst : Instruction
    {
        public Create_Inst(int time, string[] args) : base(time, args)
        {
        }

        public override void Execute()
        {
            //we need to pass a Network object and update the dictionary
            if (Args[0] == "host")
            {
                Host host = new Host(Args[1]);
            }
            if (Args[0] == "hub")
            {
                Hub hub = new Hub(Args[1], int.Parse(Args[2]));
            }
        }
    }
}
