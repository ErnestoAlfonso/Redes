using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    class Hub
    {
        public Hub(string name, int NumberOfPorts)
        {
            Name = name;
            Ports = new Port[NumberOfPorts];
            for (int i = 0; i < NumberOfPorts; i++)
                Ports[i] = new Port(name + "_" + i+1);
        }
        public string Name { get; }
        public Port[] Ports { get; }

    }
}
