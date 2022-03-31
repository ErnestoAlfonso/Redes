using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    // class Instruction : IComparable<Instruction>
    //{
    //    public Instruction(int time, string inst_type, string[] args, int priority)
    //    {
    //        Time = time;
    //        Inst_type = inst_type;
    //        Args = args;
    //        Priority = priority;
    //     }
        

    //    public int Time { get; set; }
    //    public string Inst_type { get; set; }
    //    public string[] Args { get; set; }
    //    public int Priority { get; private set; }

    //    public void Execute(NetWork nWork)
    //    {
    //        if (Inst_type == "create")
    //        {
    //            if (Args[0] == "host")
    //            {
    //                Host host = new Host(Args[1]);
    //                nWork.NameLogicDevice.Add(host.Name, host);
    //            }
    //            if (Args[0] == "hub")
    //            {
    //                Hub hub = new Hub(Args[1], int.Parse(Args[2]));
    //                nWork.NameLogicDevice.Add(hub.Name, hub);
    //            }
    //        }
    //        if (Inst_type == "connect")
    //        {
    //            string device1 = GetName(Args[0]);
    //            string device2 = GetName(Args[1]);
    //            nWork.NameLogicDevice[device1].Ports[int.Parse(device1[device1.Length - 1].ToString()) - 1].Connect(
    //            nWork.NameLogicDevice[device2].Ports[int.Parse(device2[device2.Length - 1].ToString()) - 1]);
    //            nWork.AllWires.AddLast
    //                (nWork.NameLogicDevice[device1].Ports[int.Parse(device1[device1.Length - 1].ToString()) - 1]._Wire);

    //        }
    //        if (Inst_type == "disconnect")
    //        {
    //            string device1 = GetName(Args[0]);
    //            nWork.AllWires.Remove(nWork.NameLogicDevice[device1].Ports[int.Parse(device1[device1.Length -1].ToString()) - 1]._Wire);
    //            nWork.NameLogicDevice[device1].Ports[int.Parse(device1[device1.Length - 1].ToString()) - 1].Disconnect();
    //        }
    //        if (Inst_type == "send")
    //        {//terminar
    //            Host currentHost = (Host)nWork.NameLogicDevice[Args[0]];
    //            if(currentHost.Ports[0]._Wire.Value == -1)
    //            {
    //                currentHost.Send(Args[1]);
    //                Time += 10;
    //                Priority -= 1;
    //                if(Args[1].Length > 1)
    //                {
    //                    currentHost.CurrentBit++;
    //                    nWork.PriorityQueue.Insert(this);
    //                }
    //                nWork.TimeToClean = Time;
    //            }
    //            else
    //            {
    //                Time += 10;

    //            }


    //        }
    //    }
    //    private static string GetName(string port)
    //    {
    //        string result = "";
    //        foreach (var item in port)
    //        {
    //            if (item == '_') break;
    //            result += item;
    //        }
    //        return result;

    //    }
    //    public int CompareTo(Instruction other)
    //    {
    //        if (Time < other.Time) return -1;
    //        else if (Time > other.Time) return 1;
    //        else
    //        {
    //            if (Priority < other.Priority) return -1;
    //            else return 1;
    //        }
    //    }
    //}
}
