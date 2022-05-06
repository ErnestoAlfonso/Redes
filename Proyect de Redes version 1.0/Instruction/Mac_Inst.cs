using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    public class Mac_Inst : Instruction
    {
        public Mac_Inst(int time, string[] args) : base(time, args, 2)
        {
        }

        public override void Execute(NetWork network)
        {
            Host currentHost = (Host)network.NameLogicDevice[Args[0]];
            currentHost.MacAddress = Args[1];
        }
    }
}
