using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    public abstract class Connection_Inst : Instruction
    {
        protected Connection_Inst(int time, string[] args, int priority) : base(time, args, priority)
        {
        }

        protected Port GetPort(string arg, NetWork network)
        {
            string[] info = arg.Split('_');
            return network.NameLogicDevice[info[0]].Ports[int.Parse(info[1])];
        }

    }
}
