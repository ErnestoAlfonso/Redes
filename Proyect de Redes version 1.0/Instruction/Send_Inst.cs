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
            //we need to review this implementation

            //Host currentHost = (Host)nWork.NameLogicDevice[Args[0]];
            //if (currentHost.Ports[0]._Wire.Value == -1)
            //{
            //    currentHost.Send(Args[1]);
            //    Time += 10;
            //    Priority -= 1;
            //    if (Args[1].Length > 1)
            //    {
            //        currentHost.CurrentBit++;
            //        nWork.PriorityQueue.Insert(this);
            //    }
            //    nWork.TimeToClean = Time;
            //}
            //else
            //{
            //    Time += 10;

            //}
            throw new NotImplementedException();
        }
    }
}
