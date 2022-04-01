using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    public class Send_Inst : Instruction
    {
        public Send_Inst(int time, string[] args) : base(time, args, 40)
        {
        }

        public override void Execute(NetWork network)
        {
            //    Host aux = (Host)NameLogicDevice[Args[0]];
            //    aux.Send(Args[1]);
            throw new NotImplementedException();
        }
    }
}
