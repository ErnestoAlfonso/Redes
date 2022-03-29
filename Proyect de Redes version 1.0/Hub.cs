using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    class Hub : LogicDevice, IActions
    {
        public Hub(string name, int numberOfPorts) : base(name, numberOfPorts)
        {
        }


        public void Send(string bit)
        {
        }
        public void Receive(Port receivePort)
        {//falta escribir el txt



        }
    
    }
}
