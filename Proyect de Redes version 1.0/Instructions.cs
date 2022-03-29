using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    class Instructions
    {
        public Instructions(string instruction)
        {
            Instruction = instruction;
        }
        public Dictionary<string,LogicDevice> NameLogicDevice { get; set; }
        public string Instruction { get; }
        public static string[] Compress_List(string instruction)
        {
            string[] commands = instruction.Split();
            return commands;
        }
        public void Identify(string[] compress_list)
        {
            int numberports = 4;
            if (compress_list[1] == "create")
            {
                if (compress_list[2] == "host")
                {
                    Host host = new Host(compress_list[3]);
                    NameLogicDevice.Add(host.Name, host);
                }
                if (compress_list[2] == "hub")
                {
                    if (compress_list[4] == "8") numberports = 8;
                    Hub hub = new Hub(compress_list[3], numberports);
                    NameLogicDevice.Add(hub.Name, hub); 
                }
            }
            if (compress_list[1] == "connect")
            {
                string device1 = GetName(compress_list[2]);
                string device2 = GetName(compress_list[3]);
                NameLogicDevice[device1].Ports[int.Parse(device1[device1.Length - 1].ToString()) - 1].Connect(
                NameLogicDevice[device2].Ports[int.Parse(device2[device2.Length - 1].ToString()) - 1]); 
            }
            if (compress_list[1] == "disconnect")
            {
                string device1 = GetName(compress_list[2]);
                NameLogicDevice[device1].Ports[int.Parse(device1[device1.Length - 1].ToString()) - 1].Disconnect();


            }
            if (compress_list[1] == "send")
            {
                Host aux = (Host)NameLogicDevice[compress_list[2]];
                aux.Send(compress_list[3]);
            }
        }

        private string GetName(string port)
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
