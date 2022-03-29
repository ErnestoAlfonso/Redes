using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyect_de_Redes_version_1._0
{
    class Host : LogicDevice, IActions
    {
        public Host(string name): base(name,1)
        {
        }
        public int CountTime { get; set; }

        public void Send(string info)
        {

        }//metodo para enviar la informacion que se quiere hacia el puerto requerido
        public int Receive()
        {
            return Ports[0]._Wire.Value;
        }

    }
}
