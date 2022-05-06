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
        public Send_Inst(int time, string[] args) : base(time, args, 2050)
        {
        }

        public override void Execute(NetWork network)
        {

            Host currentHost = (Host)network.NameLogicDevice[Args[0]];

            if (currentHost.Ports[0].Wire == null)
                return;
            if (currentHost.Ports[0].Wire.GetThreadToSend(currentHost.Ports[0]).Value == -1)
            {
                currentHost.IsSending = true;
                currentHost.Send(Args[1], Time);
                Time += 10;
                Priority -= 1;
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
                currentHost.WriteTxT(Time, Args[1][currentHost.CurrentBit].ToString(), true, true);
                Time += 10;
                network.PriorityQueue.Insert(this);
            }
        }
    }
}
