using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    public class Wire
    {
        public Wire(Port port1, Port port2)
        {
            Port1 = port1;
            Port2 = port2;
            Port1.Wire = this;
            Port2.Wire = this;
            _1To2 = new Threads(port1, port2);
            _2To1 = new Threads(port2, port1);

            //poner respectivas propiedades threads. Estas siempre con el puerto de destino de 1ro
        }
        
        public Threads GetThreadToSend(Port currentPort)
        {
            if (_1To2.OriginPort.Name == currentPort.Name)
                return _1To2;
            return _2To1;
        }
        public Threads GetThreadToRecieve(Port currentPort)
        {
            if(_1To2.DestinationPort.Name == currentPort.Name)
                return _1To2;
            return _2To1;
        } 

        public Threads _1To2 { get; set; }
        public Threads _2To1 { get; set; }
        public Port Port1 { get; }
        public Port Port2 { get; }
        
        public Port ConnectedPort(string name)
        {
            if (Port1.Name == name)
                return Port2;
            else
                return Port1;
        }
            
    }
    public class Threads//quizas cambiar este nombre por hairs
    {
        public Threads(Port port1, Port port2) 
        {
            OriginPort = port1;
            DestinationPort = port2;
            Value = -1;
        }
        public Port DestinationPort { get; set; }
        public Port OriginPort { get; set; }
        public int Value { get; set; }
    }
}
