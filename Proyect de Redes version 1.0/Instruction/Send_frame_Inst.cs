using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    public class Send_frame_Inst : Instruction
    {
        public Send_frame_Inst(int time, string[] args) : base(time, args, 5)
        {
        }

        public override void Execute(NetWork network)
        {
            Host currenthost = (Host)network.NameLogicDevice[Args[0]];
            Frame frame = new Frame(Args[1], currenthost.MacAddress, Args[2]);
            currenthost.FrameToSend = frame.CurrentFrame;
            string[] current_args = new string[2];
            current_args[0] = currenthost.Name;
            current_args[1] = currenthost.FrameToSend;
            Send_Inst send_instFTS = new Send_Inst(Time, current_args);
            network.PriorityQueue.Insert(send_instFTS);
        }
    }
}
