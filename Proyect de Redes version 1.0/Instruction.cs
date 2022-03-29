using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
     class Instruction
    {
        public Instruction(int time, string inst_type, string[] args)
        {
            Time = time;
            Inst_type = inst_type;
            Args = args;
            NameLogicDevice = new Dictionary<string, LogicDevice>();  
        }

        public int Time { get; set; }
        public string Inst_type { get; set; }
        public string[] Args { get; set; }

        public Dictionary<string, LogicDevice> NameLogicDevice { get; set; }

        public void ExecuteInstruccion()
        {
            if (Inst_type == "create")
            {
                if (Args[0] == "host")
                {
                    Host host = new Host(Args[1]);
                    NameLogicDevice.Add(host.Name, host);
                }
                if (Args[0] == "hub")
                {
                    Hub hub = new Hub(Args[1], int.Parse(Args[2]));
                    NameLogicDevice.Add(hub.Name, hub);
                }
            }
            if (Inst_type == "connect")
            {
                string device1 = GetName(Args[0]);
                string device2 = GetName(Args[1]);
                NameLogicDevice[device1].Ports[int.Parse(device1[device1.Length - 1].ToString()) - 1].Connect(
                NameLogicDevice[device2].Ports[int.Parse(device2[device2.Length - 1].ToString()) - 1]);
            }
            if (Inst_type == "disconnect")
            {
                string device1 = GetName(Args[0]);
                NameLogicDevice[device1].Ports[int.Parse(device1[device1.Length - 1].ToString()) - 1].Disconnect();


            }
            if (Inst_type == "send")
            {
                Host aux = (Host)NameLogicDevice[Args[0]];
                aux.Send(Args[1]);
            }
        }

        private static string GetName(string port)
        {
            string result = "";
            foreach (var item in port)
            {
                if (item != '_')
                    result += item;
            }
            return result;


        }
    }
}
