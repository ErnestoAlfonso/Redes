using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyect_de_Redes_version_1._0
{
    class LogicDevice : Device
    {
        public LogicDevice(string name, int numberPorts) : base(name)
        {
            Ports = new Port[numberPorts];
            for (int i = 0; i < numberPorts; i++) 
            {
                Ports[i] = new Port(name + "_" + i + 1, this);
            }
            MyTxt = new StreamWriter(name + ".txt");
        }
        public StreamWriter MyTxt { get; set; }
        public Port[] Ports { get; set; }
    }
}
