using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    class Port : Device
    {
        public Port(string name) : base(name)
        {
        } 
        public Wire _Wire { get; private set; }
        public void Connect(Port port)
        {
            _Wire = new Wire(this, port); 
        }
        public void Disconnect()
        {
            _Wire = null;
        }
    }
}
