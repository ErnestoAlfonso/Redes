using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    public class Connect_Inst : Connection_Inst
    {
        public Connect_Inst(int time, string[] args) : base(time, args, 2)
        {
        }


        public override void Execute(NetWork network)
        {
            Port port1 = GetPort(Args[0], network);
            Port port2 = GetPort(Args[1], network);

            new Wire(port1, port2);
        }
    }
}
