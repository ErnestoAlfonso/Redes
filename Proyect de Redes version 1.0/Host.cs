using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyect_de_Redes_version_1._0
{
    class Host
    {
        public Host( string name)
        {
            _Port = new Port(name + "_1");
            Name = name;
            CountTime = 0;
        }
        public int CountTime { get; set; }
        public string Name { get; }
        public Port _Port { get; }
        public void Send(string info)
        {
            _Port.Send = int.Parse(info[CountTime].ToString());
            _Port.Connection_Port.Receive = _Port.Send;
        }//metodo para enviar la informacion que se quiere hacia el puerto requerido
    }
}
