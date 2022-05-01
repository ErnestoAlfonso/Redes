using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyect_de_Redes_version_1._0
{
    public class Hub : LogicDevice, IActions
    {
        public Hub(string name, int numberOfPorts) : base(name, numberOfPorts)
        {
        }

        public int ReceivePort { get; set; }
        public void Send(string bit, int time)
        {
            for (int i = 0; i < Ports.Length; i++)
            {
                if (i != ReceivePort)
                {
                    if (Ports[i].Wire != null)
                    {
                        Ports[i].Wire.Value = int.Parse(bit);
                        Port portR = Ports[i].Wire.ConnectedPort(Ports[i].Name);
                        if (portR.Owner is Host)
                        {
                            Host hostR = (Host)portR.Owner;
                            hostR.Ports[0].Wire.Value = int.Parse(bit);
                            hostR.Receive(portR, time);
                        }
                        else
                        {
                            Hub hubR = (Hub)portR.Owner;
                            hubR.Ports[portR.Name[int.Parse(portR.Name[portR.Name.Length - 1].ToString()) - 1]].Wire.Value = int.Parse(bit);
                            hubR.Receive(portR, time);
                        }
                    }
                }
            }
        }
        public void Receive(Port receivePort, int time)
        {//falta escribir el txt
            ReceivePort = int.Parse(receivePort.Name[receivePort.Name.Length - 1].ToString());
            string bit = receivePort.Wire.Value.ToString();
            if (bit != "-1")
                WriteTxT(time, bit);
            Send(bit, time);
        }
        public void WriteTxT(int time, string bit)
        {
            for (int i = 0; i < Ports.Length; i++)
            {
                if (i == ReceivePort)
                {
                    TxT.WriteLine(time + " " + Ports[i].Name + " receive " + bit);
                    //Console.WriteLine(time + " " + Ports[i].Name + " receive " + bit);
                }
                else
                {
                    TxT.WriteLine(time + " " + Ports[i].Name + " send " + bit);
                    //Console.WriteLine(time + " " + Ports[i].Name + " send " + bit);
                }
            }
            //TxT.Close();
        }
    }
}
