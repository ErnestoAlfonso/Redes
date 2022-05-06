using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    interface IActions
    {
        void Send(string info, int time, bool end);
        void Receive(Port receivePort, int time, bool end);   

    }
}
