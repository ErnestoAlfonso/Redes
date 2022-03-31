using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    interface IActions
    {
        void Send(string info);
        void Receive(Port receivePort);   

    }
}
