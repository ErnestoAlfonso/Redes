using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyect_de_Redes_version_1._0
{
    public class LogicDevice : Device
    {
        public LogicDevice(string name, int numberPorts) : base(name)
        {
            Ports = new Port[numberPorts];
            for (int i = 0; i < numberPorts; i++)
            {
                Ports[i] = new Port(name + "_" + i, this);
            }
            string root = Tools.root + this.Name + ".txt";
            TxT = File.AppendText(root);
        }
        public StreamWriter TxT { get; set; }
        public Port[] Ports { get; set; }
    }
}
