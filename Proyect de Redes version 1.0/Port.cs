using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    class Port
    {
        public Port(string name)
        {
            Send = -1;
            Receive = -1;
            Name = name;
        }
        public bool IsACompPort { get; set; } //booleano para saber si es el puerto es de un computadora
        public bool IsAHubPort { get; set; } //booleano para saber si el puerto es de un hub
        public string Name { get; }
        public int Send { get; set; }
        public int Receive { get; set; }
        public Port Connection_Port { get; private set; }
        public void Connect(Port port_2)
        {
            Connection_Port = port_2;
            port_2.Connection_Port = this;
        }
        public void Disconnect()
        {
            this.Connection_Port.Connection_Port = null;
            this.Connection_Port = null;
        }
    }
}
