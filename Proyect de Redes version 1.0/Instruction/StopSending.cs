using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    public class StopSending : Instruction
    {
        public StopSending(int time, string[] args) : base(time, args, 0)
        {
        }

        public override void Execute(NetWork network)
        {
            Host currentHost = (Host)network.NameLogicDevice[Args[0]];
            currentHost.IsSending = false;
            network.NameLogicDevice[Args[0]].Ports[0].Send("-1", Time);
        }
    }
}
