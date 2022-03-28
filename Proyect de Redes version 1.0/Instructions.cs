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
                }
                if (compress_list[2] == "hub")
                {
                    if (compress_list[4] == "8") numberports = 8;
                    Hub hub = new Hub(compress_list[3], numberports);
                }
            }
            if (compress_list[1] == "connect")
            {
                compress_list[2]
            }
            if (compress_list[1] == "disconnect")
            {
                Port port = new Port(compress_list[2]);
                port.Disconnect();
            }
            if (compress_list[1] == "send")
            {
                List<int> info = new List<int>();
                Host host = new Host(compress_list[2]);
                foreach (char item in compress_list[3])
                {
                    info.Add((int)item);
                }
                host.Send(info);
            }
        }
    }
}
