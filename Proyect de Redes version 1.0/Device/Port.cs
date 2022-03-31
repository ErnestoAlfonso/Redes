using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_de_Redes_version_1._0
{
    public class Port : Device, IActions
    {
        public Port(string name, LogicDevice owner) : base(name)
        {
            Owner = owner;  
        } 


        public Wire _Wire { get; private set; }
        public LogicDevice Owner { get; } 
        public void Connect(Port port)
        {
            _Wire = new Wire(this, port); 
        }
        public void Disconnect()
        {
            _Wire = null;
        }

        public void Receive(Port receivePort)
        {
            throw new NotImplementedException();
        }

        public void Send(string info)
        {
            _Wire.Value = int.Parse(info);
            Port portR = _Wire.ReceivePort(Name);
            if(portR.Owner is Host)
            {
                Host hostR = (Host)portR.Owner;
                hostR.Receive(portR);
            }
            else
            {
                Hub hubR = (Hub)portR.Owner;
                hubR.Receive(portR);
            }
        }
    }
}
