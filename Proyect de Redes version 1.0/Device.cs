using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    abstract class Device
    {
        public Device(string name)
        {
            Name = name;
        }
        public string Name { get; }
    }
}
