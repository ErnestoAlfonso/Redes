using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyect_de_Redes_version_1._0
{
    public class Create_Inst : Instruction
    {
        public Create_Inst(int time, string[] args) : base(time, args, 1)
        {
        }

        public override void Execute(NetWork network)
        {
            if (Args[0] == "host")
            {
                Host host = new Host(Args[1]);
                network.NameLogicDevice.Add(Args[1], host);
            }
            if (Args[0] == "hub")
            {
                Hub hub = new Hub(Args[1], int.Parse(Args[2]));
                network.NameLogicDevice.Add(Args[1], hub);
            }
            if (Args[0] == "switch")
            {
                Switch _switch = new Switch(Args[1], int.Parse(Args[2]));
                network.NameLogicDevice.Add(Args[1], _switch);
                network.Switches.Add(_switch);
            }

        }
    }
}
