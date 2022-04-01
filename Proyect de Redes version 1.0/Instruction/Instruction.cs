using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    public abstract class Instruction: IComparable<Instruction>
    {
        public Instruction(int time, string[] args, int priority)
        {
            Time = time;
            Args = args;
            Priority = priority;
        }
        

        public int Time { get; set; }
        public string[] Args { get; set; }
        public int Priority { get; private set; }

        public int CompareTo(Instruction other)
        {
            if (Time < other.Time) return -1;
            else if (Time > other.Time) return 1;
            else
            {
                if (Priority < other.Priority) return -1;
                else return 1;
            }
        }

        public abstract void Execute(NetWork network);
       
            //if (Inst_type == "create")
            //{
            //    if (Args[0] == "host")
            //    {
            //        Host host = new Host(Args[1]);
            //        NameLogicDevice.Add(host.Name, host);
            //    }
            //    if (Args[0] == "hub")
            //    {
            //        Hub hub = new Hub(Args[1], int.Parse(Args[2]));
            //        NameLogicDevice.Add(hub.Name, hub);
            //    }
            //}
            //if (Inst_type == "connect")
            //{
            //    string device1 = GetName(Args[0]);
            //    string device2 = GetName(Args[1]);
            //    NameLogicDevice[device1].Ports[int.Parse(device1[device1.Length - 1].ToString()) - 1].Connect(
            //    NameLogicDevice[device2].Ports[int.Parse(device2[device2.Length - 1].ToString()) - 1]);
            //}
            //if (Inst_type == "disconnect")
            //{
            //    string device1 = GetName(Args[0]);
            //    NameLogicDevice[device1].Ports[int.Parse(device1[device1.Length - 1].ToString()) - 1].Disconnect();


            //}
            //if (Inst_type == "send")
            //{
            //    Host aux = (Host)NameLogicDevice[Args[0]];
            //    aux.Send(Args[1]);
            //}
        
    }
}
