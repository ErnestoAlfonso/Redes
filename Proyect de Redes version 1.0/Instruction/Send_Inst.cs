using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyect_de_Redes_version_1._0
{
    public class Send_Inst : Instruction
    {
        public Send_Inst(int time, string[] args) : base(time, args, 40)
        {
        }

        public override void Execute(NetWork network)
        {

            Host currentHost = (Host)network.NameLogicDevice[Args[0]];
            if (currentHost.Ports[0].Wire.Value == -1)
            {
                currentHost.Send(Args[1], Time);
                Time += 10;
                Priority -= 1;
                currentHost.IsSending = true;
                if (currentHost.CurrentBit < Args[1].Length - 1)
                {
                    currentHost.CurrentBit++;
                    network.PriorityQueue.Insert(this);
                }
                network.SendTime = (Args[1].Length - currentHost.CurrentBit +1) * 10;
                network.PriorityQueue.Insert(new StopSending(Time, Args));
            }
            else
            {
                currentHost.WriteTxT(Time, Args[1][currentHost.CurrentBit].ToString(), true);
                Time += network.SendTime;

            }
        }
    }
}
