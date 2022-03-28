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
        public Dictionary<string,Port> NamePort { get; set; }
        public Dictionary<string,Host> NameHost { get; set; }
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
                    NameHost.Add(host.Name, host);
                    NamePort.Add(host._Port.Name, host._Port);
                }
                if (compress_list[2] == "hub")
                {
                    if (compress_list[4] == "8") numberports = 8;
                    Hub hub = new Hub(compress_list[3], numberports);
                    foreach (var item in hub.Ports)
                    {
                        NamePort.Add(item.Name, item);
                    }
                }
            }
            if (compress_list[1] == "connect")
            {
                NamePort[compress_list[2]].Connect(NamePort[compress_list[3]]);
            }
            if (compress_list[1] == "disconnect")
            {
                NamePort[compress_list[2]].Disconnect();
            }
            if (compress_list[1] == "send")
            {
                NameHost[compress_list[2]].Send(compress_list[3]);
            }
        }
    }
}
